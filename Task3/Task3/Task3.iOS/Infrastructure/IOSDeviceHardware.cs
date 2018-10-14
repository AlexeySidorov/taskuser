using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using UIKit;

// ReSharper disable InconsistentNaming

namespace Task3.iOS.Infrastructure
{
    //https://www.theiphonewiki.com/wiki/Models
    public class IosDeviceHardware
    {
        /// <summary>
        /// Hardware property
        /// </summary>
        public const string HardwareProperty = "hw.machine";

        public enum IosHardware
        {
            iPhone,
            iPhone3G,
            iPhone3GS,
            iPhone4,
            iPhone4RevA,
            iPhone4CDMA,
            iPhone4S,
            iPhone5GSM,
            iPhone5CDMAGSM,
            iPhone5CGSM,
            iPhone5CCAG,
            iPhone5SGSM,
            iPhone5SCAG,
            iPhone6Plus,
            iPhone6,
            iPhone6S,
            iPhone6SPlus,
            iPhoneSE,
            iPhone7,
            iPhone7Intel,
            iPhone7Plus,
            iPhone7IntelPlus,
            iPodTouch1G,
            iPodTouch2G,
            iPodTouch3G,
            iPodTouch4G,
            iPodTouch5G,
            iPad,
            iPad3G,
            iPad2,
            iPad2GSM,
            iPad2CDMA,
            iPad2RevA,
            iPadMini,
            iPadMiniGSM,
            iPadMiniCDMAGSM,
            iPad3,
            iPad3CDMA,
            iPad3GSM,
            iPad4,
            iPad4GSM,
            iPad4CDMAGSM,
            iPhoneSimulator,
            iPhoneRetinaSimulator,
            iPadSimulator,
            iPadRetinaSimulator,
            Unknown
        }

        [DllImport(Constants.SystemLibrary)]
        internal static extern int sysctlbyname([MarshalAs(UnmanagedType.LPStr)] string property, IntPtr output, IntPtr oldLen, IntPtr newp, uint newlen);

