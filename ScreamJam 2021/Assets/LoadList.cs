using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadList : MonoBehaviour
{
    public bool List2;
    public bool List3;

    private void Start()
    {
        if(List2) FindObjectOfType<ListManager>().EnableList2();

        if(List3) FindObjectOfType<ListManager>().EnableList3();
    }
}
