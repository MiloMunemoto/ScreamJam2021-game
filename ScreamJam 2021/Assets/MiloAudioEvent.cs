using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiloAudioEvent : MonoBehaviour
{
    public UnityEvent Sound1;
    public UnityEvent Sound2;
    public UnityEvent Sound3;
    public UnityEvent AttackSound;

    public void PlaySound1() 
    {
       Sound1.Invoke();
    }
    public void PlaySound2()
    {
        Sound2.Invoke();
    }
    public void PlaySound3()
    {
        Sound3.Invoke();
    }

    public void PlaySound4Ataack()
    {
        AttackSound.Invoke();
    }
}
