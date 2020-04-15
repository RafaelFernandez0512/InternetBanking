using System;
using System.Collections.Generic;
using System.Text;
using IBankingXamarinForms.Services;
using Prism.Navigation;
using Prism.Services;

namespace IBankingXamarinForms.ViewModels
{
    public class RegisterTransactionPageViewModel: BaseViewModel
    {
        public RegisterTransactionPageViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService dialogService) : base(navigationService, apiBanking, dialogService)
        {

        }
    }
}
