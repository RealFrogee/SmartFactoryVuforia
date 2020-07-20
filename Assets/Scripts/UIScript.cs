using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject handMenu;
    public Image genghuan;
    public Sprite baocuo;
    public Sprite zhengcahng;
    public string t_name;
    public string url;
    public bool isDone;
    [Range(1, 5)]
    public int 设备型号;

    public string 报警码;
    public string 报警信息;
    public string 线体;
    public string 设备;
    public string 工位;
    public string 报警开始;
    public string 报警结束;
    public string 报警取消;
    public string 报警时长;

    public string 报警次数;
    void Start()
    {
        url = "http://10.4.20.45:88/momtoar/WebService.asmx" + "?dev=" + name;

      //  InvokeRepeating("gettupe", 0, 30);
    }
    public void gettupe()
    {
        StartCoroutine(Testweb.Instance.Request4(url, transform));
    }

    // Update is called once per frame
    void Update()
    {
        //check();
    }
    void check()
    {
        if(报警取消=="否")
        {
            genghuan.sprite = baocuo;
        }
        else
        {
            genghuan.sprite = zhengcahng;
        }
        switch (设备型号)
        {
            case 1:
                报警次数 = InterfaceCenter.Instance.涂胶机;
                break;
            case 2:
                报警次数 = InterfaceCenter.Instance.机器人;
                break;
            case 3:
                报警次数 = InterfaceCenter.Instance.加注机;
                break;
            case 4:
                报警次数 = InterfaceCenter.Instance.车轮拧紧;
                break;
            case 5:
                报警次数 = InterfaceCenter.Instance.底盘;
                break;
      

        }
            

    }
    public void GetCurAlarm()
    {
        handMenu.SetActive(true);
        PanelController.Instance.showPanel(1);
        Cur_Alarm.Instance.SetCurAlarm(this);
       
        
    }

    
}
