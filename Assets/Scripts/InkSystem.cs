using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSystem : MonoBehaviour
{
    static public int Ink = 500;

    public static bool CanDraw()
    {
        if (Ink > 0)
            return true;
        else
            return false;
    }

    public static void addInk(int ink_plus)
    {
        Ink += ink_plus;
    }

    public static void decInk(int ink_minus)
    {
        Ink -= ink_minus;
    }
}
