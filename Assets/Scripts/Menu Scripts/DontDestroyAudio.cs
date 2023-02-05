using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
   private AudioSource audioSource;
   private void Awake() 
   {
    audioSource = GetComponent<AudioSource>();
    // if(!audioSource.isPlaying)
    // {
    //     Destroy(this.gameObject);
    // }
    DontDestroyOnLoad(this.gameObject);
   }
}
