using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Inventory
{

    [UxmlElement]
    public partial class TagElement : VisualElement
    {
        private readonly VisualElement container;
        private readonly Label label;

        private string _label;
        [UxmlAttribute]
        public string Label
        {
            get => _label; set
            {
                _label = value;
                Refresh();
            }
        }
        private Color color;
        [UxmlAttribute]
        public Color Color
        {
            get => color;
            set
            {
                color = value;
                Refresh();
            }
        }

        public TagData Data
        {
            get => new()
            {
                Label = _label,
                Color = color
            };
            set
            {
                _label = value.Label;
                color = value.Color;
                Refresh();
            }
        }

        public TagElement()
        {
            container = new VisualElement();
            container.AddToClassList("tag-body");
            Add(container);

            label = new Label();
            label.AddToClassList("tag-text");
            container.Add(label);

            Refresh();
        }

        private void Refresh()
        {
            label.text = Label;

            Color bgColor = color;
            bgColor.a = 0.4f;
            Color borderColor = color;
            borderColor.a = 1f;

            container.style.backgroundColor = bgColor;
            container.style.borderBottomColor = borderColor;
            container.style.borderTopColor = borderColor;
            container.style.borderLeftColor = borderColor;
            container.style.borderRightColor = borderColor;
        }
    }

    [System.Serializable, UxmlObject]
    public partial class TagData
    {
        [UxmlAttribute] public string Label;
        [UxmlAttribute] public Color Color;
    }
}