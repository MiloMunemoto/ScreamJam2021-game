using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloAutomaticDoor : MonoBehaviour
{   

    [SerializeField]
    private GameObject Door1_left;
    [SerializeField]
    private GameObject Door1_right;
    [SerializeField]
    private GameObject Door2_left;
    [SerializeField]
    private GameObject Door2_right;

    private Animator animDoor1L;
    private Animator animDoor1R;
    private Animator animDoor2L;
    private Animator animDoor2R;

    private string left = "doorleft";
    private string right = "doorright";
    private string closeleft = "closedoorleft";
    private string closeright = "closedoorright";

    public bool inAirlock = false;

    private void Start()
    {
        animDoor1L = Door1_left.GetComponent<Animator>();
        animDoor1R = Door1_right.GetComponent<Animator>();
        animDoor2L = Door2_left.GetComponent<Animator>();
        animDoor2R = Door2_right.GetComponent<Animator>();
    }

    public void OpenDoor1()
    {
        animDoor1L.Play(left);
        animDoor1R.Play(right);
    }

    public void OpenDoor2()
    {
        animDoor2L.Play(left);
        animDoor2R.Play(right);
    }

    public void CloseDoor1()
    {
        animDoor1L.Play(closeleft);
        animDoor1R.Play(closeright);
    }

    public void CloseDoor2()
    {
        animDoor2L.Play(closeleft);
        animDoor2R.Play(closeright);
    }


    
    /*



    void OnTriggerExit()
    {
        CloseSecondDoor();
        inAirlock = false;
    }

    void OnTriggerStay()
    {
        if (!inAirlock && Vector3.Dot(firstDoor.transform.position - other.transform.position, firstDoor.transform.forward) > 0f && Vector3.Distance(firstDoor.transform.position, player.transform.position) > 2.5f)
        {
            CloseFirstDoor();
            inAirlock = true;
        }
    }

    void OpenFirstDoor()
    {
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

    */
}
