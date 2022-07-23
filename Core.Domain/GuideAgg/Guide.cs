using Framework.Domain;
using GM.Core.Domain.GuideCategoryAgg;

namespace GM.Core.Domain.GuideAgg
{
    public class Guide : EntityBase
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public long GuideCategoryId { get; private set; }
        public GuideCategory GuideCategory { get; private set; }
        public bool IsRemoved { get; private set; } = false;



        public Guide(string title, string content, long guideCategoryId)
        {
            Title = title;
            Content = content;
            GuideCategoryId = guideCategoryId;
        }

        public void Edit(string title, string content, long guideCategoryId)
        {
            Title = title;
            Content = content;
            GuideCategoryId = guideCategoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restor()
        {
            IsRemoved = false;
        }
    }
}
