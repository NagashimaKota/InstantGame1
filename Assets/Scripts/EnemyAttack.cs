using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject attackPrefab;
    private GameObject player;

    private Vector2 plPosA = Vector2.zero;
    private Vector2 plPosB = Vector2.zero;
    private Vector2 sa = new Vector2(0.001f, 0.001f);

    private bool turn = true;
    private float time = 0;
    private int buretNum = 10;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update () {
        PlayerMove pl_turn = player.GetComponent<PlayerMove>();
        turn = pl_turn.EMTurn();

        time += Time.deltaTime;

        if (time >= 1)
        {
            
            PlayerMove pl_sc = player.GetComponent<PlayerMove>();
            /*
            plPosB = pl_sc.PLPostion() - plPosA;

            plPosB.x = Mathf.Abs(plPosB.x);
            plPosA.y = Mathf.Abs(plPosB.y);

            Debug.Log(plPosA);
            Debug.Log(plPosB);
            */

            if (plPosA != pl_sc.PLPostion())
            {
                plPosA = pl_sc.PLPostion();
            }
            else
            {
                if (turn == false)
                {
                    Attack();
                    pl_sc.PLTurn();
                }
                
            }
            time = 0;
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
            
            //Debug.Log(speed.x);
            //Debug.Log(speed.y);


            GameObject effeck = Instantiate(attackPrefab);
            effeck.transform.position = this.transform.position;

            effeck.GetComponent<Rigidbody2D>().velocity = speed;
        }
    }
}
