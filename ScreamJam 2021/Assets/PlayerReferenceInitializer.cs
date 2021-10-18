using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceInitializer : MonoBehaviour
{
    void Start()
    {
        ReferenceManager.instance.player = gameObject;
    }
}
