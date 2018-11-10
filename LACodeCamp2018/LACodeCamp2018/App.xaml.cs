using Prism;
using Prism.Ioc;
using LACodeCamp2018.ViewModels;
using LACodeCamp2018.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LACodeCamp2018.Services;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LACodeCamp2018
{
    public partial class App
    {

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Console.WriteLine($"{this.GetType().Name}.{nameof(OnInitialized)}");
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            Console.WriteLine($"{this.GetType().Name}.{nameof(RegisterTypes)}");
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NextPage, NextPageViewModel>();

            containerRegistry.RegisterSingleton<IUserEventTracker, UserEventTracker>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            Console.WriteLine($"{this.GetType().Name}.{nameof(OnStart)}");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            Console.WriteLine($"{this.GetType().Name}.{nameof(OnSleep)}");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Console.WriteLine($"{this.GetType().Name}.{nameof(OnResume)}");
        }
    }
}
