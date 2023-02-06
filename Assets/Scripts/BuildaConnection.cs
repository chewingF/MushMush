using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BuildaConnection : MonoBehaviour
{

    public GameObject blowGO;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.name == "LastPos")
        {
            Debug.Log("HI");
            InkSystem.addInk(1000);
            if (blowGO)
            {
                blowGO.SetActive(true);
            }

            Debug.Log("attached");

            // pause grow
            RootGrowController.Instance.inputAllowed = false;
            RootGrowController.Instance.inputDrawing = false;

            //adjust the camera here!
            CinemachineSwitcher.Instance.SwitchCamera("Full");

        }
    }
}
