using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildaConnection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Connections")
        {
            Debug.Log("HI");
            InkSystem.addInk(1000);
            //adjust the camera here!
            ChangeColor();
        }
    }

    void ChangeColor()
    {

    }
}
