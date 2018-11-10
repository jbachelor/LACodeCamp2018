using LACodeCamp2018.Services;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LACodeCamp2018.ViewModels
{
	public class NextPageViewModel : ViewModelBase
	{
        protected IUserEventTracker _userEventTracker;

        private ObservableCollection<KeyValuePair<DateTime, string>> _userEvents;
        public ObservableCollection<KeyValuePair<DateTime, string>> UserEvents
        {
            get { return _userEvents; }
            set { SetProperty(ref _userEvents, value); }
        }

        public NextPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator,
            IUserEventTracker userEventTracker)
            : base(navigationService, eventAggregator)
        {
            _userEventTracker = userEventTracker;
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Dictionary<DateTime, string> trackedEvents = _userEventTracker.GetEvents();
            UserEvents = new ObservableCollection<KeyValuePair<DateTime, string>>(trackedEvents);
        }
    }
}
