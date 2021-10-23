using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloDisableMagic : MonoBehaviour
{
    [SerializeField]
    private MiloMagic magic;
    [SerializeField]
    private bool disableA;
    [SerializeField]
    private bool disableB;
    [SerializeField]
    private bool enableA;
    [SerializeField]
    private bool enableB;
    [SerializeField]
    private bool checkList;

    [SerializeField]
    private GameObject trigger;


    private void OnTriggerEnter()
    {
        if (checkList) 
        {
            FindObjectOfType<InventoryManager>().CheckIfListisEmpty();
        }
        if (disableA)
        { 
            magic.DisableWindowA();
            trigger.SetActive(true);
            MiloLevelManager.instance.UnloadLastScene();
            
        }
        else if (disableB)
        {
            magic.DisableWindowB();
            trigger.SetActive(true);
            MiloLevelManager.instance.UnloadLastScene();
        }
        else if (enableB)
        {
            magic.EnableWindowB();
            gameObject.SetActive(false);
        }
        else if (enableA)
        {
            magic.EnableWindowA();
            gameObject.SetActive(false);
        }
    }


}
