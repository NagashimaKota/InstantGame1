using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject attackPrefab;
    private GameObject player;

    private bool turn = true;
    private int buretNum = 20;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {

        PlayerMove pl_sc = player.GetComponent<PlayerMove>();
        turn = pl_sc.EMTurn();


        if (turn == false)
        {
            
            Debug.Log("False");
            //Attack();
            Invoke( "Attack", 2);
            pl_sc.PLTurn();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }


    void Attack()
    {
        for (int i = 0; i < buretNum; i++)
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
}
