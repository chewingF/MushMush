using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
public void ExitGame() 
{
    Debug.Log("I QUIT");
    Application.Quit();
}
}
