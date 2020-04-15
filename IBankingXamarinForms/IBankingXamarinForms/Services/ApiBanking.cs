using IBankingXamarinForms.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBankingXamarinForms.Services
{
    public class ApiBanking : IApiBanking
    {
        public async Task<List<ClsAccount>> GetAccount(long cedula)
        {
            var getRequest = RestService.For<IApiBanking>(ConfigApi.UrlApi);
            var accounts = await getRequest.GetAccount(cedula);
            return accounts;
        }

        public async Task<ClsClient> GetClient(long idCard)
        {
            var getRequest = RestService.For<IApiBanking>(ConfigApi.UrlApi);
            var client = await getRequest.GetClient(idCard);
            return client;
        }

        public async Task<List<ClsTransaction>> GetTransaction()
        {
            var getRequest = RestService.For<IApiBanking>(ConfigApi.UrlApi);
            var trans = await getRequest.GetTransaction();
            return trans;
        }

        public async Task<List<ClsTransaction>> GetTransaction(int account)
        {
            var getRequest = RestService.For<IApiBanking>(ConfigApi.UrlApi);
            var trans =  await getRequest.GetTransaction(account);
            return trans;
        }

        public async Task<ClsUser> ValidateLogin(string username, string password)
        {
            var getRequest = RestService.For<IApiBanking>(ConfigApi.UrlApi);
            var user = await getRequest.ValidateLogin(username, password);
            return user;
        }

        public async Task PostTransaction([Body] ClsTransaction Transaction)
        {
            var getRequest = RestService.For<IApiBanking>(ConfigApi.UrlApi);
            await getRequest.PostTransaction(Transaction);
        }
    }
}
