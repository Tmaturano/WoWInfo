using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WoWInfo.Authentication
{
    public interface IAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client">CLient específico de cada plataforma</param>
        /// <param name="provider"></param>
        /// <param name="parameters">parâmetros adicionais que podem ser enviados pelo login</param>
        /// <returns></returns>
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null);
    }
}
