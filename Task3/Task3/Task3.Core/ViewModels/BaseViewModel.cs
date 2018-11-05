using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Newtonsoft.Json;

namespace Task3.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns>An instance of the service.</returns>
        public TService GetService<TService>() where TService : class
        {
            return Mvx.Resolve<TService>();
        }

        private const string ParameterName = "parameter";
        protected void ShowViewModel<TViewModel>(object parameter) where TViewModel : IMvxViewModel
        {
            var text = JsonConvert.SerializeObject(parameter);
            base.ShowViewModel<TViewModel>(new Dictionary<string, string>()
            {
                {ParameterName, text}
            });
        }

        protected void ShowViewModel<TViewModel>(string json) where TViewModel : IMvxViewModel
        {
            base.ShowViewModel<TViewModel>(new Dictionary<string, string>()
            {
                {ParameterName, json}
            });
        }
    }

    public abstract class ViewModelBase<TInit> : BaseViewModel
    {
        /// <summary>
        /// Инициализация модели
        /// </summary>
        /// <param name="parameter"></param>
        public void Init(string parameter)
        {
            var deserialized = JsonConvert.DeserializeObject<TInit>(parameter);
            RealInit(deserialized);
        }

        /// <summary>
        /// Инициализация модели
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void RealInit(TInit parameter);
    }
}
