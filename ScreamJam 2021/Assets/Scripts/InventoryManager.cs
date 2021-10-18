using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PickUpEvent : UnityEvent<List<GameObject>>{}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public PickUpEvent shoppingListUpdated = new PickUpEvent();
    public PickUpEvent inventoryUpdated = new PickUpEvent();

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        if (instance == null)
            instance = this;
    }


    private List<GameObject> inventory = new List<GameObject>();
    private List<GameObject> shoppingList = new List<GameObject>();

    public List<GameObject> GetShoppingList()
    {
        return shoppingList;
    }

    public void GoalObjectPickedUp(GameObject goalObject)
    {
        if (shoppingList.Contains(goalObject))
        {
            inventory.Add(goalObject);
            shoppingList.Remove(goalObject);

            inventoryUpdated.Invoke(inventory);
            shoppingListUpdated.Invoke(shoppingList);
        }
        else
        {
            Debug.LogError(goalObject + " not in shoppingList");
        }
    }

    public void AddToShoppingList(GameObject goalObject){
        shoppingList.Add(goalObject);
        shoppingListUpdated.Invoke(shoppingList);
    }
}
