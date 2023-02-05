using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AreaChangeGrowRate : MonoBehaviour
{
    public float fixedGrowRate = 1;
    private float rateBefore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.name == "LastPos")
        {
            this.rateBefore = RootGrowController.Instance.growRate;
            RootGrowController.Instance.growRate = this.fixedGrowRate;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
        if (collision.gameObject.name == "LastPos")
        {
            RootGrowController.Instance.growRate = this.rateBefore;
        }
    }
}
