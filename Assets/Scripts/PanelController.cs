using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum times
{
    today,
    week,
    month,
    year,
}
public enum panel
{
    HFactory,
    Alarm,
    repair

}

public class PanelController : SingletonMono<PanelController>
{
    public GameObject handMenu;
    public GameObject[] AllPanel;
   public Text 计划产量;
   public Text 返修总量;
   public Text 返修完成;
   public Text 实际产量;
   public Text 返修在线;
    public GameObject[] Todays;
    public GameObject[] ElseGm;
    public Text jihuachanliang;
    public Text rijihua;
    public Text rukuliang;


    int dailyTotal          ;
    int repaired    ;
    int dayhqa1     ;
    int dayplanhqa1;
    int RepairTotal;
   public Image Bunch_实际产量;
   public Image Bunch_返修量;
    private times times;
    public void showPanel(int index)
    {
        panel panel=(panel)index;
        switch (panel)
        {
            case panel.Alarm:
                
                foreach (GameObject a in AllPanel)
                {
                    if (a.name != "Cur_Alarm")
                        a.gameObject.SetActive(false);
                    else
                    {
                        a.gameObject.SetActive(true);
                    }
                }
                break;

            case panel.HFactory:
                handMenu.SetActive(false);
                foreach (GameObject a in AllPanel)
                {
                    if (a.name != "H-Factory")
                        a.gameObject.SetActive(false);
                    else
                    {
                        a.gameObject.SetActive(true);
                    }
                }
                break;
            case panel.repair:
                handMenu.SetActive(true);
                foreach (GameObject a in AllPanel)
                {
                    if (a.name != "H_repair")
                        a.gameObject.SetActive(false);
                    else
                    {
                        a.gameObject.SetActive(true);
                    }
                }
                break;
        }


    }

    public List<GameObject> listpanel=new List<GameObject>();
    GameObject Cur_Alarm;
    GameObject H_repair;
    float chaoshi;
    float zhengchang;
    float wancheng;
    public DrawSquald 返修超时squald;
    public DrawSquald 返修正常squald;
    public DrawSquald 返修完成squald;

    protected override void  Awake()
    {
        base.Awake();

    }
    void Start()
    {
        listpanel.Clear();
          int.TryParse(InterfaceCenter.Instance.daliyTotal, out dailyTotal );
          int.TryParse(InterfaceCenter.Instance.repaired , out repaired);
          int.TryParse(InterfaceCenter.Instance.CarType[0].dayHQA1,     out dayhqa1    );
          int.TryParse(InterfaceCenter.Instance.CarType[0].dayPlanHQA1,out dayplanhqa1);
          int.TryParse(InterfaceCenter.Instance.daliyTotal,out RepairTotal );

        Cur_Alarm = Utils.Utility.findChild(transform, "Cur_Alarm").gameObject;
        H_repair = Utils.Utility.findChild(transform, "H_repair").gameObject;
        
        listpanel.Add(Cur_Alarm);
        listpanel.Add(H_repair);

 
      

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        setPanel();
    }

    // Update is called once per frame
    void Update()
    {

        if (InterfaceCenter.Instance.AllIsDone())
        {
            setPanel();
        }


    }
    public void setPanel()
    {
        计划产量.text = int.Parse(InterfaceCenter.Instance.CarType[0].dayPlanHQA1 + InterfaceCenter.Instance.CarType[1].dayPlanHQA1).ToString();
        返修总量.text = InterfaceCenter.Instance.daliyTotal;
        返修完成.text = InterfaceCenter.Instance.repaired;
        实际产量.text = int.Parse(InterfaceCenter.Instance.CarType[0].dayHQA1 + InterfaceCenter.Instance.CarType[1].dayHQA1).ToString();
        返修在线.text = InterfaceCenter.Instance.repairing;
        if (dayplanhqa1 != 0)
        {
            Bunch_实际产量.fillAmount = dayhqa1 / dayplanhqa1;
        }
        else
        {
            Bunch_实际产量.fillAmount = 0;
        }
        if (dailyTotal != 0)
        {
            Bunch_返修量.fillAmount = repaired / dailyTotal;
        }
        else
        {
            Bunch_返修量.fillAmount = 0;
        }
        if (RepairTotal != 0)
        {
            chaoshi = 1;
        }
        else
        {
            chaoshi = 0;
        }
        if (RepairTotal != 0)
        {
            int temp;
            if (int.TryParse(InterfaceCenter.Instance.repaired, out temp))
            {
                zhengchang = 1 - (temp / RepairTotal);
            }

        }
        else
        {
            zhengchang = 0;
        }
        if (RepairTotal != 0)
        {
            int temp;
            if (int.TryParse(InterfaceCenter.Instance.repaired, out temp))
            {
                wancheng = temp / RepairTotal;
            }
        }
        else
        {
            wancheng = 0;
        }
        返修超时squald.FillAmount = chaoshi;
        返修正常squald.FillAmount = zhengchang;
        返修完成squald.FillAmount = wancheng;


       
    }
    public void SayOk()
    {
        print("ok");
    }

}
