using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCam;
    [SerializeField]private VFXController vfxControl;

    public GameObject[] eyes;
    public GameObject player;
    
    void Start() 
    {
        vfxControl = mainCam.gameObject.GetComponent<VFXController>();
        StartCoroutine(StartGame());
    }

    void Update() 
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     player.gameObject.layer = LayerMask.NameToLayer("IgnorePostProcessing");

        //     foreach(Transform child in player.transform) 
        //     {
        //         child.gameObject.layer = LayerMask.NameToLayer("IgnorePostProcessing");
        //     }
        // }
    }

    private IEnumerator StartGame() 
    {
        yield return new WaitForSeconds(3f);

        foreach(GameObject eye in eyes) 
        {
            eye.SetActive(false);
        }

        player.SetActive(true);
        StartCoroutine(vfxControl.FadeVignette(2f, 0f));
        StartCoroutine(mainCam.gameObject.GetComponent<CameraController>().ChangeCamSize(12f, 2f));
    }
}
