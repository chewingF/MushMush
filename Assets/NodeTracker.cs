using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeTracker : MonoBehaviour
{
    public Transform target;

    void Update () 
    {
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);
            
        //Get the Screen position of the mouse
            
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(transform.position, target.transform.position);
    
        //Ta Daaa
        Debug.DrawLine(positionOnScreen, target.transform.position, Color.red);
        transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,angle));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) 
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg + 90;
    }
}