using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootGrowController : MonoBehaviour
{
    private Root _currRoot {
        get{
            return RootsManager.MainRoot();
        }
    }

    public float mouseSensitive = 1;

    private Vector2 _growDir = new Vector2();
    public float growRate = 0.01f;
    private float growSpd = 1;

    private Vector2 _lastMousePos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        this._lastMousePos = Input.mousePosition;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirInput();
        UpdateLineRender();
    }

    void UpdateDirInput(){

        Vector2 newGrowDir = this._growDir;
        // bool isRight = Vector2.Dot(this._growDir, Vector2.right) >= 0;
        // bool isUp = Vector2.Dot(this._growDir, Vector2.up) >= 0;

        Vector2 moveDt = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // Vector2 moveDt = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        newGrowDir += moveDt;
        newGrowDir.Normalize();

        // Vector2 mouseDelta = (Vector2)Input.mousePosition - this._lastMousePos;
        // mouseDelta.Normalize();
        // mouseDelta *= mouseSensitive;
        // this._lastMousePos = (Vector2)Input.mousePosition;

        // newGrowDir += mouseDelta;
        // newGrowDir.Normalize();

        Debug.DrawLine(Vector3.zero, newGrowDir * 10, Color.red);
        Debug.Log(newGrowDir);

        // TODO: limit arrow by last grow dir
        this._growDir = newGrowDir;

    }

    void UpdateLineRender(){
        // if (!lr){
        //     return;
        // }
        // if (lr.positionCount == 0){
        //     // TODO: create first postion instead return
        //     return;
        // }
        
        // Vector3 lastPos = lr.GetPosition(lr.positionCount - 1);
        // Vector3 newPos = lastPos;
        // newPos += (this.growDir.normalized * this.growSpd * growRate);

        // lr.positionCount += 1;
        // lr.SetPosition(lr.positionCount - 1, newPos);

    } 
}
