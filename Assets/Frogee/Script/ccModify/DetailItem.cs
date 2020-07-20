using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailItem : MonoBehaviour
{
  //  public Sprite overSprite;
  //  public Sprite unoverSprite;
    public Image statusImg;
    public Text Vintext;
    public Text enterTimeText;
  //  public Text parkingSpaceText;
    public Text durationText;
    public Text statusText;
    //public Text repairmanText;
    public Text bulModText;

    public void InitDetailItem(string vin,string enterTime,string parkingSpace,string duration,string status,string repairman,string bulMod)
    {
        
        Vintext.text ="VIN "+ vin;
        enterTimeText.text ="开始时间 "+ enterTime;
       // parkingSpaceText.text="库位 "+parkingSpace;
        durationText.text="返修时长 " +duration;
        statusText.text=status;
      //  repairmanText.text="负责人 "+repairman;
        bulModText.text="配置颜色 "+bulMod;
        if(status=="返修超时")
        {          
            statusText.color = Color.red;
        }
        else
        {
            statusText.color = Color.green;
        }

       // if(status=="返修")
    }

}
