namespace NextGen_BM_BE_Domain.Entities
{
    public class Enums
    {
        public int EnumsId { get; set; }
        public required string Description { get; set; }
        public required string Title { get; set; }
        public required string Type { get; set; }
        public int Value { get; set; }
        public DateOnly DeletedDate { get; set; }
    }
};
