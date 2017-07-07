using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.Runtime;
using Amazon.S3.Model;
using System.IO;
namespace Classes
{
    public class s3
    {
        static string existingBucketName = "BUCKET NAME/FOLDER";
        static string keyName = "*** Provide your object key ";
        static string filePath = " Provide file name ***";
        string iamUserAccessKey = "";
        string iamUserSecretKey = "";

        public s3(string iamUserAccessKey, string iamUserSecretKey)
        {
            this.iamUserAccessKey = iamUserAccessKey;
            this.iamUserSecretKey = iamUserSecretKey;
        }
        public string upload(string path)
        {
            try
            {
                filePath = path;
                BasicAWSCredentials awsCreds = new BasicAWSCredentials(this.iamUserAccessKey, this.iamUserSecretKey);
                AmazonS3Client client = new AmazonS3Client(awsCreds, Amazon.RegionEndpoint.USEast1);
                TransferUtility fileTransferUtility = new TransferUtility(client);
                fileTransferUtility.Upload(filePath, existingBucketName);
                return "File successfully uploaded";
            } catch(Exception ex)
            {
                return "Error while uploading file: " + ex;
            }
            

        }
    }
}
