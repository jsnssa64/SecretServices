using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretServices.Services
{
    public interface IBaseSecrets
    {
        public string GetValue(string key);
    }
}
