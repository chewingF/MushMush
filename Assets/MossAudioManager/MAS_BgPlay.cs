using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAS_BgPlay : MonoBehaviour
{
    public AudioClip bgAudio;
    public float fadeTime = 1;
    public bool autoPlay = false;

    public void Awake()
    {
        if (autoPlay)
        {
            this.StartFadeBg();
        }
    }

    public void StartFadeBg()
    {
        if (!bgAudio)
        {
            Debug.LogWarning("MAS_BgPlay: bgAudio missing");
            return;
        }
        MAS_Manager.PlayBackgroundMusic(bgAudio, fadeTime);
    }
}
