using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xfObjectToFile.ViewModels
{
    using System.ComponentModel;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using xfObjectToFile.Storages;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public DelegateCommand WriteCommand { get; set; }
        public DelegateCommand ReadCommand { get; set; }
        public string Message { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            WriteCommand = new DelegateCommand(async () =>
            {
                var yourClass = new YourClass()
                {
                    Id = 168,
                    MyClasee = new MyClass()
                    {
                        MyPropertyInt = 20,
                        MyPropertyString = "Vulcan Lee",
                        MyPropertyDateTime = DateTime.Now.AddDays(-3),
                        MyPropertyDouble = 99.82,
                        MyPropertyTimeSpan = new TimeSpan(15, 23, 58),
                    }
                };
                await StorageJSONService<YourClass>.WriteToDataFileAsync(
                    "VulcanDir", nameof(YourClass), yourClass);
                Message = "YourClass 類別執行個體已經儲存到手機內";

            });
            ReadCommand = new DelegateCommand(async () =>
            {
                var yourClass = await StorageJSONService<YourClass>.ReadFromFileAsync(
                      "VulcanDir", nameof(YourClass));
                string json = JsonConvert.SerializeObject(yourClass);
                Message = $"讀取成功:{json}";
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

    }
}
