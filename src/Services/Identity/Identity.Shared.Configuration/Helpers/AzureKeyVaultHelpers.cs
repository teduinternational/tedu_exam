// Original file comes from: https://github.com/damienbod/IdentityServer4AspNetCoreIdentityTemplate
// Modified by Jan Škoruba

using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Identity.Shared.Configuration.Configuration.Common;
using Identity.Shared.Configuration.Services;

namespace Identity.Shared.Configuration.Helpers
{
    public class AzureKeyVaultHelpers
    {
        public static async Task<(X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate)> GetCertificates(AzureKeyVaultConfiguration certificateConfiguration)
        {
            (X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate) certs = (null, null);

            if (!string.IsNullOrEmpty(certificateConfiguration.AzureKeyVaultEndpoint))
            {
                var keyVaultCertificateService = new AzureKeyVaultService(certificateConfiguration);

                certs = await keyVaultCertificateService.GetCertificatesFromKeyVault().ConfigureAwait(false);
            }

            return certs;
        }
    }
}