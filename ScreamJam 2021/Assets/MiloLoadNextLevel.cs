using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiloLoadNextLevel : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        {
            MiloLevelManager.instance.LoadNextLevel();
            Destroy(gameObject);
        }

    }
}

