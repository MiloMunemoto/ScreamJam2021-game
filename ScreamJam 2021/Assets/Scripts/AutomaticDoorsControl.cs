using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorsControl : MonoBehaviour
{
    private GameObject player;
    public GameObject firstWall;
    public GameObject secondWall;
    public Door firstDoor;
    public Door secondDoor;
    public bool inAirlock = false;

    void Start()
    {
        player = ReferenceManager.instance.player;
    }

    void OnTriggerEnter()
    {
        OpenFirstDoor();
    }

    void OnTriggerExit()
    {
        CloseSecondDoor();
        inAirlock = false;
    }

    void OnTriggerStay()
    {
        if (!inAirlock && Vector3.Dot(firstDoor.transform.position-player.transform.position,firstDoor.transform.forward) > 0f && Vector3.Distance(firstDoor.transform.position,player.transform.position) > 2.5f)
        {
            CloseFirstDoor();
            inAirlock = true;
        }
    }

    void OpenFirstDoor()
    {
        firstWall.SetActive(false);
        firstDoor.Open();
    }

    void CloseFirstDoor()
    {
        firstWall.SetActive(true);
        firstDoor.Close();
        secondWall.SetActive(false);
        secondDoor.Open();
    }

    void CloseSecondDoor()
    {
        secondWall.SetActive(true);
        secondDoor.Close();
    }
}
