namespace GM.Core.Application.Contracts.GuideAgg
{
    public class GuideVm
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreationDate { get; set; }
        public long GuideCategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsRemoved { get; set; }
    }
}
