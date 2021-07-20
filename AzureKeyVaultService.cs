using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using StreamServer.Storage.CredentialsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices
{
    public abstract class AzureKeyVaultBaseService : IBaseSecrets
    {
        //  Default options
        //  TEMPORARY : Possibly putting in appsettings and converting into Class in constructor.
        public SecretClientOptions options = new SecretClientOptions()
        {
            Retry =
            {
                Delay = TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
            },
        };

        public SecretClient secretClient { get; set; }

        public KeyVaultSecret CallGetSecret(string key) => secretClient.GetSecretAsync(key).Result.Value;

        public virtual string GetSecretValue(string key) => CallGetSecret(key).Value;
    }

    public interface IAzureCertificateService
    {
        public ClientCertificateCredential CCC { get; }
    }

    public interface IAzureClientSecretService
    {
        public ClientSecretCredential CSC { get; }
    }

    public class AzureKeyVaultCertificateService : AzureKeyVaultBaseService, IAzureCertificateService
    {
        public AzureCredentialsCertModel AzKeyCert { get; }
        public ClientCertificateCredential CCC { get; }

        public AzureKeyVaultCertificateService(IAzureCredentialModel AzureCredentials)
        {
            AzKeyCert = (AzureCredentialsCertModel)AzureCredentials;
            CCC = new ClientCertificateCredential(AzureCredentials.tenantId, AzKeyCert.clientId, AzKeyCert.CertificatePath);
            secretClient = new SecretClient(new Uri(AzKeyCert.azureUri), CCC, options);
        }

    }

    public class AzureKeyVaultX509CertificateService : AzureKeyVaultBaseService, IAzureCertificateService
    {
        public AzureCredentialsX509CertModel AzKeyX509Cert { get; }

        public ClientCertificateCredential CCC { get; }

        public AzureKeyVaultX509CertificateService(IAzureCredentialModel AzureCredentials)
        {
            AzKeyX509Cert = (AzureCredentialsX509CertModel)AzureCredentials;
            CCC = new ClientCertificateCredential(AzureCredentials.tenantId, AzKeyX509Cert.clientId, AzKeyX509Cert.Certificate);
            secretClient = new SecretClient(new Uri(AzKeyX509Cert.azureUri), CCC, options);
        }
    }

    public class AzureKeyVaultCSService : AzureKeyVaultBaseService, IAzureClientSecretService
    {
        public AzureCredentialsCSModel azureCredentialsCS { get; }

        public ClientSecretCredential CSC { get; }

        public AzureKeyVaultCSService(IAzureCredentialModel AzureCredentials)
        {
            azureCredentialsCS = (AzureCredentialsCSModel)AzureCredentials;
            CSC = new ClientSecretCredential(azureCredentialsCS.tenantId, azureCredentialsCS.clientId, azureCredentialsCS.clientSecret);
            secretClient = new SecretClient(new Uri(azureCredentialsCS.azureUri), CSC, options);
        }
    }
}
