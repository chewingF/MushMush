using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadControls : MonoBehaviour
{
   public GameObject controls;
   public void LoadControlScene()
   {
    Debug.Log("Load Controls");
    controls.SetActive(true);
   }
}