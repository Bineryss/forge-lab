using System.Collections.Generic;
using UnityEngine.UIElements;

namespace UI.Inventory
{
    [UxmlElement]
    public partial class TagList : VisualElement
    {
        private readonly VisualElement container;
        private readonly List<TagElement> pool = new();


        private List<TagData> tags;

        [UxmlObjectReference]
        public List<TagData> Tags
        {
            get => tags;
            set
            {
                tags = value ?? new();
                Refresh();
            }
        }

        public TagList()
        {
            container = new VisualElement();
            container.AddToClassList("tag-list-container");
            Add(container);
            Refresh();
        }


        private void Refresh()
        {
            if (tags == null) return;
            while (pool.Count < tags.Count)
            {
                TagElement tagElement = new();
                pool.Add(tagElement);
                container.Add(tagElement);
            }

            for (int i = 0; i < pool.Count; i++)
            {
                TagElement element = pool[i];
                if (i < tags.Count)
                {
                    TagData data = tags[i];
                    element.Data = data;
                    element.style.display = DisplayStyle.Flex;
                }
                else
                {
                    element.style.display = DisplayStyle.None;
                }
            }
        }
    }

}