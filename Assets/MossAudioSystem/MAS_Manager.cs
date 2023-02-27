using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MAS_Manager : MonoBehaviour
{
    private static MAS_Manager _instance;
    private AudioSource _audioSource;

    private AudioClip _tofadeAudio;
    public AudioClip toFadeAudio
    {
        get
        {
            return this._tofadeAudio;
        }
    }

    private float _fadeOutTime = 0f;
    private float _fadeInTime = 0f;
    private bool _fading = false;
    private float _toFadeVol = 1f;

    public static MAS_Manager Instance
    {
        get { 
            if (_instance != null)
            {
                return _instance;
            }
            CreateIns();
            return _instance;
        }
    }
    public static bool IsInit
    {
        get { return _instance != null; }
    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance != null)
            Destroy(gameObject);
        else
            _instance = this;

        this._audioSource = this.GetComponent<AudioSource>();
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null; 
        }
    }

    private static void CreateIns()
    {
        GameObject newGO = new GameObject("MAS_Manager");
        newGO.AddComponent<MAS_Manager>();
    }

    public static void PlaySoundEffect(AudioClip ac, Vector3 position, float volume)
    {
        AudioSource.PlayClipAtPoint(ac, position, volume);
    }

    public static void PlayBackgroundMusic(AudioClip ac, float fadeOutTime, float fadeInTime, float? vol = null)
    {
        if (MAS_Manager.Instance._fading)
        {
            Debug.LogWarning("MAS_Manager: try to fade when last fade not finished");
            return;
        }

        MAS_Manager.Instance._tofadeAudio = ac;
        fadeOutTime = Mathf.Max(0, fadeOutTime);
        fadeInTime = Mathf.Max(0, fadeInTime);
        MAS_Manager.Instance._fadeOutTime = fadeOutTime;
        MAS_Manager.Instance._fadeInTime = fadeInTime;
        if (vol == null)
        {
            MAS_Manager.Instance._toFadeVol = MAS_Manager.Instance._audioSource.volume;
        }
        else
        {
            MAS_Manager.Instance._toFadeVol = (float) vol;
        }

        MAS_Manager.Instance.StartCoroutine(Fade());
    }

    public static void StopBackgroundMusic(float fadeTime)
    {
        MAS_Manager.Instance._tofadeAudio = null;
        fadeTime = Mathf.Max(0, fadeTime);
        MAS_Manager.Instance.StartCoroutine(Fade());
    }


    private static IEnumerator Fade()
    {
        MAS_Manager.Instance._fading = true;

        float startVolume = MAS_Manager.Instance._audioSource.volume;
        float timer = 0f;


        // if no current audio playing, jump to fade in
        if (MAS_Manager.Instance._audioSource.clip)
        {
            while (timer < MAS_Manager.Instance._fadeOutTime)
            {
                timer += Time.deltaTime;
                MAS_Manager.Instance._audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / MAS_Manager.Instance._fadeOutTime);
                yield return null;
            }
        }

        // next audio null, only fade out
        if (!MAS_Manager.Instance.toFadeAudio)
        {
            MAS_Manager.Instance._audioSource.clip = null;
            MAS_Manager.Instance._audioSource.Stop();
            yield return null;
        }

        MAS_Manager.Instance._audioSource.clip = MAS_Manager.Instance.toFadeAudio;
        MAS_Manager.Instance._audioSource.Play();

        timer = 0f;
        while (timer < MAS_Manager.Instance._fadeInTime)
        {
            timer += Time.deltaTime;
            MAS_Manager.Instance._audioSource.volume = Mathf.Lerp(0f, MAS_Manager.Instance._toFadeVol, timer / MAS_Manager.Instance._fadeInTime);
            yield return null;
        }

        MAS_Manager.Instance._fading = false;
    }

    public static void SetBackgroundMusicVol(float volume)
    {
        MAS_Manager.Instance._audioSource.volume = volume;
    }
    public static void PauseBackgroundMusic()
    {
        MAS_Manager.Instance._audioSource.Pause();
    }
    public static void UnPauseBackgroundMusic()
    {
        MAS_Manager.Instance._audioSource.UnPause();
    }
}
