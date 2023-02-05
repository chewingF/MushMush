using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowDirUI : MonoBehaviour
{
    public RootGrowController gc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gc){
            return;
        }
        this.transform.LookAt((Vector3)gc.growDir + this.transform.position);
        this.transform.position = RootsManager.MainRoot().GetLastPoint();
    }
}
