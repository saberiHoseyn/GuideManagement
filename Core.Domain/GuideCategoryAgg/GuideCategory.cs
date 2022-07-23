using Framework.Domain;
using GM.Core.Domain.GuideAgg;
using System.Collections.Generic;

namespace GM.Core.Domain.GuideCategoryAgg
{
    public class GuideCategory : EntityBase
    {
        public string Name { get; private set; }
        public bool IsRemoved { get; private set; } = false;
        public List<Guide> Guides { get; private set; } = new List<Guide>();

        public GuideCategory(string name)
        {
            Name = name;
        }

        public void Edit(string name)
        {
            Name = name;
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
