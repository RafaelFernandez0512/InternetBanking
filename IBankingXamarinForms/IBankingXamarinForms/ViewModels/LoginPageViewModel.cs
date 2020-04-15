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
using Prism.Services.Dialogs;
using Xamarin.Forms;

namespace IBankingXamarinForms.ViewModels
{
    public class LoginPageViewModel: BaseViewModel
    {
        public ClsUser User { get; set; }
        public DelegateCommand ButtonEyeClickedCommand { get; set; }
        public ImageSource ImageModel { get; set; }
        public bool IsVisible { get; set; }
        private bool isEnable;
        public bool IsEnable
        {
            get
            {

                return isEnable;


            }
            set
            {
                isEnable = value;

            }
        }
        public LoginPageViewModel(INavigationService navigationService, IApiBanking apiBanking, IPageDialogService dialogService) : base(navigationService, apiBanking, dialogService)
        {
           
            IsVisible = true;
            ImageModel = "eyeW.png";

            ButtonEyeClickedCommand = new DelegateCommand(() => {

                VisiblePassWord();
            });
        }
        void VisiblePassWord()
        {
            ImageModel = !IsVisible ? "eyeW.png" : "eyeW_off.png";
            IsVisible = !IsVisible;
        }

        //async Task ValidateUser()
        //{
        //    try
        //    {
        //        var user = await ApiBanking.ValidateLogin();
        //        if (user != null)
        //        {
        //            if (IsEnable)
        //            {
                       
        //            }
        //            User = user;
        //            var param = new NavigationParameters
        //            {
        //            { $"{nameof(User)}", user }
        //            };
        //            await navigationService.NavigateAsync($"{ConfigPage.MenuTabbedPage}", param);
        //        }
        //        else
        //        {
        //            await DialogService.DisplayAlertAsync("incorrecta", "contraseña/user incorrecto", "ok");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        await DialogService.DisplayAlertAsync("incorrecta", "contraseña/user incorrecto", "ok");
        //    }
        //}
    }
}
