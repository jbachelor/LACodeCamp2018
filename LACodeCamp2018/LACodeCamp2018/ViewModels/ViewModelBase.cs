using LACodeCamp2018.Services;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace LACodeCamp2018.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService _navigationService { get; private set; }
        protected IEventAggregator _eventAggregator { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<TrackUserEvent>().Publish($"{this.GetType().Name}:  ctor");
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<TrackUserEvent>().Publish($"{this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<TrackUserEvent>().Publish($"{this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<TrackUserEvent>().Publish($"{this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }

        public virtual void Destroy()
        {
            _eventAggregator.GetEvent<TrackUserEvent>().Publish($"{this.GetType().Name}.{nameof(Destroy)}");
        }
    }
}
