using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum Inter_type
{
    ctype,
    dayPlanHQA1,
    dayHQA1,
    dayHQA8,
    weekHQA1,
    weekHQA8,
    monthHQA1,
    monthHQA8,
    yearHQA1,
    yearHQA8,
    repairing,
    repaired,
    overtime,
    daliyTotal,
    todayToRepair,
    VIN,
    enterTime,
    ParkingSpace,
    Duration,
    Seconds,
    status,
    repairMan,
    bulMod,
    报警码,
    报警信息,
    线体,
    设备,
    工位,
    报警开始,
    报警结束,
    报警取消,
    报警时长,
    涂胶机,
    机器人,
    加注机,
    车轮拧紧,
    底盘,
}

public struct DetailInfo
{
    public string VIN;
    public string enterTime;
    public string ParkingSpace;
    public string Duration;
    public string Seconds;
    public string status;
    public string repairMan;
    public string bulMod;     
}
public struct CarType
{

    public string ctype         ;
    public string dayPlanHQA1   ;
    public string dayHQA1       ;
    public string dayHQA8       ;
    public string weekHQA1      ;
    public string weekHQA8      ;
    public string monthHQA1     ;
    public string monthHQA8     ;
    public string yearHQA1      ;
    public string yearHQA8      ;
}


public class InterfaceCenter : SingletonMono<InterfaceCenter>
{
    private Inter_type inter_Type;
    public Inter_type Inter_Type
    {
        get { return inter_Type; }
        set {inter_Type=value; }
    }

    public CarType[] CarType = new CarType[3];
    public string repairing   ;
    public string repaired     ;
    public string overtime      ;
    public string daliyTotal    ;
    public string todayToRepair ;
    public DetailInfo[] detailInfo;
    public string 报警码      ;
    public string 报警信息      ;
    public string 线体          ;
    public string 设备         ;
    public string 工位         ;
    public string 报警开始      ;
    public string 报警结束     ;
    public string 报警取消     ;
    public string 报警时长      ;
    public string 涂胶机       ;
    public string 机器人        ;
    public string 加注机        ;
    public string 车轮拧紧     ;
    public string 底盘         ;
    public string Car_total;
    public bool CanSetInter;


    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {

        
        Testweb.Instance.GetAll();


    }
  
    // Update is called once per frame
    void Update()
    {
        
    }

    #region
    public bool FirstInter(Inter_type inter)
    {
       if(
             inter==Inter_type.ctype||
             inter==Inter_type.dayPlanHQA1||
             inter==Inter_type.dayHQA1||
             inter==Inter_type.dayHQA8||
             inter==Inter_type.weekHQA1||
             inter==Inter_type.weekHQA8||
             inter==Inter_type.monthHQA1||
             inter==Inter_type.monthHQA8||
             inter==Inter_type.yearHQA1||
             inter == Inter_type.yearHQA8
             )
        {
            return true;
        }
        return false;
    }

    public int Repair_status(string status)
    {
        if(status.Equals("返修中"))
        {
            return -2;
        }
        if (status.Equals("返修超时"))
        {
            return 2;
        }
        print(status);
        return 0;
    }
    public bool SecondInter(Inter_type inter)
    {
        if (
         inter == Inter_type.repairing||
        inter == Inter_type.repaired ||
         inter == Inter_type.overtime||
         inter == Inter_type.daliyTotal||
         inter == Inter_type.todayToRepair
         )
        {
            return true;
        }
        return false;
    }
    public bool ThirdInter(Inter_type inter)
    {
        if (
      inter == Inter_type.VIN||
        inter == Inter_type.enterTime ||
      inter == Inter_type.ParkingSpace||
      inter == Inter_type.Duration||
      inter == Inter_type.Seconds||
      inter == Inter_type.status ||
      inter == Inter_type.repairMan||
      inter == Inter_type.bulMod 
  
      )
        {
            return true;
        }
        return false;
    }
    public bool ForthInter(Inter_type inter)
    {
        if (
      inter == Inter_type.报警码 ||
      inter == Inter_type.报警信息||
      inter == Inter_type.线体 ||
      inter == Inter_type.设备 ||
      inter == Inter_type.工位 ||
      inter == Inter_type.报警开始 ||
      inter == Inter_type.报警结束 ||
      inter == Inter_type.报警取消||
      inter == Inter_type.报警时长
      )
        {
            return true;
        }
        return false;
    }
    public bool FifthInter(Inter_type inter)
    {
        if (
         inter == Inter_type.涂胶机|
         inter == Inter_type.机器人 ||
         inter == Inter_type.加注机||
         inter == Inter_type.车轮拧紧||
         inter == Inter_type.底盘 
         )
        {
            return true;
        }
        return false;
    }
       IEnumerator  IsDone()
      {
        if(Testweb.Instance.AllReady())
        {
            CanSetInter = true;
        }
        else
        {
            CanSetInter = false;
            yield return new WaitForSeconds(0.25f);
        }
        
    }
    public bool AllIsDone()
    {
        if(Testweb.Instance.AllReady())
        {
            return true;
        }
        return false;
    }
    void StartAllInter()
    {
        Testweb.Instance.GetAll();
        StartCoroutine(IsDone());
    }
    #endregion

    /// <summary>
    /// 调用一次刷新一次
    /// </summary>
    /// <param name="inter"></param>
    /// <returns></returns>
    IEnumerator StartGetInformation(Inter_type inter)
    {
        if(FirstInter(inter))
        {
            Testweb.Instance.GetCtype();
            if(Testweb.Instance.FirstIsDone)
            {
                //此处写入数据逻辑
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }
        }
        else if(SecondInter(inter))
        {
            Testweb.Instance.GetRepair();
            if (Testweb.Instance.SecondIsDone)
            {
                //此处写入数据逻辑
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }
        }
        else if(ThirdInter(inter))
        {
            Testweb.Instance.GetDetail();
            if (Testweb.Instance.ThirdIsDone)
            {
                //此处写入数据逻辑
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }
        }

        else if (FifthInter(inter))
        {
            Testweb.Instance.GetTimes();
            if (Testweb.Instance.FifthIsDone)
            {
                //此处写入数据逻辑
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }
        }
        else if (FifthInter(inter))
        {
            Testweb.Instance.GetTimes();
            if (Testweb.Instance.FifthIsDone)
            {
                //此处写入数据逻辑
            }
            else
            {
                yield return new WaitForSeconds(0.25f);
            }
        }



    }
    
}
