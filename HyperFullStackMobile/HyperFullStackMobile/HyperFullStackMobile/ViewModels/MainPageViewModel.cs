using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HyperFullStackMobile.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Net.Http;
    using System.Threading.Tasks;
    using HyperFullStackMobile.Models;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public ObservableCollection<BlogPost> BlogPostItems { get; set; } = new ObservableCollection<BlogPost>();
        public DelegateCommand PullRefreshCommand { get; set; }
        public bool IsRefreshing { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            PullRefreshCommand = new DelegateCommand(async () =>
            {
                await Reload();
                IsRefreshing = false;
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await Reload();
        }
        async Task Reload()
        {
            BlogPostItems.Clear();
            HttpClient client = new HttpClient();
            string rawBlog = await client.GetStringAsync("http://192.168.31.153:5000/api/Blog");
            var getItems = JsonConvert.DeserializeObject<List<BlogPost>>(rawBlog);
            foreach (var item in getItems)
            {
                BlogPostItems.Add(item);
            }
        }
    }
}
