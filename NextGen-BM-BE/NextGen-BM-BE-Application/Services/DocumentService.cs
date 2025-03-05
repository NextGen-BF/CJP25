using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

public class DocumentService : IDocumentService
{

    private readonly IConfiguration _config;
    private readonly IAmazonS3 _s3Client;
    public DocumentService(IConfiguration configuration, IAmazonS3 amazonS3)
    {
        _config = configuration;
        _s3Client = amazonS3;
    }

    public Task<List<IFormFile>> GetDocumentsByRequestId(int requestId, string requestType)
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> UploadDocuments(IList<IFormFile> files, int requestId, string requestType)
    {
        try
        {
            var bucketName = _config.GetValue<string>("AWS:BucketName");
            var region = _config.GetValue<string>("AWS:Region");
            var accessKey = _config.GetValue<string>("AWS:AccessKey");
            var secretKey = _config.GetValue<string>("AWS:SecretKey");
            using var s3Client = new AmazonS3Client(accessKey, secretKey, Amazon.RegionEndpoint.GetBySystemName(region));
            var checkIfBucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(s3Client, bucketName);
            if (!checkIfBucketExists) throw new Exception($"Connection to S3 bucket could not be made. Bucket with name {bucketName} doesn't exist");
            var filePaths = new List<string>();
            foreach (var file in files)
            {
                var request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = "Hidden_Resources/" + file.FileName + "_" + requestId,
                    InputStream = file.OpenReadStream()
                };
                request.Metadata.Add("Content-Type", file.ContentType);
                await _s3Client.PutObjectAsync(request);
                filePaths.Add(request.Key);
            }
            //await UploadFilePaths(requestId, filePaths, requestType);
            return filePaths;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not upload files. Threw an error of: " + ex.Message);
        }
    }

    private Task UploadFilePaths(int requestId, IList<string> filePaths, string requestType)
    {

        return null;
    }
}