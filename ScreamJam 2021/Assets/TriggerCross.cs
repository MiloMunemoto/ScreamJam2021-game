using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCross : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    private bool spun;
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter()
    {
        if (!spun)
        {
            _anim.Play("crossspin");
            FindObjectOfType<InventoryManager>().UnlockFinalDoor();
            spun = true;
        }
       
    }
}
