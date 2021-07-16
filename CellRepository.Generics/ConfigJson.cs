using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Shared
{
    public class ConfigJson
    {
        public ConfigJson(string encryptString)
        {
            EncriptString = encryptString;
        }

        public string EncriptString { get; init; }
    }
}
