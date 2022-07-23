using System;

namespace Framework.Dtos
{
    public class GuideDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public long GuideCategoryId { get; set; }
        public string GuideCategoryName { get; set; }
        public bool IsRemoved { get; set; }
    }
}