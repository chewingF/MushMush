using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public IEnumerator ChangeVCamSize(float changeToSize, float changeTime) 
    {
        float timer = 0f;
        float difference = changeToSize - this.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
        float startSize = this.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
        
        do
        {
            this.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize += 0.1f;

            timer += Time.deltaTime;
            
            yield return null;
        }  while (timer <= changeTime);
    }


    public IEnumerator ChangeCamSize(float changeToSize, float changeTime) 
    {
        float timer = 0f;
        float difference = changeToSize - this.gameObject.GetComponent<Camera>().orthographicSize;

        do
        {
            this.gameObject.GetComponent<Camera>().orthographicSize = ((timer / changeTime * changeToSize) + 1.5f);

            timer += Time.deltaTime;
            
            yield return null;
        }  while (timer <= changeTime);
    }
}
