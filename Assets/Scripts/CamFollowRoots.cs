using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowRoots : MonoBehaviour
{
    public LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!lr){
            return;
        }   
        if (lr.positionCount == 0){
            // TODO: create first postion instead return
            return;
        }
        
        Vector3 lastPos = lr.GetPosition(lr.positionCount - 1);
        Vector3 camPos = this.transform.position;
        Vector3 newPos = camPos;
        newPos.x = lastPos.x;
        newPos.y = lastPos.y;

        Vector3 lerpPos = Vector3.Lerp(camPos, newPos, Time.deltaTime);
        this.transform.position = lerpPos;
    }
}
