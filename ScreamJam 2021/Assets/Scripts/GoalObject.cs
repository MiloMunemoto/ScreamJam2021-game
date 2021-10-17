using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : MonoBehaviour
{
    public void PickUp()
    {
        InventoryManager.instance.GoalObjectPickedUp(gameObject);
        Destroy(gameObject);
    }
}
