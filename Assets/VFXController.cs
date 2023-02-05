using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VFXController : MonoBehaviour
{
    Volume pp_volume;
    Vignette pp_vignette;
    Bloom pp_bloom;
    ColorAdjustments pp_colAdjust;
    // DepthOfField pp_depthOfField;
    // ChromaticAberration pp_aberration;

    // Start is called before the first frame update
    void Start()
    {
        pp_volume = this.gameObject.GetComponent<Volume>();

        pp_volume.profile.TryGet<Vignette>(out pp_vignette);
        pp_volume.profile.TryGet<Bloom>(out pp_bloom);
        pp_volume.profile.TryGet<ColorAdjustments>(out pp_colAdjust);
    }

    private void SetVignetteFocus(float x, float y)
    {
        pp_vignette.center.value = new Vector2(x, y);
    }

    public IEnumerator FadeVignette(float fadeTime, float intensityVal)
    {
        float timer = 0f;
        float startingVal = pp_vignette.intensity.value;

        do
        {
            pp_vignette.intensity.value -= (timer / fadeTime * intensityVal);

            timer += Time.deltaTime;
            
            yield return null;
        }  while (timer <= fadeTime);
    }

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

    public void ChangeColor(float saturationVal) 
    {
        pp_colAdjust.saturation.value = saturationVal;
    }
}
