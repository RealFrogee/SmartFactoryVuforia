using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Xml;
using LitJson;
#region 第一个接口
[Serializable]
public class CAR
{
    public type[] ctype;
}
[Serializable]
public class type
{
    public string ctype;
    public string dayPlanHQA1;
    public string dayHQA1;
    public string dayHQA8;
    public string weekHQA1;
    public string weekHQA8;
    public string monthHQA1;
    public string monthHQA8;
    public string yearHQA1;
    public string yearHQA8;
}
#endregion
#region  第二个接口
[Serializable]
public class CAR_REPAIR
{
    public R_type[] Trepair;
}
[Serializable]
public class R_type
{
    public string repairing;
    public string repaired;
    public string overtime;
    public string daliyTotal;
    public string todayToRepair;
}
#endregion
#region  第三个接口
[Serializable]
public class CAR_DETAIL
{
    public R_detail[] Detail;
}
[Serializable]
public class R_detail
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
#endregion
#region  第四个接口
[Serializable]
public class CAR_DEVICE
{
    public R_Device[] Device;
}
[Serializable]
public class R_Device
{
    public string 报警码;
    public string 报警信息;
    public string 线体;
    public string 设备;
    public string 工位;
    public string 报警开始;
    public string 报警结束;
    public string 报警取消;
    public string 报警时长;
}
#endregion
#region  第五个接口
[Serializable]
public class CAR_TIMES
{
    public R_Times[] Times;
}
[Serializable]
public class R_Times
{
    public string 涂胶机;
    public string 机器人;
    public string 加注机;
    public string 车轮拧紧;
    public string 底盘;
}
#endregion

public class Testweb : SingletonMono<Testweb>
{
    public string testXml;
    #region 第一个接口
    [SerializeField]
    public string ctype;
    string n_ctype;
    public CAR result;
    #endregion
    #region 第二个接口
    public string repair;
    string n_repair;
    public CAR_REPAIR CAR_REPAIR;
    #endregion
    #region 第三个接口
    public string detail;
    string n_detail;
    public CAR_DETAIL CAR_DETAIL;
    #endregion
    #region 第四个接口
    public string device;
    string n_device;
    public CAR_DEVICE CAR_DEVICE;
    #endregion
    #region 第五个接口
    public string times;
    string n_times;
    public CAR_TIMES CAR_TIMES;
    #endregion
    #region 第六个接口
    [SerializeField]
    public string ctype_HS7;
    string n_ctype_HS7;
    public CAR result_HS7;
    #endregion

    public bool FirstIsDone = false;
    public bool SecondIsDone = false;
    public bool ThirdIsDone = false;
    public bool ForthIsDone = false;
    public bool FifthIsDone = false;
    public bool sixthIsDone = false;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        #region 第一个接口

        //if (ctype != null)
        //{
        //    n_ctype = "{\"ctype\": " + ctype + "}";
        //    result = JsonUtility.FromJson<CAR>(n_ctype);
        //    InterfaceCenter.Instance.CarType[0].ctype = result.ctype[0].ctype;
        //    InterfaceCenter.Instance.CarType[0].dayPlanHQA1 = result.ctype[0].dayPlanHQA1;
        //    InterfaceCenter.Instance.CarType[0].dayHQA1 = result.ctype[0].dayHQA1;
        //    InterfaceCenter.Instance.CarType[0].dayHQA8 = result.ctype[0].dayHQA8;
        //    InterfaceCenter.Instance.CarType[0].weekHQA1 = result.ctype[0].weekHQA1;
        //    InterfaceCenter.Instance.CarType[0].weekHQA8 = result.ctype[0].weekHQA8;
        //    InterfaceCenter.Instance.CarType[0].monthHQA1 = result.ctype[0].monthHQA1;
        //    InterfaceCenter.Instance.CarType[0].monthHQA8 = result.ctype[0].monthHQA8;
        //    InterfaceCenter.Instance.CarType[0].yearHQA1 = result.ctype[0].yearHQA1;
        //    InterfaceCenter.Instance.CarType[0].yearHQA8 = result.ctype[0].yearHQA8;

