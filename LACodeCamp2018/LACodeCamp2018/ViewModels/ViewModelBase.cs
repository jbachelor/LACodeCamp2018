using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LACodeCamp2018.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            System.Console.WriteLine($"{this.GetType().Name}:  ctor");
            NavigationService = navigationService;   
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
