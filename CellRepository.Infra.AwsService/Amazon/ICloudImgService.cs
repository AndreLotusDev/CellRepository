using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.AwsService.Amazon
{
    public interface ICloudImgService
    {
        void Start(string acess, string secret);
        Task<(string message, bool status, string idImage)> PerformASave(byte[] imgsBytes);
    }
}
