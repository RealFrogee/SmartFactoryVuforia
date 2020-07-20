using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class squaldInfo : MonoBehaviour
{
    public DrawSquald HS7;
    times timeimg = times.today;
    public Text CenterText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeValue((int)timeimg);
    }

    public void ChangeValue(int index)
    {
        timeimg = (times)index;
        Debug.Log(int.Parse(InterfaceCenter.Instance.CarType[1].dayHQA1));
        switch ((times)index)
        {

            case times.today:
                this.gameObject.SetActive(true);
                CenterText.text = "日产车辆";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    float hs7 = int.Parse(InterfaceCenter.Instance.CarType[1].dayHQA1) / int.Parse(InterfaceCenter.Instance.CarType[2].dayHQA1);
                    HS7.FillAmount = hs7;
                }

                break;
            case times.week:
                this.gameObject.SetActive(true);
                CenterText.text = "周产车辆";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    if (InterfaceCenter.Instance.AllIsDone())
                    {
                        float hs7 = int.Parse(InterfaceCenter.Instance.CarType[1].weekHQA1) / int.Parse(InterfaceCenter.Instance.CarType[2].weekHQA1);
                        HS7.FillAmount = hs7;
                    }
                }
                break;
            case times.month:
                this.gameObject.SetActive(true);
                CenterText.text = "月产车辆";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    if (InterfaceCenter.Instance.AllIsDone())
                    {
                        float hs7 = int.Parse(InterfaceCenter.Instance.CarType[1].monthHQA1) / int.Parse(InterfaceCenter.Instance.CarType[2].monthHQA1);
                        HS7.FillAmount = hs7;
                    }
                }
                break;
            case times.year:
                this.gameObject.SetActive(true);
                CenterText.text = "年产车辆";
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    if (InterfaceCenter.Instance.AllIsDone())
                    {
                        float hs7 = int.Parse(InterfaceCenter.Instance.CarType[1].yearHQA1) / int.Parse(InterfaceCenter.Instance.CarType[2].yearHQA1);
                        HS7.FillAmount = hs7;
                    }
                }
                break;



        }


    }
 
}
