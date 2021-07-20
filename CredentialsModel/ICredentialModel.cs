using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices.CredentialsModel
{
    public interface ICredentialModel
    {
    }

    public interface IAzureCredentialModel : ICredentialModel
    {
        public string azureUri { get; }
        public string tenantId { get; }
    }

    public interface IAWSCredentialModel : ICredentialModel
    {

    }
}
