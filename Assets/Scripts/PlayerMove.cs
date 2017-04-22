using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector2 mousePos = Vector2.zero;

    private Vector2 touchOrigin = new Vector2(-1.0f, -1.0f); //Beganの条件回避
    private Rigidbody2D pl;
    
    // Use this for initialization
	void Start () {
        
        pl = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        

        //マウス操作用 Input
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;

        }

        //マウス操作用 Output
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 power = Input.mousePosition;
            mousePos -= power;
            pl.AddForce(mousePos);
        }


        //タッチ数１以上
        if (Input.touchCount >0)
        {
            //touchs配列の１番目の値を取得
            Touch myTouch = Input.touches[0];

            //タッチ開始時
            if(myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }

            //指を離したとき
            if (myTouch.phase == TouchPhase.Ended)
            {
                Vector2 power = touchOrigin - myTouch.position;
                pl.AddForce(power);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
