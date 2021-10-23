using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PickUpEvent : UnityEvent<List<GameObject>>{}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField]
    private MiloTriggerScript unlocklevel;

    public PickUpEvent shoppingListUpdated = new PickUpEvent();
    public PickUpEvent inventoryUpdated = new PickUpEvent();
    private AudioManager _audioManager;

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        if (instance == null)
            instance = this;

        _audioManager = FindObjectOfType<AudioManager>();
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

            
            _audioManager.Play("pickupitem");

            inventoryUpdated.Invoke(inventory);
            shoppingListUpdated.Invoke(shoppingList);

            CheckIfListisEmpty();
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

    public void CheckWinCondition()
    {
        if (shoppingList.Count == 0)
        {
            Debug.Log("Last stage loaded with no items in shopping list, game won");
        }
        else
        {
            Debug.Log("Last stage loaded with items in shopping list, game lost");
        }
    }

    public void CheckIfListisEmpty() 
    {
        if (shoppingList.Count.Equals(0))
        { 
            Debug.Log("List is empty");
            unlocklevel.UnlockDoors();
        }
        
        //string number = shoppingList.Count.ToString();
        //Debug.Log(number);
    }

    public void UnlockFinalDoor() 
    {
        unlocklevel.UnlockDoors();
    }
}
