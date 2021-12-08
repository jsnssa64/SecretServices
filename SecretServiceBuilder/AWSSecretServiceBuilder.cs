using Microsoft.Extensions.Configuration;
using SecretServices;
using SecretServices.CredentialsModel;
using SecretServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.SecretsManager;
using System.Threading.Tasks;
using Amazon.Runtime;

namespace SecretServices.SecretServiceBuilder
{
    public class AWSSecretServiceBuilder : ISecretServiceBuilder
    {
        public string profile { get; }
        public string region { get; }
        public AWSSecretServiceBuilder(string Profile, string Region)
        {
            profile = Profile;
            region = Region;
        }

        public IBaseSecrets BuildAWSSecretService()
        {
            throw new NotImplementedException();
            AWSCredentials test = new 

            new AmazonSecretsManagerClient(new AWSCredentials()
            //return new AWSSecretService(new AWSSimpleCredentialsModel(Profile, Region));
        }
    }
}
