using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerGumballMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject _eyeball;
    private void OnTriggerEnter()
    {
        {
            _eyeball.SetActive(true);
            Destroy(gameObject);
        }
    }

}
