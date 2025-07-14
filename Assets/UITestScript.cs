using System.Collections.Generic;
using Core.Item;
using UI.Inventory;
using UnityEngine;
using UnityEngine.UIElements;


[System.Serializable]
public struct TestValue
{
    public int quantity;
    public Sprite background;
    public Sprite icon;
}
public class UITestScript : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private StyleSheet styles;
    [SerializeField] private List<TagData> tags = new();
    [SerializeField] private List<TestValue> items = new();



    private TagList list;
    void Start()
    {
        Generate();
    }

    void OnValidate()
    {
        if (Application.isPlaying) return;
        Generate();
    }

    private void Generate()
    {
        VisualElement root = document.rootVisualElement;
        root.Clear();
        root.styleSheets.Add(styles);

        ListView listView = new();
        listView.makeItem = () => new InventoryUIElement();
        listView.bindItem = (element, index) =>
        {
            var item = items[index];  // e.g., List<InventoryItemData>
            var uiElement = (InventoryUIElement)element;
            uiElement.Background = item.background;  // Bind to data
            uiElement.Icon = item.icon;  // Bind to data
            uiElement.Quantity = item.quantity;  // Bind to data
        };
        listView.itemsSource = items;
        listView.fixedItemHeight = 100;

        root.Add(listView);
    }

    // void Update()
    // {
    //     list.Tags = tags;
    // }

}
