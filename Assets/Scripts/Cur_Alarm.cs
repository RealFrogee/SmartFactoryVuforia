using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cur_Alarm : SingletonMono<Cur_Alarm>
{
    public Text title;
    public Text 生产线;
    public Text 报警信息;
    public Text 是否消除;
    public Text 报警次数;
    public Text 开始时间;
    public Text 结束时间;
    public Text 报警时长;
    UIScript uIScript;
    public Image zhuangtai;
    public Image zhuangtai2;
    public Image kongge;
    public Sprite zhuangtai3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(uIScript)
        {
            title.text= uIScript.设备;
            生产线.text = uIScript.设备;
            报警信息.text = uIScript.报警信息;
            是否消除.text = uIScript.报警取消;
            报警次数.text = uIScript.报警次数;
            开始时间.text = uIScript.报警开始;
            结束时间.text = uIScript.报警结束;
            报警时长.text = uIScript.报警时长;
            if(是否消除.text=="否")
            {
                zhuangtai.sprite = uIScript.baocuo;
                zhuangtai2.sprite = zhuangtai3;
                kongge.fillAmount = 0.5f;
            }
            if (是否消除.text == "是")
            {
                zhuangtai.sprite = uIScript.zhengcahng;
                zhuangtai2.sprite = uIScript.zhengcahng;
                kongge.fillAmount = 1f;
                kongge.color = Color.green;
            }
        }
    }
    public void SetCurAlarm(UIScript uisc )
    {
        uIScript = uisc;
    }
}
