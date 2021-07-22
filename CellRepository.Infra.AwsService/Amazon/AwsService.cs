using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SimpleNotificationService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.Infra.AwsService.Amazon
{
    public class AwsService : ICloudImgService
    {
        private AmazonS3Client Client { get; set; }

        public void Start(string acess, string secret)
        {
            var awsCredentials = new BasicAWSCredentials(acess, secret);
            var client = new AmazonS3Client(awsCreden‌​tials, RegionEndpoint.USEast2);

            Client = client;
        }

        public async Task<(string message, bool status, string idImage)> PerformASave(byte[] imgsBytes)
        {
            CheckIfTheClientIsAuthenticated();

            Stream imgStream = new MemoryStream(imgsBytes);

            var objectInformations = new PutObjectRequest()
            {
                BucketName = "smartphone-storage",
                ContentType = "image/jpeg",
                InputStream = imgStream,
                Key = Guid.NewGuid().ToString()
            };

            var response = await Client.PutObjectAsync(objectInformations);

            var message = response.HttpStatusCode.ToString();
            var idImage = response.VersionId; 
            var status = true;

            return (message, status, idImage);
        }

        public void CheckIfTheClientIsAuthenticated()
        {
            if (Client is null)
            {
                throw new ArgumentNullException(nameof(Client) + " is null");
            }
        }
    }
}
