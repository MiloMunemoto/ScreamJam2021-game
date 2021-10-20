using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextStageTirgger : MonoBehaviour
{
    private void OnTriggerEnter()
    {       
        {
            StageManager.instance.LoadNextStage();
            Destroy(gameObject);
        }
       
    }
}
