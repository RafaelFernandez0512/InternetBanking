using System;
using System.Collections.Generic;
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
    public class TransactionPageViewModel: BaseViewModel
    {
        public ClsTransaction Transaction { get; set; } = new ClsTransaction();
        public List<ClsAccount> MyAccounts { get; set; }
        private ClsAccount selectAccount;

        public ClsAccount SelectAccount
        {
            get { return selectAccount; }
            set { selectAccount = value;
                if (SelectAccount!=null)
                {
                    Transaction.IdCuentaEmisor = selectAccount.IdCuenta;
                }
            
            }
        }

        public DelegateCommand TransactionCommand { get; set; }
        public TransactionPageViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService dialogService) : base(navigationService, apiBanking, dialogService)
        {
            GetAccount();
            TransactionCommand = new DelegateCommand(async () =>
            {
                await PostTransaction();
            });
        }
        async Task GetAccount()
        {
            long cedula = 0;
            var accounts = await apiBanking.GetAccount(cedula.IdCardGet());
            MyAccounts = new List<ClsAccount>(accounts);
        }
        async Task PostTransaction()
        {
            try
            {
                Transaction.TipoTransaccion = "Deposito";
                if (Transaction.IdCuentaEmisor!=0&& Transaction.IdCuentaReceptor != 0)
                {
                    await apiBanking.PostTransaction(Transaction);
                    await navigationService.GoBackAsync();
                }

            }
            catch (Exception)
            {
                await DialogService.DisplayAlertAsync("Llene todos lo campos", "Campos vacios", "ok");
            }

        }
    }
}
