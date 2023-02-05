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
    
    private bool inputDrawing;

    public LayerMask cantDrawOverLayer;
    int cantDrawOerLayerIndex;
    

    private Vector2 _lastMousePos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        this._lastMousePos = Input.mousePosition;
        Cursor.visible = false;
        cantDrawOerLayerIndex = LayerMask.NameToLayer("CantDrawOver");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirInput();

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Stop");
            inputDrawing = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Grow");
            inputDrawing = true;
        }

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
    
        this._growDir = newGrowDir;

    }

    void UpdateLineRender(){
        if (inputDrawing && InkSystem.CanDraw())
        {
            Vector2 lastPos = this._currRoot.GetLastPoint();
            RaycastHit2D hit = Physics2D.CircleCast(lastPos, this._currRoot.lineRenderer.endWidth / 3f, Vector2.zero, 0.1f, cantDrawOverLayer);

            if (hit)
            {
                return;
            }
            else
            {
                //cant grow roots on existed roots
                //Debug.Log(this._currRoot.gameObject);
                //this._currRoot.gameObject.layer = cantDrawOerLayerIndex;
                this._currRoot.AddPoint(_growDir * growSpd * Time.deltaTime + lastPos);
                InkSystem.decInk(1);
            }
        }
    } 
}
