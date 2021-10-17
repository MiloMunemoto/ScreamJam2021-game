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

    void Start()
    {
        player = ReferenceManager.instance.player;
    }

    void OnTriggerEnter()
    {
        OpenAirlock();
    }

    void OnTriggerStay()
    {
        if (Vector3.Dot(transform.position-player.transform.position,firstDoor.transform.forward) > 0f && Vector3.Distance(transform.position,player.transform.position) > 0.5f)
        {
            CloseAirlock();
        }
    }

    void OpenAirlock()
    {
        firstWall.SetActive(false);
    }

    void CloseAirlock()
    {
        firstWall.SetActive(true);
        secondWall.SetActive(false);
    }
}
