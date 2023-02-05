using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrowController : MonoBehaviour
{
    public LineRenderer lr;

    private Vector3 growDir = new Vector3();
    public float growRate = 0.01f;
    private float growSpd = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirInput();
        UpdateLineRender();
    }

    void UpdateDirInput(){
        this.growDir = Vector2.zero;
        if (Input.GetKey(KeyCode.A)){
            growDir.x -= 1;
        }
        if (Input.GetKey(KeyCode.W)){
            growDir.y += 1;
        }
        if (Input.GetKey(KeyCode.S)){
            growDir.y -= 1;
        }
        if (Input.GetKey(KeyCode.D)){
            growDir.x += 1;
        }
        this.growSpd = this.growDir.magnitude;
    }

    void UpdateLineRender(){
        if (!lr){
            return;
        }
        if (lr.positionCount == 0){
            // TODO: create first postion instead return
            return;
        }
        
        Vector3 lastPos = lr.GetPosition(lr.positionCount - 1);
        Vector3 newPos = lastPos;
        newPos += (this.growDir.normalized * this.growSpd * growRate);

        lr.positionCount += 1;
        lr.SetPosition(lr.positionCount - 1, newPos);

    } 
}
