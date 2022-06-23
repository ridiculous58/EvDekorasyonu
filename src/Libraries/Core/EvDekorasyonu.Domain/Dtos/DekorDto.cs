namespace EvDekorasyonu.Domain.Dtos
{
    public class DekorDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dekor { get; set; }
        public int Star { get; set; }
        public string ImageUrl { get; set; }
        public string DekorCategoryId { get; set; }
        public bool IsActive { get; set; }
    }


}
