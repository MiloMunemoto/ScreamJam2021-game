using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    public static ReferenceManager instance;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        if (instance == null)
            instance = this;
    }

    public GameObject player;
}
