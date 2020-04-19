using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    Vector3 point = Vector3.zero;

    Vector3 pos = Vector3.zero;
	
	// Update is called once per frame
	void Update () {
        point = new Vector3(Input.mousePosition.x,Input.mousePosition.y,10);

        transform.position = Camera.main.ScreenToWorldPoint(point);//从屏幕空间转换到世界空间;

        //point.y = 0;

        //transform.position = pos;

    }
}
