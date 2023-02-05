using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public Camera mainCam;
    public CinemachineBrain camBrain;
    public CinemachineVirtualCamera cutsceneCam;
    public CinemachineVirtualCamera followCam;

    [SerializeField]private VFXController vfxControl;

    public GameObject[] eyes;
    public GameObject player;
    public GameObject[] blueObjects;
    
    void Start() 
    {
        vfxControl = mainCam.gameObject.GetComponent<VFXController>();
        StartCoroutine(StartGame());
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // player.gameObject.layer = LayerMask.NameToLayer("IgnorePostProcessing");

            // foreach(Transform child in player.transform) 
            // {
            //     child.gameObject.layer = LayerMask.NameToLayer("IgnorePostProcessing");
            // }

            // foreach(GameObject blueObj in blueObjects) 
            // {
            //     blueObj.gameObject.layer = LayerMask.NameToLayer("IgnorePostProcessing");
            // }
        }
    }

    private IEnumerator StartGame() 
    {
        yield return new WaitForSeconds(3f);

        // foreach(GameObject eye in eyes) 
        // {
        //     eye.SetActive(false);
        // }

        // player.SetActive(true);
        // //StartCoroutine(vfxControl.FadeVignette(2f, 0f));
        // StartCoroutine(cutsceneCam.gameObject.GetComponent<CameraController>().ChangeVCamSize(3f, 2f));
        // //StartCoroutine(mainCam.gameObject.GetComponent<CameraController>().ChangeCamSize(12f, 2f));

        // yield return new WaitForSeconds(2f);

        cutsceneCam.Priority = 0;
        followCam.Priority = 10;
    }
}
