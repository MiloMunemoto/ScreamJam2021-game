using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    [SerializeField]
    private GameObject List1;
    [SerializeField]
    private GameObject List2;
    [SerializeField]
    private GameObject List3;

    [SerializeField]
    private Eyeball_grow growItemEyeball;
    

    //ENABLE
    public void EnableList2()
    {
        List2.SetActive(true);
    }
    public void EnableList3()
    {
        List3.SetActive(true);
    }

    //DISABLE
    public void DisableList1() 
    {
        List1.SetActive(false);
    }
    public void DisableList2()
    {
        List2.SetActive(false);
    }
    public void DisableList3()
    {
        List3.SetActive(false);
    }

    public void ScaleItemEyeball() 
    {
        Debug.Log("sclaing eyeball");
        growItemEyeball.StartGrowning();
    }
}
