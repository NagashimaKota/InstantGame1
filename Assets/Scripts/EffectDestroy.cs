using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectDestroy : MonoBehaviour {
    

 	void Start () {
        
	}
    void Update () {
        
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col2)
    {
        
        if (col2.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
