using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public LineRenderer lineRenderer;

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int length = 0;

    public void AddPoint(Vector2 newPoint)
    {
        points.Add(newPoint);
        length++;

        //line renderer
        lineRenderer.positionCount = length;
        lineRenderer.SetPosition(length - 1, newPoint);
    }

    public Vector2 GetLastPoint()
    {
        return (Vector2)lineRenderer.GetPosition(length - 1);
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
