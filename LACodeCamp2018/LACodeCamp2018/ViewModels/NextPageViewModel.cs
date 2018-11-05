using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LACodeCamp2018.ViewModels
{
	public class NextPageViewModel : ViewModelBase
	{
        public NextPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
