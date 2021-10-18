using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListDisplay : MonoBehaviour
{
    [SerializeField] private Text shoppingListtextField;
    [SerializeField] private Text pickedUpItemsTextField;

    void Start()
    {
        InventoryManager.instance.shoppingListUpdated.AddListener(UpdateList);
        InventoryManager.instance.inventoryUpdated.AddListener(UpdatePickedUp);
        shoppingListtextField.text = "Shopping list\n";
        pickedUpItemsTextField.text = "Picked up items\n";
    }

    void UpdateList(List<GameObject> objects)
    {
        shoppingListtextField.text = "Shopping list\n";
        foreach (var obj in objects)
        {
            shoppingListtextField.text += obj.name + '\n';
        }
    }

    void UpdatePickedUp(List<GameObject> objects)
    {
        pickedUpItemsTextField.text = "Picked up items\n";
        foreach (var obj in objects)
        {
            pickedUpItemsTextField.text += obj.name + '\n';
        }
    }
}
