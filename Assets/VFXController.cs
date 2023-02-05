using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VFXController : MonoBehaviour
{
    Volume pp_volume;
    public VolumeProfile pp_profile_default;
    public VolumeProfile pp_profile_mushFollow;
    Vignette pp_vignette;
    Bloom pp_bloom;
    ColorAdjustments pp_colAdjust;
    public GameObject mainCam;

    // DepthOfField pp_depthOfField;
    // ChromaticAberration pp_aberration;

    // Start is called before the first frame update
    void Awake()
    {
        pp_volume = this.gameObject.GetComponent<Volume>();

        pp_volume.profile.TryGet<Vignette>(out pp_vignette);
        pp_volume.profile.TryGet<Bloom>(out pp_bloom);
        pp_volume.profile.TryGet<ColorAdjustments>(out pp_colAdjust);
    }

    void Update() 
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     SwapProfiles();
        // }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ChangeColor(1f, -70f);
        }
    }

    private void SetVignetteFocus(float x, float y)
    {
        pp_vignette.center.value = new Vector2(x, y);
    }

    public void SwapProfiles() 
    {
        if (pp_volume.profile == pp_profile_default) 
        {
            pp_volume.profile = pp_profile_mushFollow;
        }
        else
        {
            pp_volume.profile = pp_profile_default;
        }
    }

    // public IEnumerator FadeVignette(float fadeTime, float intensityVal)
    // {
    //     float timer = 0f;
    //     //float startingVal = pp_vignette.intensity.value;

    //     do
    //     {
    //         pp_vignette.intensity.value -= (timer / fadeTime * intensityVal);

    //         timer += Time.deltaTime;
            
    //         yield return null;
    //     }  while (timer <= fadeTime);
    // }

    // private IEnumerator FadeAberration(float fadeTime)
    // {
    //     float timer = 0f;
    //     do
    //     {
    //         pp_vignette.intensity.value = (timer / fadeTime);

    //         timer += Time.deltaTime;

    //         yield return null;
    //     } while (timer <= fadeTime);
    // }

    private IEnumerator FadeBloom(float fadeTime, float intensityVal)
    {
        float timer = 0f;

        do
        {
            pp_bloom.intensity.value = (timer / fadeTime * intensityVal);

            timer += Time.deltaTime;

            yield return null;
        } while (timer <= fadeTime);
    }

    public void ChangeColor(float fadeTime, float saturationVal) 
    {
        //pp_colAdjust.saturation.value = saturationVal;
        StartCoroutine(ChangeSaturation(fadeTime, saturationVal));
    }

    private IEnumerator ChangeSaturation(float fadeTime, float saturationVal)
    {
        float timer = 0f;

        do
        {
            pp_colAdjust.saturation.value += 0.1f;

            timer += Time.deltaTime;

            yield return null;
        } while (timer <= fadeTime);
    }
}
