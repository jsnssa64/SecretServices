using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices.CredentialsModel
{
    public abstract class AzureCredentialsBaseModel : IAzureCredentialModel
    {
        public string azureUri { get; }
        public string tenantId { get; }
        public string clientId { get; }

        public AzureCredentialsBaseModel(string AzureUri, string TenantId, string ClientId)
        {
            azureUri = AzureUri;
            tenantId = TenantId;
            clientId = ClientId;
        }
    }

    public class AzureCredentialsCSModel : AzureCredentialsBaseModel
    {
        public string clientSecret { get; }
        public AzureCredentialsCSModel(string AzureUri, string TenantId, string ClientId, string ClientSecret) : base(AzureUri, TenantId, ClientId)
        {
            clientSecret = ClientSecret;
        }
    }

    public class AzureCredentialsCertModel : AzureCredentialsBaseModel
    {
        public string CertificatePath { get; }

        public AzureCredentialsCertModel(string AzureUri, string TenantId, string ClientId, string certificatePath) : base(AzureUri, TenantId, ClientId)
        {
            CertificatePath = certificatePath;
        }
    }

    
    public class AzureCredentialsX509CertModel : AzureCredentialsBaseModel
    {
        public X509Certificate2 Certificate { get; }

        public AzureCredentialsX509CertModel(string AzureUri, string TenantId, string ClientId, string certificatePath, string Password) : base(AzureUri, TenantId, ClientId)
        {
            X509Certificate2 X509 = new X509Certificate2(certificatePath, Password);
            Certificate = X509;
        }
    }
}
