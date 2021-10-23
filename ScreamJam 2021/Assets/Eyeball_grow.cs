using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball_grow : MonoBehaviour
{
    public bool grow;

    public bool disableAfterGrowing;
    
    public float timeUntilGrow;

    public float GrowSpeed = 20f;

    public Vector3 Scale;

    private bool isScaling = false;


    private void Start()
    {
        if (grow)
        { StartCoroutine(Grow()); }

       
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(timeUntilGrow);
        { StartCoroutine(scaleOverTime(gameObject.transform, Scale, GrowSpeed)); }


    }
    

    IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        Vector3 startScaleSize = objectToScale.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        isScaling = false;

        FindObjectOfType<ListManager>().ScaleItemEyeball();
        if (disableAfterGrowing) 
        {
            gameObject.SetActive(false);
        }
    }

    public void StartGrowning() 
    {
        StartCoroutine(Grow());
    }
}
