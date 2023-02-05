using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public LineRenderer lineRenderer;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int length = 0;
    [HideInInspector] public Vector2 currDir = Vector2.down;

    public void AddPoint(Vector2 newPoint)
    {
        points.Add(newPoint);
        length++;

        //line renderer
        lineRenderer.positionCount = length;
        lineRenderer.SetPosition(length - 1, newPoint);

        if (length >= 2){
            this.currDir = (Vector2)(lineRenderer.GetPosition(length - 1) - lineRenderer.GetPosition(length - 2));
        }
    }

    public Vector2 GetLastPoint()
    {
        if (length <= 0){
            return this.transform.position;
        }
        return (Vector2)lineRenderer.GetPosition(length - 1);
    }

    public Vector2 GetLastDir(){
        return this.currDir;
    }

    public void SetLineColor(Gradient colorGradient)
    {
        lineRenderer.colorGradient = colorGradient;
    }

    public void SetLineWidth(float width)
    {
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
