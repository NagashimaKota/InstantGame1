using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{

    private int plLife = 100;
    private int emLife = 1000;
    private bool turn = true;
    
    private Vector2 mousePos = Vector2.zero;
    private Vector2 touchOrigin = new Vector2(-1.0f, -1.0f); //Beganの条件回避
    private Rigidbody2D pl;


    public Text ClearText;
    public Text OverText;
    public Text plHP;
    public Text emHP;

    // Use this for initialization
    void Start()
    {

        pl = GetComponent<Rigidbody2D>();
        plHP.text = " PL Life: " + plLife;
        emHP.text = " EM Life: " + emLife;

        ClearText.gameObject.SetActive(false);
        OverText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (turn == true)
        {
            Attack();
        }

        plHP.text = "PL Life: " + plLife;
        emHP.text = "EM Life: " + emLife;
    }

    void Attack()
    {
        
        //マウス操作用 Input
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
        }

        //マウス操作用 Output
        if (Input.GetMouseButtonUp(0))
        {
            //最大・最小ベクトル設定(仮)
            Vector2 maxPower = new Vector2(100, 100);

            Vector2 power = Input.mousePosition;
            mousePos -= power;
            //最大、最小設定
            //x,yどちらも強い
            if (Math.Abs(mousePos.x) >= Math.Abs(maxPower.x) && Math.Abs(mousePos.y) >= Math.Abs(maxPower.y))
            {
                if (mousePos.x < 0 && mousePos.y < 0)
                {
                    mousePos = -maxPower;
                }
                else if (mousePos.x < 0 && mousePos.y > 0)
                {
                    mousePos.x = -maxPower.x;
                    mousePos.y = maxPower.y;
                }
                else if (mousePos.x > 0 && mousePos.y < 0)
                {
                    mousePos.x = maxPower.x;
                    mousePos.y = -maxPower.y;
                }
                else
                {
                    mousePos = maxPower;
                }
                turn = false;
            }
            //xが強い
            else if (Math.Abs(mousePos.x) >= Math.Abs(maxPower.x))
            {
                if (mousePos.x < 0)
                {
                    mousePos.x = -maxPower.x;
                }
                else
                {
                    mousePos.x = maxPower.x;
                }
                turn = false;
            }
            //yが強い
            else if (Math.Abs(mousePos.y) >= Math.Abs(maxPower.y))
            {
                if (mousePos.y < 0)
                {
                    mousePos.y = -maxPower.y;
                }
                else
                {
                    mousePos.y = maxPower.y;
                }
                turn = false;
            }
            //xまたはyが弱い(最小設定)
            else if (Math.Abs(mousePos.x) <= 20 || Math.Abs(mousePos.y) <= 20)
            {
                mousePos = Vector2.zero;
            }
            Debug.Log(mousePos);
            pl.AddForce(mousePos);
        }


        //タッチ数１以上
        if (Input.touchCount > 0)
        {
            //touchs配列の１番目の値を取得
            Touch myTouch = Input.touches[0];

            //タッチ開始時
            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }

            //指を離したとき
            if (myTouch.phase == TouchPhase.Ended)
            {
                Vector2 power = touchOrigin - myTouch.position;
                pl.AddForce(power);
                turn = false;
            }
        }
    }


    public bool EMTurn()
    {
        return turn;
    }

    public void PLTurn()
    {
        turn = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            emLife -= 50;
            Debug.Log(emLife);
        }
        if (emLife <= 0)
        {
            ClearText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "E_attack")
        {
            plLife -= 5;
            Debug.Log(plLife);
        }
        
        if (plLife<=0)
        {
            OverText.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
        
    }
}
