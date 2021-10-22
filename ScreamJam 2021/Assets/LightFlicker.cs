using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField,Range(0f,1f)] float flickerProbability;
    [SerializeField] private float minWaitTime = 5f;
    [SerializeField] private float maxWaitTime = 12f;
    private float t = 0;

    [SerializeField] private Light light;

    void Update()
    {
        t += Time.deltaTime;
        if (t < minWaitTime) return;
        if (t > maxWaitTime)
        {
            StartCoroutine(Flicker());
            t = 0;
            return;
        }

        if (Random.Range(0f,1f)<=flickerProbability*Time.deltaTime)
        {
            StartCoroutine(Flicker());
            t = 0;
        }
    }

    IEnumerator Flicker()
    {
        light.enabled = false;
        yield return new WaitForSeconds(0.1f);
        light.enabled = true;
        yield return new WaitForSeconds(0.15f);
        light.enabled = false;
        yield return new WaitForSeconds(0.15f);
        light.enabled = true;
        yield return new WaitForSeconds(0.6f);
        light.enabled = false;
        yield return new WaitForSeconds(0.2f);
        light.enabled = true;
    }
}
