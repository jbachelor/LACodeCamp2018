using LACodeCamp2018.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LACodeCamp2018.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavToNextPageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            NavToNextPageCommand = new DelegateCommand(OnNavToNextPageTapped);
        }

        private async void OnNavToNextPageTapped()
        {
            System.Console.WriteLine($"{this.GetType().Name}.{nameof(OnNavToNextPageTapped)}");
            await NavigationService.NavigateAsync(nameof(NextPage));
        }
    }
}
