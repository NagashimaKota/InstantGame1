using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScale : MonoBehaviour {

    private Vector2 m_mouseDownPosition = Vector2.zero;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        // マウスクリックした際の初期位置を保存。
        Debug.Log("aaaaaaa");
        m_mouseDownPosition = transform.position;
    }

    void OnMouseDrag()
    {
        // マウスクリックした場所をワールド座標に変化して、
        // 初期位置とマウスクリック位置の中間にオブジェクトを配置。
        // オブジェクトのスケールを初期位置とマウスクリックの距離に。
        // オブジェクトの向きをマウスクリックした位置に。
        Debug.Log("bbbbbbbbbb");
        Vector2 inputPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(inputPosition);
        Vector2 mediumPos = (mousePos - m_mouseDownPosition) / 2.0f;

        transform.position = mediumPos;
        transform.localScale = new Vector2(1.0f, 1.0f);
        transform.LookAt(mousePos);
    }

    void OnMouseUp()
    {
        Debug.Log("cccccccccccccc");
        // 位置、回転、スケールを元に戻す。
        transform.position = m_mouseDownPosition;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }
}
