using System;
using Microsoft.Practices.Prism.Mvvm;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Unity;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace PrismDemo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : MvvmAppBase
    {
        IUnityContainer _container = new UnityContainer();
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // Register MvvmAppBase services with the container so that view models can take dependencies on them
            _container.RegisterInstance<ISessionStateService>(SessionStateService);
            _container.RegisterInstance<INavigationService>(NavigationService);
            // Register any app specific types with the container

            // Set a factory for the ViewModelLocator to use the container to construct view models so their 
            // dependencies get injected by the container
            ViewModelLocationProvider.SetDefaultViewModelFactory((viewModelType) => _container.Resolve(viewModelType));
            return Task.FromResult<object>(null);
        }

    }
}