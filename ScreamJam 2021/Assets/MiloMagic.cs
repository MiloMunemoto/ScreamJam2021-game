using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloMagic : MonoBehaviour
{
    [SerializeField]
    private GameObject magicWindow1A;
    [SerializeField]
    private GameObject magicWindow2A;
    [SerializeField]
    private GameObject magicWindow3A;

    [SerializeField]
    private GameObject magicWindow1B;
    [SerializeField]
    private GameObject magicWindow2B;
    [SerializeField]
    private GameObject magicWindow3B;

    public void DisableWindowA() 
    {
        magicWindow1A.SetActive(false);
        magicWindow2A.SetActive(false);
        magicWindow3A.SetActive(false);
    }

    public void DisableWindowB()
    {
        magicWindow1B.SetActive(false);
        magicWindow2B.SetActive(false);
        magicWindow3B.SetActive(false);
    }

    public void EnableWindowA()
    {
        magicWindow1A.SetActive(true);
        magicWindow2A.SetActive(true);
        magicWindow3A.SetActive(true);
    }
    public void EnableWindowB()
    {
        magicWindow1B.SetActive(true);
        magicWindow2B.SetActive(true);
        magicWindow3B.SetActive(true);
    }
}
