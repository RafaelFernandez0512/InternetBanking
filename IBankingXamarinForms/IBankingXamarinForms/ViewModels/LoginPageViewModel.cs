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
        public ClsUser User { get; set; } = new ClsUser();
        public DelegateCommand ButtonEyeClickedCommand { get; set; }
        public DelegateCommand SignOutCommand    { get; set; }
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
            SignOutCommand = new DelegateCommand(async() => {

                if (!string.IsNullOrEmpty(User.Username)&&!string.IsNullOrEmpty(User.Password))
                {
                    await ValidateUser();
                }
            });
        }
        void VisiblePassWord()
        {
            ImageModel = !IsVisible ? "eyeW.png" : "eyeW_off.png";
            IsVisible = !IsVisible;
        }

        async Task ValidateUser()
        {
            try
            {
                var user = await apiBanking.ValidateLogin(User.Username,User.Password);
            if (user != null)
                {
                    User = user;
                    user.IdCard = user.IdCard.IdCardSave();
                    await navigationService.NavigateAsync($"{ConfigPage.MenuTabbedPage}");
                }
                else
                {
                    await DialogService.DisplayAlertAsync("incorrecta", "contraseña/user incorrecto", "ok");
                }
            }
            catch (Exception)
            {
                await DialogService.DisplayAlertAsync("incorrecta", "contraseña/user incorrecto", "ok");
            }
        }
        }

  }

