using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloOpenDoorRotate : MonoBehaviour
{

    [SerializeField]
    private string animation1;
    [SerializeField]
    private string animation2;

    [SerializeField]
    private float timeUntilSecondAnim;

    private Animator anim;

    private bool AnimStarted;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!AnimStarted) 
            {
                AnimStarted = true;
               anim.Play(animation1);
               { StartCoroutine(SecondAnim()); }
                
            }
        }
    }
    IEnumerator SecondAnim()
    {
        yield return new WaitForSeconds(timeUntilSecondAnim);
        { 
            anim.Play(animation2);
            AnimStarted = false;
        
        }
    }


}
