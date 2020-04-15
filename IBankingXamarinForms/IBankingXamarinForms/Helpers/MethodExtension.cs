using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace IBankingXamarinForms.Helpers
{
    public static class MethodExtension
    {
        public static long IdCardSave(this long idCard) {
            Preferences.Set("Id", idCard);
            return idCard;
        }
        public static long IdCardGet(this long idCard)
        {
            return Preferences.Get("Id", idCard); ;
        }
    }
}
