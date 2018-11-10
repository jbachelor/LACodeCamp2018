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

        private ObservableCollection<string> _userEvents;
        public ObservableCollection<string> UserEvents
        {
            get { return _userEvents; }
            set { SetProperty(ref _userEvents, value); }
        }

        public DelegateCommand<string> ItemTappedCommand { get; set; }

        public NextPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator,
            IUserEventTracker userEventTracker)
            : base(navigationService, eventAggregator)
        {
            _userEventTracker = userEventTracker;
            ItemTappedCommand = new DelegateCommand<string>(OnItemTapped);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Dictionary<DateTime, string> trackedEvents = _userEventTracker.GetEvents();
            UserEvents = new ObservableCollection<string>(trackedEvents.Values);
        }

        private void OnItemTapped(string trackedEvent)
        {
            _eventAggregator.GetEvent<TrackUserEvent>().Publish($"{this.GetType().Name}.{nameof(OnItemTapped)}: {trackedEvent}");
        }

    }
}
