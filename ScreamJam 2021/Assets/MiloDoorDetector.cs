using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloDoorDetector : MonoBehaviour
{
    public bool Door1;
    public bool Door2;

    [SerializeField]
    private MiloAutomaticDoor autoDoor;

    [SerializeField]
    private MiloTriggerScript triggers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Door1) { autoDoor.OpenDoor1(); }
            if (Door2) 
            { 
                autoDoor.OpenDoor2();
                triggers.LockDoors();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Door1) { autoDoor.CloseDoor1(); }
            if (Door2) 
            { 
                autoDoor.CloseDoor2();
            }
        }
    }



}
