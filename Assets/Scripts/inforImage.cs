using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inforImage : MonoBehaviour
{
    public Image total;
    public Image shiji;
    public times timeimg=times.today;
    public Text text_total;
    public Text text_shiji;
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
        switch ((times)index)
        {

            case times.today:
                this.gameObject.SetActive(false);
               
                break;
            case times.week:
                this.gameObject.SetActive(true);
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    total.fillAmount = 1;
                    shiji.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].weekHQA8)/ int.Parse( InterfaceCenter.Instance.CarType[2].weekHQA1);
                    text_total.text = InterfaceCenter.Instance.CarType[2].weekHQA1;
                    text_shiji.text = InterfaceCenter.Instance.CarType[2].weekHQA8;
                }
                break;
            case times.month:
                this.gameObject.SetActive(true);
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    total.fillAmount = 1;
                    shiji.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].monthHQA8) / int.Parse(InterfaceCenter.Instance.CarType[2].monthHQA1);
                    text_total.text = InterfaceCenter.Instance.CarType[2].monthHQA1;
                    text_shiji.text = InterfaceCenter.Instance.CarType[2].monthHQA8;
                }
                break;
            case times.year:
                this.gameObject.SetActive(true);
                if (InterfaceCenter.Instance.AllIsDone())
                {
                    total.fillAmount = 1;
                    shiji.fillAmount = int.Parse(InterfaceCenter.Instance.CarType[2].yearHQA8) / int.Parse(InterfaceCenter.Instance.CarType[2].yearHQA1);
                    text_total.text = InterfaceCenter.Instance.CarType[2].yearHQA1;
                    text_shiji.text = InterfaceCenter.Instance.CarType[2].yearHQA8;
                }
                break;
          


        }
        

    }
}
