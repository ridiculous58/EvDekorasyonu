namespace EvDekorasyonu.MVC.Models
{
    public class LayoutUrlViewModel
    {
        public LayoutUrlViewModel()
        {
            UrlViewModels = new List<UrlViewModel>();
        }
        public IList<UrlViewModel> UrlViewModels { get; set; }
    }

    public class UrlViewModel
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public string IconName { get; set; }
    }
}