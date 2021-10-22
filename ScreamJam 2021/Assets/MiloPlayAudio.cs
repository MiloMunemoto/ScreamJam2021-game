using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloPlayAudio : MonoBehaviour
{
    [SerializeField]
    private string soundname;
    public void PlaySound() 
    {
        FindObjectOfType<AudioManager>().Play(soundname);
    }
}
