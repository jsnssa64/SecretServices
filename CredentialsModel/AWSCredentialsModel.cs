using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices.CredentialsModel
{
    public class AWSSimpleCredentialsModel : IAWSCredentialModel
    {
        public string profile { get; }
        public string region { get; }
        public AWSSimpleCredentialsModel(string Profile, string Region)
        {
            profile = Profile;
            region = Region;
        }
    }
}
