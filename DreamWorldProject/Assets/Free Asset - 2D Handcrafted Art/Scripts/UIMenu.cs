using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour {

    public Button btn_right;

    public Button btn_left;

    public Button btn_top;

    public Button btn_bottom;

    //----------------------------

    public Button btn_moreMenu;

    public Transform moreMenu;

    //---------------------------

    public Button btn_chinese;

    public Button btn_english;

    //---------------------------

    public Toggle tog_x;

    public Toggle tog_z;


    public Text txt_tog_x;

    public Text txt_tog_z;

    

    public Text txt_speed_x;

    public Text txt_speed_z;


    public Slider slider_x;

    public Slider slider_z;


    public Text txt_speed_num_x;

    public Text txt_speed_num_z;


    public Button btn_save;

    public Text txt_save;


    public Text txt_tips;

    /// <summary>
    /// 语言 1:中文   其他:english
    /// </summary>
    private int Language
    {
        set
        {
            PlayerPrefs.SetInt("LANGUAGE", value);
        }
        get
        {
            //1:中文   其他:english
            return PlayerPrefs.GetInt("LANGUAGE", 1);
        }
    }

    /// <summary>
    /// 左右移动
    /// </summary>
    private int MoveX
    {
        set
        {
            PlayerPrefs.SetInt("MOVEX", value);
        }
        get
        {
            //1:默认开启 
            return PlayerPrefs.GetInt("MOVEX", 1);
        }
    }

    /// <summary>
    /// 前后移动
    /// </summary>
    private int MoveZ
    {
        set
        {
            PlayerPrefs.SetInt("MOVEZ", value);
        }
        get
        {
            //1:默认开启 
            return PlayerPrefs.GetInt("MOVEZ", 1);
        }
    }

    /// <summary>
    /// 左右移动速度
    /// </summary>
    private float SpeedX
    {
        set
        {
            PlayerPrefs.SetFloat("SPEEDX", value);
        }
        get
        {
            return PlayerPrefs.GetFloat("SPEEDX", 0.2f);
        }
    }

    /// <summary>
    /// 前后移动速度
    /// </summary>
    private float SpeedZ
    {
        set
        {
            PlayerPrefs.SetFloat("SPEEDZ", value);
        }
        get
        {
            return PlayerPrefs.GetFloat("SPEEDZ", 0.2f);
        }
    }

    // Use this for initialization
    void Start () {

        //InitData();

        Invoke("DelegetFunc", 1f);

        btn_chinese.onClick.AddListener(OnClickChinese);

        btn_english.onClick.AddListener(OnClickEnglish);

        tog_x.onValueChanged.AddListener(OnToggleX);

        tog_z.onValueChanged.AddListener(OnToggleZ);


        slider_x.onValueChanged.AddListener(OnSlidelX);

        slider_z.onValueChanged.AddListener(OnSlidelZ);

        btn_save.onClick.AddListener(MoreMenu);
    }

    private void OnSlidelZ(float arg0)
    {
        SpeedZ = arg0;
        int speed = (int)(arg0 * 10);
        CamerController.instance.speedZ = speed;
        txt_speed_num_z.text = speed.ToString();

    }

    private void OnSlidelX(float arg0)
    {
        SpeedX = arg0;
        int speed = (int)(arg0 * 10);
        CamerController.instance.speedX = speed;
        txt_speed_num_x.text = speed.ToString();
    }

    private void OnToggleZ(bool arg0)
    {
        if (arg0)
        {
            MoveZ = 1;
            CamerController.instance.sz = true;
        }
        else
        {
            MoveZ = 0;
            CamerController.instance.sz = false;
        }
    }

    private void OnToggleX(bool arg0)
    {
        if (arg0)
        {
            MoveX = 1;
            CamerController.instance.sx = true;
        }
        else
        {
            MoveX = 0;
            CamerController.instance.sx = false;
        }
    }

    private void InitData()
    {
        if (Language==1)
        {
            OnClickChinese();
        }
        else
        {
            OnClickEnglish();
        }

        if (MoveX==1)
        {
            tog_x.isOn = true;
            OnToggleX(true);
        }
        else
        {
            tog_x.isOn = false;
            OnToggleX(false);
        }


        if (MoveZ == 1)
        {
            tog_z.isOn = true;
           OnToggleZ(true);
        }
        else
        {
            tog_z.isOn = false;
            OnToggleZ(false);
        }

        slider_x.value = SpeedX;
        OnSlidelX(SpeedX);

        slider_z.value = SpeedZ;
        OnSlidelZ(SpeedZ);
    }




    private void OnClickEnglish()
    {
        txt_tog_x.text = "Move left and right";
        txt_tog_z.text = "Move back and forth";

        txt_speed_x.text = "Speed：";
        txt_speed_z.text = "Speed：";

        txt_save.text = "OK";

        Language = 0;

        txt_tips.text = @"Tips

Long press the left button of the mouse on the left side of the screen, the scene moves to the left after 1 second ~

Long press the left button of the mouse on the far right of the screen, and the scene moves to the right after 1 second ~

Long press the left button of the mouse on the top of the screen, and the scene moves forward in 1 second ~

Long press the left button of the mouse on the bottom of the screen, and the scene will move to the back after 1 second ~";
    }

    private void OnClickChinese()
    {
        txt_tog_x.text = "左右移动";
        txt_tog_z.text = "前后移动";

        txt_speed_x.text = "速度：";
        txt_speed_z.text = "速度：";

        txt_save.text = "确 定";

        Language = 1;

        txt_tips.text = @"温馨提示

鼠标左键长按屏幕最左侧，1秒后场景向左方移动~

鼠标左键长按屏幕最右侧，1秒后场景向右方移动~

鼠标左键长按屏幕最上侧，1秒后场景向前方移动~

鼠标左键长按屏幕最下侧，1秒后场景向后方移动~";
    }

    private void DelegetFunc()
    {
        InitData();

        btn_right.GetComponent<ButtonEvent>().Repeating += CamerController.instance.RightPointDown;

        btn_left.GetComponent<ButtonEvent>().Repeating += CamerController.instance.LeftPointDown;

        btn_top.GetComponent<ButtonEvent>().Repeating += CamerController.instance.TopPointDown;

        btn_bottom.GetComponent<ButtonEvent>().Repeating += CamerController.instance.BottomPointDown;


        btn_moreMenu.GetComponent<ButtonEvent>().Once += MoreMenu;
    }


    private void MoreMenu()
    {
        moreMenu.gameObject.SetActive(!moreMenu.gameObject.activeSelf);

        if (moreMenu.gameObject.activeSelf)
        {
            btn_right.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
            btn_left.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
            btn_top.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
            btn_bottom.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
            btn_moreMenu.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            btn_right.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            btn_left.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            btn_top.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            btn_bottom.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            btn_moreMenu.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}