        /// <summary>
        /// Version
        /// </summary>
        public static IosHardware Version
        {
            get
            {
                var pLen = Marshal.AllocHGlobal(sizeof(int));
                sysctlbyname(HardwareProperty, IntPtr.Zero, pLen, IntPtr.Zero, 0);

                var length = Marshal.ReadInt32(pLen);

                if (length == 0)
                {
                    Marshal.FreeHGlobal(pLen);
                    return IosHardware.Unknown;
                }

                var pStr = Marshal.AllocHGlobal(length);
                sysctlbyname(HardwareProperty, pStr, pLen, IntPtr.Zero, 0);

                var hardwareStr = Marshal.PtrToStringAnsi(pStr);

                Marshal.FreeHGlobal(pLen);
                Marshal.FreeHGlobal(pStr);

                //iPhone version
                if (hardwareStr == "iPhone1,1") return IosHardware.iPhone;
                if (hardwareStr == "iPhone1,2") return IosHardware.iPhone3G;
                if (hardwareStr == "iPhone2,1") return IosHardware.iPhone3GS;
                if (hardwareStr == "iPhone3,1") return IosHardware.iPhone4;
                if (hardwareStr == "iPhone3,2") return IosHardware.iPhone4RevA;
                if (hardwareStr == "iPhone3,3") return IosHardware.iPhone4CDMA;
                if (hardwareStr == "iPhone4,1") return IosHardware.iPhone4S;
                if (hardwareStr == "iPhone5,1") return IosHardware.iPhone5GSM;
                if (hardwareStr == "iPhone5,2") return IosHardware.iPhone5CDMAGSM;
                if (hardwareStr == "iPhone5,3") return IosHardware.iPhone5CGSM; //iPhone 5c (model A1456, A1532 | GSM)
                if (hardwareStr == "iPhone5,4") return IosHardware.iPhone5CCAG;  //iPhone 5c (model A1507, A1516, A1526 (China), A1529 | Global)
                if (hardwareStr == "iPhone6,1") return IosHardware.iPhone5SGSM; //iPhone 5s (model A1433, A1533 | GSM)
                if (hardwareStr == "iPhone6,2") return IosHardware.iPhone5SCAG;  //iPhone 5s (model A1457, A1518, A1528 (China), A1530 | Global)
                if (hardwareStr == "iPhone7,1") return IosHardware.iPhone6Plus; //iPhone 6 Plus
                if (hardwareStr == "iPhone7,2") return IosHardware.iPhone6; //iPhone 6
                if (hardwareStr == "iPhone8,1") return IosHardware.iPhone6S;  //iPhone 6S
                if (hardwareStr == "iPhone8,2") return IosHardware.iPhone6SPlus; //iPhone 6S Plus
                if (hardwareStr == "iPhone8,4") return IosHardware.iPhoneSE;  //iPhone SE
                if (hardwareStr == "iPhone9,1") return IosHardware.iPhone7;  //iPhone 7 (model A1660 A1779 A1780)
                if (hardwareStr == "iPhone9,2") return IosHardware.iPhone7Plus; //iPhone 7 Plus (model A1661, A1785, A1786)
                if (hardwareStr == "iPhone9,3") return IosHardware.iPhone7Intel;  //iPhone 7 (model A1778)
                if (hardwareStr == "iPhone9,4") return IosHardware.iPhone7IntelPlus; //iPhone 7 Plus (model A1784)

                //iPad version TODO: нет новых моделей. Добавить при не обходимости
                if (hardwareStr == "iPad1,1") return IosHardware.iPad;
                if (hardwareStr == "iPad1,2") return IosHardware.iPad3G;
                if (hardwareStr == "iPad2,1") return IosHardware.iPad2;
                if (hardwareStr == "iPad2,2") return IosHardware.iPad2GSM;
                if (hardwareStr == "iPad2,3") return IosHardware.iPad2CDMA;
                if (hardwareStr == "iPad2,4") return IosHardware.iPad2RevA;
                if (hardwareStr == "iPad2,5") return IosHardware.iPadMini;
                if (hardwareStr == "iPad2,6") return IosHardware.iPadMiniGSM;
                if (hardwareStr == "iPad2,7") return IosHardware.iPadMiniCDMAGSM;
                if (hardwareStr == "iPad3,1") return IosHardware.iPad3;
                if (hardwareStr == "iPad3,2") return IosHardware.iPad3CDMA;
                if (hardwareStr == "iPad3,3") return IosHardware.iPad3GSM;
                if (hardwareStr == "iPad3,4") return IosHardware.iPad4;
                if (hardwareStr == "iPad3,5") return IosHardware.iPad4GSM;
                if (hardwareStr == "iPad3,6") return IosHardware.iPad4CDMAGSM;

                //iPod version TODO: нет новых моделей. Добавить при не обходимости
                if (hardwareStr == "iPod1,1") return IosHardware.iPodTouch1G;
                if (hardwareStr == "iPod2,1") return IosHardware.iPodTouch2G;
                if (hardwareStr == "iPod3,1") return IosHardware.iPodTouch3G;
                if (hardwareStr == "iPod4,1") return IosHardware.iPodTouch4G;
                if (hardwareStr == "iPod5,1") return IosHardware.iPodTouch5G;

                if (hardwareStr == "i386" || hardwareStr == "x86_64")
                {
                    if (UIDevice.CurrentDevice.Model.Contains("iPhone"))
                    {
                        if (UIScreen.MainScreen.Scale > 1.5f)
                            return IosHardware.iPhoneRetinaSimulator;
                        else
                            return IosHardware.iPhoneSimulator;
                    }
                    else
                    {
                        if (UIScreen.MainScreen.Scale > 1.5f)
                            return IosHardware.iPadRetinaSimulator;
                        else
                            return IosHardware.iPadSimulator;
                    }
                }

                return IosHardware.Unknown;
            }
        }

        /// <summary>
        /// Iphone с большими экранами
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool BigIphone(IosHardware version)
        {
            return version == IosHardware.iPhoneRetinaSimulator || version == IosHardware.iPhone6 || version == IosHardware.iPhone6Plus || 
                   version == IosHardware.iPhone6S || version == IosHardware.iPhone6SPlus || version == IosHardware.iPhone7 ||
                   version == IosHardware.iPhone7Plus || version == IosHardware.iPhone7Intel || version == IosHardware.iPhone7IntelPlus;
        }

        /// <summary>
        /// Сдатнтарный Iphone
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool StandartIphone(IosHardware version)
        {
            return version == IosHardware.iPhoneSimulator || version == IosHardware.iPhone4S || version == IosHardware.iPhone5SGSM || 
                   version == IosHardware.iPhone5GSM || version == IosHardware.iPhone5CGSM || version == IosHardware.iPhone5CCAG || 
                   version == IosHardware.iPhone5SCAG || version == IosHardware.iPhone5CDMAGSM;
        }

        /// <summary>
        /// Самый маленький по высоте
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static bool SmallHeightIphone(IosHardware version)
        {
            return version == IosHardware.iPhone4S || version == IosHardware.iPhone4 ||
                   version == IosHardware.iPhone4RevA;
        }

    }
}
