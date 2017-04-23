using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject attackPrefab;

    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        

    }


    void Attack()
    {
        
        Vector2 speed = Vector2.zero;
        float power = 10.0f;

        speed.x = Random.Range(-1.0f, 1.0f) * power;
        speed.y = Random.Range(-1.0f, 1.0f) * power;

        Debug.Log(speed.x);
        Debug.Log(speed.y);


        GameObject effeck = Instantiate(attackPrefab);
        effeck.transform.position = this.transform.position;
        
        effeck.GetComponent<Rigidbody2D>().velocity = speed;
    }
}
