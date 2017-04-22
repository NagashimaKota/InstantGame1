using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector2 touchOrigin = new Vector2(-1.0f, -1.0f);
    private Rigidbody2D pl;
    
    // Use this for initialization
	void Start () {
        
        pl = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        int horizontal = 0;
        int vertical = 0;

        //キーボード用
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");


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
}
