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
    public float TurnAngLmt = 15;

    private Vector2 _growDir = new Vector2();
    public float growRate = 0.01f;
    private float growSpd = 1;
    
    private bool inputDrawing;

    public LayerMask cantDrawOverLayer;
    int cantDrawOerLayerIndex;
    int rootsSortingLayerIndex;
    

    private Vector2 _lastMousePos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        this._lastMousePos = Input.mousePosition;
        Cursor.visible = false;
        cantDrawOerLayerIndex = LayerMask.NameToLayer("CantDrawOver");
        rootsSortingLayerIndex = SortingLayer.NameToID("Roots");
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
        Vector2 moveDt = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        newGrowDir += moveDt;
        newGrowDir.Normalize();

        // Check angle limit
        Vector2 lastDir = this._currRoot.GetLastDir(30);
        if (Vector2.Angle(lastDir, newGrowDir) <= TurnAngLmt){
            this._growDir = newGrowDir;
        }


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
                this._currRoot.AddPoint(_growDir * growSpd * Time.deltaTime + lastPos);
                this._currRoot.lineRenderer.sortingLayerID = rootsSortingLayerIndex;
                InkSystem.decInk(1);
            }
        }
    } 
}
