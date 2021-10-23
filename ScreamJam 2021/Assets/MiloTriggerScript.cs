using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloTriggerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Exit1;
    [SerializeField]
    private GameObject Exit2;

    private Collider Exit1Collider;
    private Collider Exit2Collider;

    private void Start()
    {
        Exit1Collider = Exit1.GetComponent<Collider>();
        Exit2Collider = Exit2.GetComponent<Collider>();
    }
    public void UnlockDoors() 
    {
        Debug.Log("unlocked doors");
        Exit1Collider.enabled = true;
        Exit2Collider.enabled = true;
    }

    public void LockDoors()
    {
        Exit1Collider.enabled = false;
        Exit2Collider.enabled = false;
    }
}