        //}
        #endregion
        #region 第二个接口
        //if (repair != null)
        //{
        //    n_repair = "{\"Trepair\": " + repair + "}";
        //    CAR_REPAIR = JsonUtility.FromJson<CAR_REPAIR>(n_repair);
        //    InterfaceCenter.Instance.repairing = CAR_REPAIR.Trepair[0].repairing;
        //    InterfaceCenter.Instance.repaired = CAR_REPAIR.Trepair[0].repaired;
        //    InterfaceCenter.Instance.overtime = CAR_REPAIR.Trepair[0].overtime;
        //    InterfaceCenter.Instance.daliyTotal = CAR_REPAIR.Trepair[0].daliyTotal;
        //    InterfaceCenter.Instance.todayToRepair = CAR_REPAIR.Trepair[0].todayToRepair;
        //}
        #endregion
        #region 第三个接口
        //if (detail != null)
        //{
        //    n_detail = "{\"Detail\": " + detail + "}";
        //    CAR_DETAIL = JsonUtility.FromJson<CAR_DETAIL>(n_detail);
        //    int num;
        //    num = CAR_DETAIL.Detail.Length;
        //    InterfaceCenter.Instance.detailInfo = new DetailInfo[num];

        //    for (int i = 0; i < num; i++)
        //    {

        //        InterfaceCenter.Instance.detailInfo[i].VIN = CAR_DETAIL.Detail[i].VIN;
        //        InterfaceCenter.Instance.detailInfo[i].enterTime = CAR_DETAIL.Detail[i].enterTime;
        //        InterfaceCenter.Instance.detailInfo[i].ParkingSpace = CAR_DETAIL.Detail[i].ParkingSpace;
        //        InterfaceCenter.Instance.detailInfo[i].Duration = CAR_DETAIL.Detail[i].Duration;
        //        InterfaceCenter.Instance.detailInfo[i].Seconds = CAR_DETAIL.Detail[i].Seconds;
        //        InterfaceCenter.Instance.detailInfo[i].status = CAR_DETAIL.Detail[i].status;
        //        InterfaceCenter.Instance.detailInfo[i].repairMan = CAR_DETAIL.Detail[i].repairMan;
        //        InterfaceCenter.Instance.detailInfo[i].bulMod = CAR_DETAIL.Detail[i].bulMod;

        //    }

        //}
        #endregion
        #region 第四个接口
        //if (device != null)
        //{
        //    device = "{\"Device\": " + device + "}";
        //    CAR_DEVICE = JsonUtility.FromJson<CAR_DEVICE>(device);
        //    InterfaceCenter.Instance.报警码 = CAR_DEVICE.Device[0].报警码;
        //    InterfaceCenter.Instance.报警信息 = CAR_DEVICE.Device[0].报警信息;
        //    InterfaceCenter.Instance.线体 = CAR_DEVICE.Device[0].线体;
        //    InterfaceCenter.Instance.设备 = CAR_DEVICE.Device[0].设备;
        //    InterfaceCenter.Instance.工位 = CAR_DEVICE.Device[0].工位;
        //    InterfaceCenter.Instance.报警开始 = CAR_DEVICE.Device[0].报警开始;
        //    InterfaceCenter.Instance.报警结束 = CAR_DEVICE.Device[0].报警结束;
        //    InterfaceCenter.Instance.报警取消 = CAR_DEVICE.Device[0].报警取消;
        //    InterfaceCenter.Instance.报警时长 = CAR_DEVICE.Device[0].报警时长;
        //}
        #endregion
        #region 第五个接口
        //if (times != null)
        //{
        //    n_times = "{\"Times\": " + times + "}";
        //    CAR_TIMES = JsonUtility.FromJson<CAR_TIMES>(n_times);
        //    InterfaceCenter.Instance.涂胶机 = CAR_TIMES.Times[0].涂胶机;
        //    InterfaceCenter.Instance.机器人 = CAR_TIMES.Times[0].机器人;
        //    InterfaceCenter.Instance.加注机 = CAR_TIMES.Times[0].加注机;
        //    InterfaceCenter.Instance.车轮拧紧 = CAR_TIMES.Times[0].车轮拧紧;
        //    InterfaceCenter.Instance.底盘 = CAR_TIMES.Times[0].底盘;
        //}
        #endregion
        #region 第六个接口

