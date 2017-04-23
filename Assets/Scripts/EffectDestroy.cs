using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectDestroy : MonoBehaviour {
    

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    


    void OnTriggerExit2D(Collider2D col2)
    {
        
        if (col2.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
