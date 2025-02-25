using Microsoft.AspNetCore.Http;

public interface IDocumentService
{
    Task<List<IFormFile>> GetDocumentsByRequestId();
    Task<List<string>> UploadDocuments(IList<IFormFile> files, int requestId, string requestType);
}