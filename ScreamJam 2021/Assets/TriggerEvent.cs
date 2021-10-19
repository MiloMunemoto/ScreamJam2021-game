using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    public UnityEvent OnTriggerExitEvent;
    [SerializeField] private bool triggerOnce;

    void OnTriggerEnter()
    {
        OnTriggerEnterEvent.Invoke();
        if(triggerOnce) Destroy(gameObject);
    }

    void OnTriggerExit()
    {
        OnTriggerExitEvent.Invoke();
        if (triggerOnce) Destroy(gameObject);
    }
}