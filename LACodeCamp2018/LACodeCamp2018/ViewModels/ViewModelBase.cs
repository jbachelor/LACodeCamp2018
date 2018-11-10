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
            System.Console.WriteLine($"{this.GetType().Name}:  ctor");
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            System.Console.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            System.Console.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            System.Console.WriteLine($"{this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }

        public virtual void Destroy()
        {
            System.Console.WriteLine($"{this.GetType().Name}.{nameof(Destroy)}");
        }
    }
}