        //if (ctype_HS7 != null)
        //{
        //    n_ctype_HS7 = "{\"ctype\": " + ctype_HS7 + "}";
        //    result_HS7 = JsonUtility.FromJson<CAR>(n_ctype_HS7);
        //    InterfaceCenter.Instance.CarType[1].ctype = result_HS7.ctype[0].ctype;
        //    InterfaceCenter.Instance.CarType[1].dayPlanHQA1 = result_HS7.ctype[0].dayPlanHQA1;
        //    InterfaceCenter.Instance.CarType[1].dayHQA1 = result_HS7.ctype[0].dayHQA1;
        //    InterfaceCenter.Instance.CarType[1].dayHQA8 = result_HS7.ctype[0].dayHQA8;
        //    InterfaceCenter.Instance.CarType[1].weekHQA1 = result_HS7.ctype[0].weekHQA1;
        //    InterfaceCenter.Instance.CarType[1].weekHQA8 = result_HS7.ctype[0].weekHQA8;
        //    InterfaceCenter.Instance.CarType[1].monthHQA1 = result_HS7.ctype[0].monthHQA1;
        //    InterfaceCenter.Instance.CarType[1].monthHQA8 = result_HS7.ctype[0].monthHQA8;
        //    InterfaceCenter.Instance.CarType[1].yearHQA1 = result_HS7.ctype[0].yearHQA1;
        //    InterfaceCenter.Instance.CarType[1].yearHQA8 = result_HS7.ctype[0].yearHQA8;

        //}
        #endregion
        InvokeRepeating("GetAll", 0, 30);

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region 开启获取接口

    public void GetCtype()
    {
        StartCoroutine(Request1(ctype));
    }
    public void GetRepair()
    {
        StartCoroutine(Request2(repair));
    }
    public void GetDetail()
    {
        StartCoroutine(Request3(detail));
    }


