using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
