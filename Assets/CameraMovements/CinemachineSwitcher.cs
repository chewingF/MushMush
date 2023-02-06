using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CinemachineSwitcher : Singleton<CinemachineSwitcher>
{
    Animator _animator;
    [SerializeField] bool _keyTest = false;

    private  void  Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();

        if (_animator == null)
        {
            //Debug.LogError("Animator is Null");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_keyTest)
        {

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                SwitchCamera("Mush");
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchCamera("Follow");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchCamera("Full");
            }

        }

    }

    public void SwitchCamera(string camera)
    {

        switch (camera)
        {
            case "Mush":
                //Mush anim
                _animator.Play("Mush");
                break;
            case "Follow":
                //Follow anim
                _animator.Play("Follow");
                break;
            case "Full":
                //Full anim
                _animator.Play("Full");
                break;
            default:
                //Mush anim
                _animator.Play("Mush");
                break;

        }
    
    }

}
