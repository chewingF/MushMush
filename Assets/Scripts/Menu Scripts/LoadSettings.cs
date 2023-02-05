using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSettings : MonoBehaviour
{
   public void LoadSettingsScene()
   {
    Debug.Log("Load Settings");
    SceneManager.LoadScene("Settings");
   }
}
