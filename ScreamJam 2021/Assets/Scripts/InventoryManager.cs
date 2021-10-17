using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
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

    public void PickUpObject(GameObject goalObject)
    {
        if (shoppingList.Contains(goalObject))
        {
            inventory.Add(goalObject);
            shoppingList.Remove(goalObject);
        }
        else
        {
            Debug.LogError(goalObject + " not in shoppingList");
        }
    }

    public void AddToShoppingList(GameObject goalObject){
        shoppingList.Add(goalObject);
    }
    public void AddToShoppingList(List<GameObject> goalObjects)
    {
        shoppingList.AddRange(goalObjects);
    }
}