    public void GetTimes()
    {
        StartCoroutine(Request5(times));
    }
    public void StartRequest6()
    {
        // StartCoroutine(Request6_HS7(ctype_HS7));
        StartCoroutine(Request6_HS7(ctype));
    }
    public void startget()
    {
        StartCoroutine(gettype());
    }
    public void GetAll()
    {
        GetCtype();
        GetRepair();
        GetDetail();
        GetTimes();
        StartRequest6();
        startget();


    }
    #endregion
    IEnumerator Request1(string ctype)
    {

     

        WWW getdata = new WWW(ctype);
        yield return getdata;
        if (getdata.error != null)
        {
            Debug.Log(getdata.error);
        }
        else
        {
            Debug.Log(getdata.text);
            XmlDocument xmlDoc = new XmlDocument();
         
            xmlDoc.LoadXml(getdata.text);
           
            string s = xmlDoc.LastChild.InnerText;
            string p = s.Replace("[", "").Replace("]", "");
            CarType cty = JsonMapper.ToObject<CarType>(p);
            InterfaceCenter.Instance.CarType[0] = cty;
            Debug.Log(InterfaceCenter.Instance.CarType[0].ctype);
            FirstIsDone = true;

        }
        //   UnityWebRequest  www = new UnityWebRequest(ctype);
        //   www = UnityWebRequest.Get(ctype);
        //   FirstIsDone = false;
        //   yield return www;
        //   Debug.Log("ok");
        //   while (!www.isDone)
        //   {
        //       //Debug.Log("??");
        //       yield return new WaitForEndOfFrame();
        //
        //   }
        //   if (www.error == null)
        //   {
        //       Debug.Log("??");
        //       n_ctype = "{\"ctype\": " + ctype + "}";
        //       result = JsonUtility.FromJson<CAR>(n_ctype);
        //       InterfaceCenter.Instance.CarType[0].ctype = result.ctype[0].ctype;
        //       InterfaceCenter.Instance.CarType[0].dayPlanHQA1 = result.ctype[0].dayPlanHQA1;
        //       InterfaceCenter.Instance.CarType[0].dayHQA1 = result.ctype[0].dayHQA1;
        //       InterfaceCenter.Instance.CarType[0].dayHQA8 = result.ctype[0].dayHQA8;
        //       InterfaceCenter.Instance.CarType[0].weekHQA1 = result.ctype[0].weekHQA1;
        //       InterfaceCenter.Instance.CarType[0].weekHQA8 = result.ctype[0].weekHQA8;
        //       InterfaceCenter.Instance.CarType[0].monthHQA1 = result.ctype[0].monthHQA1;
        //       InterfaceCenter.Instance.CarType[0].monthHQA8 = result.ctype[0].monthHQA8;
        //       InterfaceCenter.Instance.CarType[0].yearHQA1 = result.ctype[0].yearHQA1;
        //       InterfaceCenter.Instance.CarType[0].yearHQA8 = result.ctype[0].yearHQA8;
        //       FirstIsDone = true;
        //
        //       Debug.Log(n_ctype);
        //
        //   }
        //   else
        //   {
        //       Debug.Log("地址有误");
        //   }
    }
    IEnumerator Request2(string repair)
    {
        WWW getdata = new WWW(repair);
        yield return getdata;
        if (getdata.error != null)
        {
            Debug.Log(getdata.error);
        }
        else
        {
            Debug.Log(getdata.text);
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(getdata.text);
            string s = xmlDoc.LastChild.InnerText;
            string p = s.Replace("[", "").Replace("]", "");
            R_type temp = JsonMapper.ToObject<R_type>(p);
            CAR_REPAIR.Trepair = new R_type[1];
            CAR_REPAIR.Trepair[0] = temp;
            InterfaceCenter.Instance.repairing = CAR_REPAIR.Trepair[0].repairing;
            InterfaceCenter.Instance.repaired = CAR_REPAIR.Trepair[0].repaired;
            InterfaceCenter.Instance.overtime = CAR_REPAIR.Trepair[0].overtime;
            InterfaceCenter.Instance.daliyTotal = CAR_REPAIR.Trepair[0].daliyTotal;
            InterfaceCenter.Instance.todayToRepair = CAR_REPAIR.Trepair[0].todayToRepair;
            Debug.Log(InterfaceCenter.Instance.repairing);
            SecondIsDone = true;
        }
        //   UnityWebRequest www = new UnityWebRequest(repair);
        //   www = UnityWebRequest.Get(repair);
        //   SecondIsDone = false;
        //   yield return www;
        //   while (!www.isDone)
        //   {
        //       yield return new WaitForEndOfFrame();
        //
        //   }
        //   if (www.error == null)
        //   {
        //       n_repair = "{\"Trepair\": " + www.downloadHandler.text + "}";
        //       CAR_REPAIR = JsonUtility.FromJson<CAR_REPAIR>(n_repair);
        //       InterfaceCenter.Instance.repairing     =      CAR_REPAIR.Trepair[0].repairing;
        //       InterfaceCenter.Instance.repaired      =      CAR_REPAIR.Trepair[0].repaired;
        //       InterfaceCenter.Instance.overtime      =      CAR_REPAIR.Trepair[0].overtime;
        //       InterfaceCenter.Instance.daliyTotal    =      CAR_REPAIR.Trepair[0].daliyTotal;
        //       InterfaceCenter.Instance.todayToRepair =      CAR_REPAIR.Trepair[0].todayToRepair;
        //       SecondIsDone = true;
        //
        //   }
        //   else
        //   {
        //       Debug.Log("地址有误");
        //   }
    }
    IEnumerator Request3(string detail)
    {
        WWW getdata = new WWW(detail);
        yield return getdata;
        if (getdata.error != null)
        {
            Debug.Log(getdata.error);
        }
        else
        {
            Debug.Log(getdata.text);
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(getdata.text);
            string s = xmlDoc.LastChild.InnerText;
            //string p = s.Replace("[", "").Replace("]", "");
            JsonData pa = JsonMapper.ToObject(s);
            CAR_DETAIL.Detail = new R_detail[pa.Count];
            for (int i = 0; i < pa.Count; i++)
            {
                R_detail temp = new R_detail();
                temp.VIN = pa[i]["VIN"].ToString();
                temp.enterTime = pa[i]["enterTime"].ToString();
                temp.ParkingSpace = pa[i]["ParkingSpace"].ToString();
               temp.Duration = pa[i]["Duration"].ToString();
                temp.Seconds = pa[i]["Seconds"].ToString();
                temp.status = pa[i]["status"].ToString();
                temp.repairMan = pa[i]["repairMan"].ToString();
               temp.bulMod = pa[i]["bulMod"].ToString();
                CAR_DETAIL.Detail[i] = temp;
                // CAR_DETAIL.Detail[i].VIN = pa[i]["VIN"].ToString();
                // CAR_DETAIL.Detail[i].enterTime = pa[i]["enterTime"].ToString();
                // CAR_DETAIL.Detail[i].ParkingSpace = pa[i]["ParkingSpace"].ToString();
                // CAR_DETAIL.Detail[i].Duration = pa[i]["Duration"].ToString();
                // CAR_DETAIL.Detail[i].Seconds = pa[i]["Seconds"].ToString();
                // CAR_DETAIL.Detail[i].status = pa[i]["status"].ToString();
                // CAR_DETAIL.Detail[i].repairMan = pa[i]["repairMan"].ToString();
                // CAR_DETAIL.Detail[i].bulMod = pa[i]["bulMod"].ToString();
                Debug.Log(temp.VIN);
                
            }
            InterfaceCenter.Instance.detailInfo = new DetailInfo[pa.Count];
              for (int i=0;i< pa.Count; i++)
              {
            
                      InterfaceCenter.Instance.detailInfo[i].VIN           =CAR_DETAIL.Detail[i].VIN           ;
                      InterfaceCenter.Instance.detailInfo[i].enterTime     =CAR_DETAIL.Detail[i].enterTime     ;
                      InterfaceCenter.Instance.detailInfo[i].ParkingSpace  =CAR_DETAIL.Detail[i].ParkingSpace  ;
                      InterfaceCenter.Instance.detailInfo[i].Duration      =CAR_DETAIL.Detail[i].Duration      ;
                      InterfaceCenter.Instance.detailInfo[i].Seconds       =CAR_DETAIL.Detail[i].Seconds       ;
                      InterfaceCenter.Instance.detailInfo[i].status        =CAR_DETAIL.Detail[i].status        ;
                      InterfaceCenter.Instance.detailInfo[i].repairMan     =CAR_DETAIL.Detail[i].repairMan     ;
                      InterfaceCenter.Instance.detailInfo[i].bulMod        =CAR_DETAIL.Detail[i].bulMod        ;
            
              }
            ThirdIsDone = true;


        }
        //UnityWebRequest www = new UnityWebRequest(detail);
        //www = UnityWebRequest.Get(detail);
        //ThirdIsDone = false;
        //yield return www;
        //while (!www.isDone)
        //{
        //    yield return new WaitForEndOfFrame();

        //}
        //if (www.error == null)
        //{
        //    n_detail = "{\"Detail\": " + www.downloadHandler.text + "}";
        //    CAR_DETAIL = JsonUtility.FromJson<CAR_DETAIL>(n_detail);
        //    int num;
        //    num = CAR_DETAIL.Detail.Length;
        //    InterfaceCenter.Instance.detailInfo = new DetailInfo[num];
        //    for (int i=0;i<num;i++)
        //    {

        //            InterfaceCenter.Instance.detailInfo[i].VIN           =CAR_DETAIL.Detail[i].VIN           ;
        //            InterfaceCenter.Instance.detailInfo[i].enterTime     =CAR_DETAIL.Detail[i].enterTime     ;
        //            InterfaceCenter.Instance.detailInfo[i].ParkingSpace  =CAR_DETAIL.Detail[i].ParkingSpace  ;
        //            InterfaceCenter.Instance.detailInfo[i].Duration      =CAR_DETAIL.Detail[i].Duration      ;
        //            InterfaceCenter.Instance.detailInfo[i].Seconds       =CAR_DETAIL.Detail[i].Seconds       ;
        //            InterfaceCenter.Instance.detailInfo[i].status        =CAR_DETAIL.Detail[i].status        ;
        //            InterfaceCenter.Instance.detailInfo[i].repairMan     =CAR_DETAIL.Detail[i].repairMan     ;
        //            InterfaceCenter.Instance.detailInfo[i].bulMod        =CAR_DETAIL.Detail[i].bulMod        ;

        //    }                                              
        //    ThirdIsDone = true;                            
        //}                                                      
        //else
        //{
        //    Debug.Log("地址有误");
        //}
    }
    public IEnumerator Request4(string device, Transform trans)
    {
        UnityWebRequest www = new UnityWebRequest(device);
        UIScript uIScript = trans.GetComponent<UIScript>();
        www = UnityWebRequest.Get(device);
        ForthIsDone = false;
        yield return www;
        while (!www.isDone)
        {
            yield return new WaitForEndOfFrame();

        }
        if (www.error == null)
        {
            n_device = "{\"Device\": " + www.downloadHandler.text + "}";
            CAR_DEVICE = JsonUtility.FromJson<CAR_DEVICE>(n_device);
            uIScript.报警码 = CAR_DEVICE.Device[0].报警码;
            uIScript.报警信息 = CAR_DEVICE.Device[0].报警信息;
            uIScript.线体 = CAR_DEVICE.Device[0].线体;
            uIScript.设备 = CAR_DEVICE.Device[0].设备;
            uIScript.工位 = CAR_DEVICE.Device[0].工位;
            uIScript.报警开始 = CAR_DEVICE.Device[0].报警开始;
            uIScript.报警结束 = CAR_DEVICE.Device[0].报警结束;
            uIScript.报警取消 = CAR_DEVICE.Device[0].报警取消;
            uIScript.报警时长 = CAR_DEVICE.Device[0].报警时长;

            ForthIsDone = true;
        }
        else
        {
            Debug.Log("地址有误");
        }
    }
    IEnumerator Request5(string times)
    {
        WWW getdata = new WWW(times);
        yield return getdata;
        if (getdata.error != null)
        {
            Debug.Log(getdata.error);
        }
        else
        {
            Debug.Log(getdata.text);
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(getdata.text);
            string s = xmlDoc.LastChild.InnerText;
            string p = s.Replace("[", "").Replace("]", "");
            R_Times cty = JsonMapper.ToObject<R_Times>(p);
            CAR_TIMES.Times = new R_Times[1];
            CAR_TIMES.Times[0] = cty;
                 InterfaceCenter.Instance.涂胶机 = CAR_TIMES.Times[0].涂胶机;
                 InterfaceCenter.Instance.机器人 = CAR_TIMES.Times[0].机器人;
                 InterfaceCenter.Instance.加注机 = CAR_TIMES.Times[0].加注机;
                 InterfaceCenter.Instance.车轮拧紧 = CAR_TIMES.Times[0].车轮拧紧;
                 InterfaceCenter.Instance.底盘 = CAR_TIMES.Times[0].底盘;
            Debug.Log(InterfaceCenter.Instance.底盘 = CAR_TIMES.Times[0].底盘);
            FifthIsDone = true;

        }
        //   UnityWebRequest www = new UnityWebRequest(times);
        //   www = UnityWebRequest.Get(times);
        //   FifthIsDone = false;
        //   yield return www;
        //   while (!www.isDone)
        //   {
        //       yield return new WaitForEndOfFrame();
        //
        //   }
        //   if (www.error == null)
        //   {
        //       n_times = "{\"Times\": " + www.downloadHandler.text + "}";
        //       CAR_TIMES = JsonUtility.FromJson<CAR_TIMES>(n_times);
        //       InterfaceCenter.Instance.涂胶机 = CAR_TIMES.Times[0].涂胶机;
        //       InterfaceCenter.Instance.机器人 = CAR_TIMES.Times[0].机器人;
        //       InterfaceCenter.Instance.加注机 = CAR_TIMES.Times[0].加注机;
        //       InterfaceCenter.Instance.车轮拧紧 = CAR_TIMES.Times[0].车轮拧紧;
        //       InterfaceCenter.Instance.底盘 = CAR_TIMES.Times[0].底盘;
        //
        //       FifthIsDone = true;
        //   }
        //   else
        //   {
        //       Debug.Log("地址有误");
        //   }
    }
    IEnumerator Request6_HS7(string ctype)
    {
        WWW getdata = new WWW(ctype);
        yield return getdata;
        if (getdata.error != null)
        {
            Debug.Log(getdata.error);
        }
        else
        {
            Debug.Log(getdata.text);
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(getdata.text);
            string s = xmlDoc.LastChild.InnerText;
            string p = s.Replace("[", "").Replace("]", "");
            CarType cty = JsonMapper.ToObject<CarType>(p);
            InterfaceCenter.Instance.CarType[1] = cty;
            Debug.Log(cty.ctype);
            sixthIsDone = true;

        }
        //  UnityWebRequest www = new UnityWebRequest(ctype_HS7);
        //  www = UnityWebRequest.Get(ctype_HS7);
        //  sixthIsDone = false;
        //  yield return www;
        //  while (!www.isDone)
        //  {
        //      yield return new WaitForEndOfFrame();
        //
        //  }
        //  if (www.error == null)
        //  {
        //      n_ctype_HS7 = "{\"ctype\": " + ctype_HS7 + "}";
        //      result_HS7 = JsonUtility.FromJson<CAR>(n_ctype_HS7);
        //      InterfaceCenter.Instance.CarType[1].ctype = result_HS7.ctype[0].ctype;
        //      InterfaceCenter.Instance.CarType[1].dayPlanHQA1 = result_HS7.ctype[0].dayPlanHQA1;
        //      InterfaceCenter.Instance.CarType[1].dayHQA1 = result_HS7.ctype[0].dayHQA1;
        //      InterfaceCenter.Instance.CarType[1].dayHQA8 = result_HS7.ctype[0].dayHQA8;
        //      InterfaceCenter.Instance.CarType[1].weekHQA1 = result_HS7.ctype[0].weekHQA1;
        //      InterfaceCenter.Instance.CarType[1].weekHQA8 = result_HS7.ctype[0].weekHQA8;
        //      InterfaceCenter.Instance.CarType[1].monthHQA1 = result_HS7.ctype[0].monthHQA1;
        //      InterfaceCenter.Instance.CarType[1].monthHQA8 = result_HS7.ctype[0].monthHQA8;
        //      InterfaceCenter.Instance.CarType[1].yearHQA1 = result_HS7.ctype[0].yearHQA1;
        //      InterfaceCenter.Instance.CarType[1].yearHQA8 = result_HS7.ctype[0].yearHQA8;
        //
        //
        //      sixthIsDone = true;
        //
        //  }
        //  else
        //  {
        //      Debug.Log("地址有误");
        //  }
    }
    public IEnumerator gettype()
    {
        while (!AllReady())
        {
            yield return new WaitForSeconds(0.25f);
        }

        InterfaceCenter.Instance.CarType[2].dayPlanHQA1 = (int.Parse(InterfaceCenter.Instance.CarType[0].dayPlanHQA1) + int.Parse(InterfaceCenter.Instance.CarType[1].dayPlanHQA1)).ToString();
        InterfaceCenter.Instance.CarType[2].dayHQA1 = (int.Parse(InterfaceCenter.Instance.CarType[0].dayHQA1) + int.Parse(InterfaceCenter.Instance.CarType[1].dayHQA1)).ToString();
        InterfaceCenter.Instance.CarType[2].dayHQA8 = (int.Parse(InterfaceCenter.Instance.CarType[0].dayHQA8) + int.Parse(InterfaceCenter.Instance.CarType[1].dayHQA8)).ToString();
        InterfaceCenter.Instance.CarType[2].weekHQA1 = (int.Parse(InterfaceCenter.Instance.CarType[0].weekHQA1) + int.Parse(InterfaceCenter.Instance.CarType[1].weekHQA1)).ToString();
        InterfaceCenter.Instance.CarType[2].weekHQA8 = (int.Parse(InterfaceCenter.Instance.CarType[0].weekHQA8) + int.Parse(InterfaceCenter.Instance.CarType[1].weekHQA8)).ToString();
        InterfaceCenter.Instance.CarType[2].monthHQA1 = (int.Parse(InterfaceCenter.Instance.CarType[0].monthHQA1) + int.Parse(InterfaceCenter.Instance.CarType[1].monthHQA1)).ToString();
        InterfaceCenter.Instance.CarType[2].monthHQA8 = (int.Parse(InterfaceCenter.Instance.CarType[0].monthHQA8) + int.Parse(InterfaceCenter.Instance.CarType[1].monthHQA8)).ToString();
        InterfaceCenter.Instance.CarType[2].yearHQA1 = (int.Parse(InterfaceCenter.Instance.CarType[0].yearHQA1) + int.Parse(InterfaceCenter.Instance.CarType[1].yearHQA1)).ToString();
        InterfaceCenter.Instance.CarType[2].yearHQA8 = InterfaceCenter.Instance.CarType[0].yearHQA8 + InterfaceCenter.Instance.CarType[1].yearHQA8;


    }
    public bool AllReady()
    {
        if (FirstIsDone && SecondIsDone && ThirdIsDone && FifthIsDone && sixthIsDone)
        {
            return true;
        }
        return false;
    }
}
