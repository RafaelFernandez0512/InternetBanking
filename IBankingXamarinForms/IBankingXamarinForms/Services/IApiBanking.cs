using IBankingXamarinForms.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IBankingXamarinForms.Services
{
    public interface IApiBanking
    {
        [Post("/api/CoreTransaction")]
        Task PostTransaction([Body]ClsTransaction Transaction); 
        [Get("/api/CoreTransaction")]
        Task<List<ClsTransaction>> GetTransaction();
        [Get("/api/CoreTransaction?idCuenta={idCuenta}")]
        Task<List<ClsTransaction>> GetTransactionID(int idCuenta);
        [Get("/api/CoreClient?cedula={idCard}")]
        Task<ClsClient> GetClient(long idCard);
        [Get("/api/CoreUser?username={username}&password={password}")]
        Task<ClsUser> ValidateLogin(string username,string password);
        [Get("/api/CoreAccount?cedula={cedula}")]
        Task<List<ClsAccount>> GetAccount(long cedula);
     


    }
}
