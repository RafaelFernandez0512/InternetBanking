using IBankingXamarinForms.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBankingXamarinForms.ViewModels
{
    public class BaseViewModel
    {
        protected INavigationService navigationService;
        protected IApiBanking apiBanking;
        protected IPageDialogService DialogService;

        public BaseViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService DialogService )
        {
            this.navigationService = navigationService;
            this.apiBanking = apiBanking;
            this.DialogService = DialogService;
        }
    }
}
