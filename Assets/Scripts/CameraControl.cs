using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Root _currRoot
    {
        get
        {
            return RootsManager.MainRoot();
        }
    }

    private Transform LastPos;

    void Start()
    {
        LastPos = GameObject.Find("LastPos").transform;
    }

    void Update()
    {
        UpdateLastPos();
    }

    void UpdateLastPos()
    {
        LastPos.position = this._currRoot.GetLastPoint();
    }
}
