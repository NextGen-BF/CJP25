namespace NextGen_BM_BE_Domain.Entities{

    public class RequestFiles{
        public int RequestFilesId { get; set; }
        public required string FilePath { get; set; }
        public required string RequestType { get; set; }
        public required int RequestId { get; set; }
    }
}