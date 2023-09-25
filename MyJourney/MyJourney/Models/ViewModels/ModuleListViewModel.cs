namespace MyJourney.Models.ViewModels
{
    public class ModuleListViewModel
    {
        public IEnumerable<Module> Modules { get; set; }
        public PagingInfoViewModel PagingInfo { get; set; }
    }
}
