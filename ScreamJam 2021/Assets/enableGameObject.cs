using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject outerbox;
    private void OnTriggerEnter()
    {
        outerbox.SetActive(true);

    }
}
