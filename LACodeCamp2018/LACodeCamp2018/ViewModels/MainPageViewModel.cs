using LACodeCamp2018.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LACodeCamp2018.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavToNextPageCommand { get; set; }

        IPageDialogService _pageDialogService;

        public MainPageViewModel(INavigationService navigationService, 
            IPageDialogService pageDialogService,
            IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            _pageDialogService = pageDialogService;
            Title = "Main Page";
            NavToNextPageCommand = new DelegateCommand(OnNavToNextPageTapped);
        }

        private async void OnNavToNextPageTapped()
        {
            Console.WriteLine($"{this.GetType().Name}.{nameof(OnNavToNextPageTapped)}");

            bool userWouldLikeToNavigate = await _pageDialogService.DisplayAlertAsync("Really?",
                "Are you sure you would like to navigate to the magical, mystical next page?",
                "Yes!",
                "Nope");

            Console.WriteLine($"User has responded to the alert. Do they wish to navigate:  {userWouldLikeToNavigate}.");

            if (userWouldLikeToNavigate)
            {
                await _navigationService.NavigateAsync(nameof(NextPage));
            }
        }
    }
}
