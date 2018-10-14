using System;
using System.Diagnostics;
using Foundation;
using Security;
using UIKit;

namespace Task3.iOS.Infrastructure.Utils
{
    public static class DeviceSpecific
    {
        public static nfloat Margin => UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone ? 40 : 110f;

        public static string GetDeviceId()
        {
            string id;
            var ServiceId = "KeyChainAccountStore";

            //use the bundle identifier of the app to identifie the value in the keychain
            string appId = NSBundle.MainBundle.InfoDictionary["CFBundleIdentifier"].ToString();

            //Try to read the id from the keychain
            var rec = new SecRecord(SecKind.GenericPassword)
            {
                Service = ServiceId,
                Account = appId,
            };

            var match = SecKeyChain.QueryAsRecord(rec, out _);

            //Store a new ID to the keychain
            if (match?.Generic == null)
            {
                //Get the vendor ID (does change after a reinstall of the app)
                var vendorId = UIDevice.CurrentDevice.IdentifierForVendor.AsString().Replace("-", "");
                var record = new SecRecord(SecKind.GenericPassword)
                {
                    Service = ServiceId,
                    Account = appId,
                    Generic = NSData.FromString(vendorId),
                    Accessible = SecAccessible.Always
                };

                var statusCode = SecKeyChain.Add(record);
                if (statusCode != SecStatusCode.Success)
                    Debug.WriteLine("Could not save key to KeyChain: " + statusCode);

                id = vendorId;
            }
            else
            {   //Use ID from keychain
                id = match.Generic.ToString();
            }

            return id;
        }
    }
}
