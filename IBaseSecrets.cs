using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices
{
    public interface IBaseSecrets
    {
        public string GetSecretValue(string key);
    }
}
