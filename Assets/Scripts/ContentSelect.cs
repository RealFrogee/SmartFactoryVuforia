using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ContentSelect : MonoBehaviour
{
    public GameObject cell;
    Transform[] cells;
    Color color;
    string lanse="#1357DD";//正在返修
    string hongse="#FF1414";//未完成
    public Sprite zhengzaifanxiu;
    public Sprite chaoshi;
    Vector3 itemLocalPos;
    float itemHeight;
    Vector2 contentSize;
    int num;
    void Start()
    {
        StartCoroutine(wait());
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        if(Testweb.Instance.AllReady())
        {
            if(InterfaceCenter.Instance.detailInfo.Length!=0)
            {
                num = InterfaceCenter.Instance.detailInfo.Length;
                cells = new Transform[num];
                CreateCells();
            }
           
        }
       
    }
    void CreateCells()
    {
        for(int i=0;i<num;i++)
        {

            contentSize = transform.GetComponent<RectTransform>().sizeDelta;
            itemHeight = cell.GetComponent<RectTransform>().rect.height;
            itemLocalPos = cell.transform.localPosition;
            cells[i]= Instantiate(cell).transform;
            cells[i].GetComponent<Transform>().SetParent(transform.GetComponent<Transform>(), false);
            cells[i].transform.localPosition = new Vector3(itemLocalPos.x, itemLocalPos.y - num * itemHeight, 0);
            if (contentSize.y <= num * itemHeight)//增加内容的高度
            {
                transform.GetComponent<RectTransform>().sizeDelta = new Vector2(contentSize.x, num * itemHeight);
            }





            //double temp;
            //double.TryParse(InterfaceCenter.Instance.detailInfo[i].Seconds, out temp);
            //DateTime dateTime = DateTime.Parse(InterfaceCenter.Instance.detailInfo[i].enterTime).AddSeconds(temp);
            //if(DayCompare(dateTime)==0)
            //{
            //    //刚好到时间
            //    ColorUtility.TryParseHtmlString(lvse, out color);
            //}
            //if(DayCompare(dateTime) > 0)
            //{
            //    //返修中
            //    ColorUtility.TryParseHtmlString(lvse, out color);
            //}
            //if (DayCompare(dateTime) <0)
            //{
            //    //超时
            //    ColorUtility.TryParseHtmlString(lvse, out color);
            //}
            if (InterfaceCenter.Instance.Repair_status( InterfaceCenter.Instance.detailInfo[i].status)>0)
            {
                //超时
                double temp2;
                double.TryParse(InterfaceCenter.Instance.detailInfo[i].Seconds, out temp2);
                Utils.Utility.findChild(cells[i], "Image").GetComponent<Image>().sprite=chaoshi;
                Utils.Utility.findChild(cells[i], "Text_VIN").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].VIN;
                Utils.Utility.findChild(cells[i], "Text_配置颜色").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].bulMod;
                Utils.Utility.findChild(cells[i], "Text_返修时长").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].Duration;
                Utils.Utility.findChild(cells[i], "Text_返修进入时间").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].enterTime;
                Utils.Utility.findChild(cells[i], "Text_返修完成时间").GetComponent<Text>().text = DateTime.Parse(InterfaceCenter.Instance.detailInfo[i].enterTime).AddSeconds(temp2).ToString();
                Utils.Utility.findChild(cells[i], "Fillter").GetComponent<Image>().fillAmount = 1;



            }
           else if (InterfaceCenter.Instance.Repair_status(InterfaceCenter.Instance.detailInfo[i].status) < 0)
            {
                //进行中
                double temp3;
                double.TryParse(InterfaceCenter.Instance.detailInfo[i].Seconds, out temp3);
                System.TimeSpan t3 = DateTime.Parse(InterfaceCenter.Instance.detailInfo[i].enterTime).AddSeconds(temp3) - DateTime.Now;
                double fill = t3.TotalSeconds /temp3;
                Utils.Utility.findChild(cells[i], "Image").GetComponent<Image>().sprite = zhengzaifanxiu;
                Utils.Utility.findChild(cells[i], "Text_VIN").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].VIN;
                Utils.Utility.findChild(cells[i], "Text_配置颜色").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].bulMod;
                Utils.Utility.findChild(cells[i], "Text_返修时长").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].Duration;
                Utils.Utility.findChild(cells[i], "Text_返修进入时间").GetComponent<Text>().text = InterfaceCenter.Instance.detailInfo[i].enterTime;
                Utils.Utility.findChild(cells[i], "Text_返修完成时间").GetComponent<Text>().text = DateTime.Parse(InterfaceCenter.Instance.detailInfo[i].enterTime).AddSeconds(temp3).ToString();
                Utils.Utility.findChild(cells[i], "Fillter").GetComponent<Image>().fillAmount =(float)fill;
            }
            else
            {
                Debug.Log("没有数据");
            }


        }
       
       
    }
    int DayCompare(DateTime dateTime)
    {
        return (DateTime.Compare(DateTime.Now, dateTime));
        //返回>0 那么时间比现在多，翻修中
        //返回小于0时间比现在少，超时
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
