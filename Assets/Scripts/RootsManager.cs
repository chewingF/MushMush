using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsManager : Singleton<RootsManager>
{

    // GrowSys
    // RenderSys
    // BranchSys

    private Root _mainRoot;
    private List<Root> _otherRoots = new List<Root>();

    private Transform _rootsPTran;
    
    public GameObject RootIns = null;
    // Start is called before the first frame update
    void Start()
    {
        if (!this.RootIns){
            return;
        }

        // generate a parent go for root instances
        GameObject rootsP = new GameObject();
        rootsP.transform.SetParent(this.transform);
        rootsP.transform.localPosition = Vector3.zero;
        this._rootsPTran = rootsP.transform;

        // generate the first root instance
        GameObject ri = GameObject.Instantiate(RootIns);
        ri.transform.SetParent(this._rootsPTran);
        ri.transform.localPosition = Vector3.zero;

        // Set first main root
        this._mainRoot = ri.GetComponent<Root>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Root MainRoot(){
        return Instance._mainRoot;
    }
}
