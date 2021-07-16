using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Shared
{
    public class ConfigJson
    {
        public ConfigJson(string encryptString, string secretKey)
        {
            EncriptString = encryptString;
            SecretKey = secretKey;
        }

        public string EncriptString { get; init; }
        public string SecretKey { get; init; }
    }
}
