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

    private float _fadeTime = 0f;
    private bool _fading = false;

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

    public static void PlaySoundEffect(AudioClip ac, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(ac, position);
    }

    public static void PlayBackgroundMusic(AudioClip ac, float fadeTime)
    {
        if (MAS_Manager.Instance._fading)
        {
            Debug.LogWarning("MAS_Manager: try to fade when last fade not finished");
            return;
        }

        MAS_Manager.Instance._tofadeAudio = ac;
        fadeTime = Mathf.Max(0, fadeTime);
        MAS_Manager.Instance._fadeTime = fadeTime;

        MAS_Manager.Instance.StartCoroutine(Fade());
    }


    private static IEnumerator Fade()
    {
        MAS_Manager.Instance._fading = true;

        float startVolume = MAS_Manager.Instance._audioSource.volume;
        float timer = 0f;

        while (timer < MAS_Manager.Instance._fadeTime / 2)
        {
            timer += Time.deltaTime;
            MAS_Manager.Instance._audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / (MAS_Manager.Instance._fadeTime / 2));
            yield return null;
        }

        MAS_Manager.Instance._audioSource.clip = MAS_Manager.Instance.toFadeAudio;
        MAS_Manager.Instance._audioSource.Play();

        while (timer < MAS_Manager.Instance._fadeTime)
        {
            timer += Time.deltaTime;
            MAS_Manager.Instance._audioSource.volume = Mathf.Lerp(0f, startVolume, (timer - (MAS_Manager.Instance._fadeTime / 2)) / (MAS_Manager.Instance._fadeTime / 2));
            yield return null;
        }

        MAS_Manager.Instance._fading = false;
    }
}
