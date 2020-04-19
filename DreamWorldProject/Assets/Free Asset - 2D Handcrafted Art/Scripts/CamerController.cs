using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamerController : MonoBehaviour {

    public static CamerController instance;

    public float speedX;
    public bool sx;

    public float speedZ;
    public bool sz;

    public float clampLeft;
    public float clampRight;

    public float clampTop = -8;
    public float clampBottom = -25;

    //private float cameraX;

    private float mouseX = 0;

    private float mouseY = 0;

    

    // Use this for initialization
    void Start () {
        //cameraX = transform.position.x;

        instance = this;

        mouseX = Input.mousePosition.x;

        mouseY = Input.mousePosition.y;

    }

    

    
	// Update is called once per frame
	void Update () {

        //鼠标右移
        if (Input.mousePosition.x > mouseX && sx)
        {
            RightPointDown();
        }

        //鼠标左移
        if (Input.mousePosition.x < mouseX && sx)
        {
            LeftPointDown();
        }

        //鼠标上移
        if (Input.mousePosition.y > mouseY && sz)
        {
            TopPointDown();
        }

        //鼠标下移
        if (Input.mousePosition.y < mouseY && sz)
        {
            BottomPointDown();
        }

#if old
        if (Input.GetKey(KeyCode.D) && transform.position.x < clampRight)
        {
            transform.Translate(new Vector3(speedX * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > clampLeft)
        {
            transform.Translate(new Vector3(-speedX * Time.deltaTime, 0, 0));
        }
#endif


        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("mouse:"+Input.mousePosition);
            Debug.Log("transform:"+transform.position);
        }
    }

    float space = 0.001f;

    /// <summary>
    /// 鼠标下移
    /// </summary>
    public void BottomPointDown()
    {
        if (transform.position.z > clampBottom)
        {
            transform.Translate(new Vector3(0, 0, -speedZ * Time.deltaTime));
            mouseY = Input.mousePosition.y;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, clampBottom + space);
        }
    }

    /// <summary>
    /// 鼠标上移
    /// </summary>
    public void TopPointDown()
    {
        if (transform.position.z < clampTop)
        {
            transform.Translate(new Vector3(0, 0, speedZ * Time.deltaTime));
            mouseY = Input.mousePosition.y;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, clampTop - space);
        }
    }

    /// <summary>
    /// 鼠标右移
    /// </summary>
    public void RightPointDown()
    {
        if (transform.position.x < clampRight)
        {
            transform.Translate(new Vector3(speedX * Time.deltaTime, 0, 0));
            mouseX = Input.mousePosition.x;
        }
        else
        {
            transform.position = new Vector3(clampRight - space, transform.position.y, transform.position.z);
        }
    }

    /// <summary>
    /// 鼠标左移
    /// </summary>
    public void LeftPointDown()
    {
        if (transform.position.x > clampLeft)
        {
            transform.Translate(new Vector3(-speedX * Time.deltaTime, 0, 0));
            mouseX = Input.mousePosition.x;
        }
        else
        {
            transform.position = new Vector3(clampLeft + space, transform.position.y, transform.position.z);
        }
    }

}
