using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;
using Amazon.SecretsManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices.Services
{
    public class AWSSecretService : IBaseSecrets, IDisposable
    {
        private readonly AmazonSecretsManagerConfig config;
        private readonly IAmazonSecretsManager client;
        private readonly SecretsManagerCache Cache;
        private readonly GetSecretValueRequest request;

        public AWSSecretService(string SecretName, AmazonSecretsManagerConfig Config, AmazonSecretsManagerClient Client, GetSecretValueRequest Request)
        {
            config = Config;
            client = Client;
            request = Request;
            Cache = new SecretsManagerCache(Client);
        }
        public void Dispose()
        {
            client.Dispose();
            Cache.Dispose();
        }

        public string GetValue(string name) => Task.Run(async () => await client.GetSecretValueAsync(request)).Result?.SecretString;
    }
}
