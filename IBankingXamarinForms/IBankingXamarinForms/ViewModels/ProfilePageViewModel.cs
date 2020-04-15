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
    public class ProfilePageViewModel: BaseViewModel
    {
        public ClsClient User { get; set; }
        public DelegateCommand LoadUserCommad { get; set; }
        public DelegateCommand TransactionCommand { get; set; }
        
        public ProfilePageViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService dialogService) : base(navigationService, apiBanking, dialogService)
        {
            LoadUserCommad = new DelegateCommand(async () =>
            {
                await FindUser();
            });
            LoadUserCommad.Execute();
            TransactionCommand = new DelegateCommand(async () =>
            {

                await navigationService.NavigateAsync(new Uri($"{ConfigPage.NavigationPage}{ConfigPage.TransactionPage}", UriKind.Relative));
            });
        }
        async Task FindUser()
        {
            long id =0;
            var user = await apiBanking.GetClient(id.IdCardGet());
            User = user;
        }
    }
}
