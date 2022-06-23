namespace EvDekorasyonu.Application.Features.Queries.ViewModels
{
    public class DekorViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Dekor { get; set; }
        public int Star { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public string DekorCategoryId { get; set; }
        public DekorCategoryViewModel DekorCategory { get; set; }
        public IList<DekorCommentsViewModel> DekorComments { get; set; }
    }
}
