using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject linePrefab;

    [Space(30f)]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;

    Line currrentLine;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeginDraw();
        }

        if (currrentLine != null)
        {
            Draw();
        }

        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }
    }

    void BeginDraw()
    {
        currrentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        currrentLine.UsePhysics(false);
        currrentLine.SetLineColor(lineColor);
        currrentLine.SetPointsMinDistance(linePointsMinDistance);
        currrentLine.SetLineWidth(lineWidth);
    }

    void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        currrentLine.AddPoint(mousePosition);
    }

    void EndDraw()
    {
        if (currrentLine != null)
        {
            if (currrentLine.pointsCount < 2)
            {
                //if line has one point
                Destroy(currrentLine.gameObject);
            }
            else
            {
                //turn off/on physics here
                currrentLine.UsePhysics(false);
                currrentLine = null;
            }
        }
    }
}
