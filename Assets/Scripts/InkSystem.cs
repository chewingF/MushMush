using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkSystem : MonoBehaviour
{
    static public int Ink = 5000;
    public Slider slider;

    public static bool CanDraw()
    {
        if (Ink > 0)
            return true;
        else
        {
            Debug.Log("You are out of ink!");
            return false;
        }
    }

    public static void addInk(int ink_plus)
    {
        Ink += ink_plus;
    }

    public static void decInk(int ink_minus)
    {
        Ink -= ink_minus;
    }

    private void Update()
    {
        slider.value = Ink;
    }
}