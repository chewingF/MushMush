using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadControls : MonoBehaviour
{
   public void LoadControlScene()
   {
    Debug.Log("Load Controls");
    SceneManager.LoadScene("Controls");
   }
}