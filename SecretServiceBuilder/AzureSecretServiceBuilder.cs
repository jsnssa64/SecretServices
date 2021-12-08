using Microsoft.Extensions.Configuration;
using SecretServices;
using SecretServices.CredentialsModel;
using SecretServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices.SecretServiceBuilder
{
    public abstract class AzureSecretServiceBuilder : ISecretServiceBuilder
    {
        public const string FilePathType = "Type";

        public string uri { get; }
        public string tenantId { get; }
        public string clientId { get; }

        public AzureSecretServiceBuilder(string Uri, string TenantId, string ClientId)
        {
            string uri = Uri;
            string tenantId = TenantId;
            string clientId = ClientId;
        }
    }

    public class AzureBasicCertificateBuilder : AzureSecretServiceBuilder
    {
        public IBaseSecrets Service { get; }
        public AzureBasicCertificateBuilder(string Uri, string TenantId, string ClientId, string CertPath) : base(Uri, TenantId, ClientId)
        {
            Service = new AzureKeyVaultCertificateService(new AzureCredentialsCertModel(uri, tenantId, clientId, CertPath));
        }
    }

    public class AzureX509CertificateBuilder : AzureSecretServiceBuilder
    {
        public IBaseSecrets Service { get; }
        public AzureX509CertificateBuilder(string Uri, string TenantId, string ClientId, string X509CertPath, string password) : base(Uri, TenantId, ClientId)
        {
            Service = new AzureKeyVaultX509CertificateService(new AzureCredentialsX509CertModel(uri, tenantId, clientId, X509CertPath, password));
        }
    }

    public class AzureClientSecretBuilder : AzureSecretServiceBuilder
    {
        public IBaseSecrets Service { get; }
        public AzureClientSecretBuilder(string Uri, string TenantId, string ClientId, string ClientSecret) : base(Uri, TenantId, ClientId)
        {
            Service = new AzureKeyVaultCSService(new AzureCredentialsCSModel(uri, tenantId, clientId, ClientSecret));
        }
    }
}
