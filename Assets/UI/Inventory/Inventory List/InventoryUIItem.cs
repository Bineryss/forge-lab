using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Inventory
{
    [UxmlElement]
    public partial class InventoryUIElement : VisualElement
    {
        private readonly Button container;
        private readonly Image iconElement;
        private readonly Label labelElement;

        private Sprite background;
        [UxmlAttribute]
        public Sprite Background
        {
            get => background; set
            {
                if (value == null || value.Equals(background)) return;
                background = value;
                Refresh();
            }
        }

        private Sprite icon;
        [UxmlAttribute]
        public Sprite Icon
        {
            get => icon; set
            {
                if (value == null || value.Equals(icon)) return;
                icon = value;
                Refresh();
            }
        }

        private int quantity;
        [UxmlAttribute]
        public int Quantity
        {
            get => quantity; set
            {
                if (value == quantity) return;
                quantity = value;
                Refresh();
            }
        }

        public InventoryUIElement()
        {
            container = new();
            container.AddToClassList("inventory-item-container");
            container.AddToClassList("button");
            container.AddToClassList("button-reset");
            Add(container);

            iconElement = new();
            iconElement.AddToClassList("inventory-item-icon");
            container.Add(iconElement);

            VisualElement counterContainer = new();
            counterContainer.AddToClassList("inventory-item-counter-container");
            container.Add(counterContainer);
            labelElement = new Label()
            {
                text = "#000"
            };
            labelElement.AddToClassList("inventory-item-counter");
            counterContainer.Add(labelElement);

        }

        public void RegisterCallback(EventCallback<ClickEvent> callback)
        {
            if (callback != null)
            {
                container.RegisterCallback(callback);
                //TODO add cleanup for unregistering the callbacks
            }
        }

        private void Refresh()
        {
            container.style.backgroundImage = new StyleBackground(background);
            iconElement.sprite = icon;
            labelElement.text = quantity.ToString();
        }
    }
}