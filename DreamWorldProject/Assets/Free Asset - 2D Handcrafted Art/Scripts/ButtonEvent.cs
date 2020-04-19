using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void ButtonDelegate();

public class ButtonEvent : MonoBehaviour, IPointerDownHandler,IPointerUpHandler{

    /// <summary>
    /// 长按重复执行
    /// </summary>
	public ButtonDelegate Repeating;

    /// <summary>
    /// 长按只执行一次
    /// </summary>
    public ButtonDelegate Once;

    //string transformName;

    public void OnPointerDown(PointerEventData eventData)
	{
        if (!IsInvoking("OnPressRepeating"))
        {
            InvokeRepeating("OnPressRepeating", 1, 0.001f);
        }

        if (!IsInvoking("OnPressOnce"))
        {
            Invoke("OnPressOnce", 1);
        }
        
        
    }

	public void OnPointerUp(PointerEventData eventData)
	{
        CancelInvoke();
    }

	private void Awake()
	{
		//transformName = transform.name;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnPressRepeating()
	{
        if (Repeating!=null)
        {
            Repeating();
        }
        
    }


    private void OnPressOnce()
    {
        if (Once!=null)
        {
            Once();
        }
    }
}
