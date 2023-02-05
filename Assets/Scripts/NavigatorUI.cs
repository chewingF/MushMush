using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NavigatorUI : MonoBehaviour
{
    public GameObject target;
    public Animator ac;
    public float secToNavOnce = 3;
    // Start is called before the first frame update
    void Start()
    {
        ac = this.GetComponent<Animator>();
    }

    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (!target){
            return;
        }
        this.transform.LookAt(target.transform.position);
        this.transform.position = RootsManager.MainRoot().GetLastPoint(true);

        this.timer += Time.deltaTime;
        if (this.timer < this.secToNavOnce){
            return;
        }
        if (ac){
            ac.SetTrigger("FadeOnce");
        }
        this.timer = 0;
        
    }
}
