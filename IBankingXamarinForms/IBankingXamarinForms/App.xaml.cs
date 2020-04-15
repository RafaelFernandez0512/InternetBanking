using IBankingXamarinForms.Helpers;
using IBankingXamarinForms.Services;
using IBankingXamarinForms.ViewModels;
using IBankingXamarinForms.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBankingXamarinForms
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }
        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"{ConfigPage.MenuTabbedPage}",UriKind.Absolute));
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance <IApiBanking>(new ApiBanking());
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterTransactionPage, RegisterTransactionPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuTabbedPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<TransactionPage, TransactionPageViewModel>();
            containerRegistry.RegisterForNavigation<AccountPage, AccountPageViewModel>();
        }
    }
}
