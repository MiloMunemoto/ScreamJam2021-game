using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiloPlayAudioManager : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

   public void PlayAudioManager(string soundname) 
   {
        audioManager.Play(soundname);
   }

}
