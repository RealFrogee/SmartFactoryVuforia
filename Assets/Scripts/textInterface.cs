using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textInterface : MonoBehaviour
{
    public Image jihuachanliang;
    public Image chanliang;
    public Image ruku;         
    public Text rijihua_text;
    public Text chanliang_text;
    public Text ruku_text;      
    public times timeimg = times.today;
    public Text shuju1;
    public Text shuju2;
    public Text shuju3;

    void Start()
    {

    }

    
    void Update()
    {
        ChangeValue((int)timeimg);
    }

    public void ChangeValue(int index)
    {
        timeimg = (times)index;
        switch ((times)index)
        {

            case times.today:
                jihuachanliang.gameObject.SetActive(true);
                shuju1.gameObject.SetActive(true);
                shuju1.text = "计划产量";
                shuju2.text = "日产量";
                shuju3.text = "入库量";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                   
                    jihuachanliang.fillAmount = 1;
                    rijihua_text.text = InterfaceCenter.Instance.CarType[1].dayPlanHQA1;
                    chanliang.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].dayHQA1) / int.Parse(InterfaceCenter.Instance.CarType[2].dayPlanHQA1);
                    chanliang_text.text = InterfaceCenter.Instance.CarType[2].dayHQA1;
                    ruku.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].dayHQA8) / int.Parse(InterfaceCenter.Instance.CarType[2].dayPlanHQA1);
                    ruku_text.text = InterfaceCenter.Instance.CarType[2].dayHQA8;

                }

                break;
            case times.week:
                jihuachanliang.gameObject.SetActive(false);
                shuju1.gameObject.SetActive(false);
                shuju2.text = "周产量";
                shuju3.text= "周入库量";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    if (InterfaceCenter.Instance.AllIsDone())
                    {
                        chanliang.fillAmount = 1;
                        chanliang_text.text = InterfaceCenter.Instance.CarType[2].weekHQA1;
                        ruku.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].weekHQA8) / int.Parse(InterfaceCenter.Instance.CarType[2].weekHQA1);
                        ruku_text.text = InterfaceCenter.Instance.CarType[2].weekHQA8;
                    }
                }
                break;
            case times.month:
                jihuachanliang.gameObject.SetActive(false);
                shuju1.gameObject.SetActive(false);
                shuju2.text = "月产量";
               shuju3.text = "月入库量";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    chanliang.fillAmount = 1;
                    chanliang_text.text = InterfaceCenter.Instance.CarType[2].monthHQA1;
                    ruku.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].monthHQA8) / int.Parse(InterfaceCenter.Instance.CarType[2].monthHQA1);
                    ruku_text.text = InterfaceCenter.Instance.CarType[2].monthHQA8;
                }
                break;
            case times.year:
                jihuachanliang.gameObject.SetActive(false);
                shuju1.gameObject.SetActive(false);
                shuju2.text = "年产量";
               shuju3.text= "年入库量";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    chanliang.fillAmount = 1;
                    chanliang_text.text = InterfaceCenter.Instance.CarType[2].yearHQA1;
                    ruku.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].yearHQA8) / int.Parse(InterfaceCenter.Instance.CarType[2].yearHQA1);
                    ruku_text.text = InterfaceCenter.Instance.CarType[2].yearHQA8;
                }
                break;



        }
    }
}
