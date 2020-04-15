using IBankingXamarinForms.Models;
using IBankingXamarinForms.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace IBankingXamarinForms.ViewModels
{
    public class AccountPageViewModel : BaseViewModel, INavigatedAware
    {
        public ClsAccount Account { get; set; }
        public ObservableCollection<ClsTransaction> Transactions { get; set; }
        public DelegateCommand LoadListCommand { get; set; }
        public AccountPageViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService dialogService) : base(navigationService, apiBanking, dialogService)
        {



        }
        async Task GetTransaction() {
            var trans = await apiBanking.GetTransactionID(Account.IdCuenta);
            Transactions = new ObservableCollection<ClsTransaction>(trans);

        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters["Account"] as ClsAccount;
            if (param !=null)
            {
                Account = param;
                LoadListCommand = new DelegateCommand(async () =>
                {
                    await GetTransaction();
                });
                LoadListCommand.Execute();
            }


        }
    }
}
