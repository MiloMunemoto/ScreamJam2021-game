using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObject : Interactable
{
    [SerializeField] private GameObject meshObject;

    void Start()
    {
        InventoryManager.instance.AddToShoppingList(gameObject);
    }
    public override void Unhighlight()
    {
        base.Unhighlight();
        meshObject.transform.localScale = Vector3.one;
    }

    void Update()
    {
        if (highlighted)
        {
            meshObject.transform.localScale = Vector3.one * (1f + Mathf.Sin(Time.time*3f)/9f);
        }
    }

    public void PickUp()
    {
        InventoryManager.instance.GoalObjectPickedUp(gameObject);
        Destroy(gameObject);
    }

    public override void Interact()
    {
        PickUp();
    }
}
