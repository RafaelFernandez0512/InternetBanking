using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using IBankingXamarinForms.Helpers;
using IBankingXamarinForms.Models;
using IBankingXamarinForms.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
namespace IBankingXamarinForms.ViewModels
{
    public class HomePageViewModel: BaseViewModel
    {
        public ObservableCollection<ClsAccount> Accounts { get; set; }
        public DelegateCommand LoadListCommand { get; set; }
        private ClsAccount selectAccount;

        public ClsAccount SelectAccount
        {
            get { return selectAccount; }
            set {
                selectAccount = value;
                if (SelectAccount != null) {
                  NavigateToDetail(SelectAccount);
                }
            
            }
        }

        public HomePageViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService dialogService):base(navigationService,apiBanking, dialogService)
        {
            long idcard = 0;
            idcard = idcard.IdCardGet();
            LoadListCommand = new DelegateCommand(async () =>
            {
                
                await GetAccount(40021345678);
            });
            LoadListCommand.Execute();
        }
        async Task NavigateToDetail(ClsAccount clsAccount)
        {
            var param = new NavigationParameters
            {
                { "Account", clsAccount }
            };
            await navigationService.NavigateAsync(new Uri($"{ConfigPage.AccountPage}", UriKind.Relative), param);
        }
        async Task GetAccount(long cedula) {
                var accounts = await apiBanking.GetAccount(cedula);
                Accounts = new ObservableCollection<ClsAccount>(accounts);
        }

    }
}
