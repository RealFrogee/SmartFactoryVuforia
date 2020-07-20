using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using LitJson;



public struct Ctype
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
public struct Repair
{
    public string repairing;
    public string repaired;
    public string overtime;
    public string daliyTotal;
    public string todayToRepair;
}

public struct Detail
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

public struct Device
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

public struct Times
{
    public string 涂胶机;
    public string 机器人;
    public string 加注机;
    public string 车轮拧紧;
    public string 底盘;
}




public class InterfaceDataController : MonoBehaviour
{
    public static InterfaceDataController Instance;
    public Ctype[] totalCtype;
    public Ctype ctype_hs5;
    public Ctype ctype_hs7;
    public Repair repair;
    public Detail[] detail;
    public Times times;
    public Dictionary<string,Device> deviceDic=new Dictionary<string, Device>();
    
    public string[] devNames;
    public string urlTotalCtype;
    public string urlCtypeHs5;
    public string urlCtypeHs7;
    public string urlRepair;
    public string urlDetail;
    public string urlTimes;
    
    public string urlDevice;

    public string testCtypeJson;
  public  string testDetailJson;
    public string testDevJson;
    // Start is called before the first frame update
    void Start()
    {
     //   StartCoroutine(LoadCtypeHS5(urlCtypeHs5));
        StartCoroutine(LoadTimes(urlTimes));
   //     StartCoroutine(LoadCtypeHS7(urlCtypeHs7));
        StartCoroutine(LoadDetail(urlDetail));
        StartCoroutine(LoadRepair(urlRepair));
        StartCoroutine(LoadCtypeTotal(urlTotalCtype));
        LoadTotalDevice();
     //  TestDetail();
     //  TestDevice();
     //  TestTotalCtype();
    }

    private void Awake()
    {
        Instance = this;
       
    }

    public void LoadTotalDevice()
    {
        for (int i = 0; i < devNames.Length; i++)
        {
            StartCoroutine(LoadDevice(urlDevice, devNames[i]));
        }
    }

    public string GetErrorTimes(string devName )
    {
        string timesData="";
        switch (devName)
        {
            case "风挡自动涂胶机":
                timesData = times.涂胶机;
                break;
            case "转挂机器人":
                timesData = times.机器人;
                break;
            case "四合一加注机":
                timesData = times.加注机;
                break;
            case "车轮自动拧紧设备":
                timesData = times.车轮拧紧;
                break;
            case "底盘合装自动拧紧系统":
                timesData = times.底盘;
                break;
            default:
                break;
        }
        return timesData;

    }

    #region TEST Func

    public void TestTotalCtype()
    {
        string s = testCtypeJson;
        JsonData pa = JsonMapper.ToObject(s);
        totalCtype = new Ctype[pa.Count];
        for (int i = 0; i < totalCtype.Length; i++)
        {
            Ctype temp = new Ctype();
            temp.ctype = pa[i]["ctype"].ToString();
            temp.dayPlanHQA1 = pa[i]["dayPlanHQA1"].ToString();
            temp.dayHQA1 = pa[i]["dayHQA1"].ToString();
            temp.dayHQA8 = pa[i]["dayHQA8"].ToString();
            temp.weekHQA1 = pa[i]["weekHQA1"].ToString();
            temp.weekHQA8 = pa[i]["weekHQA8"].ToString();
            temp.monthHQA1 = pa[i]["monthHQA1"].ToString();
            temp.monthHQA8 = pa[i]["monthHQA8"].ToString();
            temp.yearHQA1 = pa[i]["yearHQA1"].ToString();
            temp.yearHQA8 = pa[i]["yearHQA8"].ToString();
            totalCtype[i] = temp;
            Debug.Log(totalCtype[i].ctype);

        }
    }
    public void TestDetail()
    {
        string s = testDetailJson;
        JsonData pa = JsonMapper.ToObject(s);
        detail = new Detail[pa.Count];
        for (int i = 0; i < detail.Length; i++)
        {
            Detail temp = new Detail();
            temp.VIN = pa[i]["VIN"].ToString();
            temp.enterTime = pa[i]["enterTime"].ToString();
            temp.ParkingSpace = pa[i]["ParkingSpace"].ToString();
            temp.Duration = pa[i]["Duration"].ToString();
            temp.Seconds = pa[i]["Seconds"].ToString();
            temp.status = pa[i]["status"].ToString();
            temp.repairMan = pa[i]["repairMan"].ToString();
            temp.bulMod = pa[i]["bulMod"].ToString();
            detail[i] = temp;
            Debug.Log(detail[i].VIN);
        }
    }


    public void TestDevice()
    {
        string devName = "风挡自动涂胶机";
        string s = testDevJson;
        string p = s.Replace("[", "").Replace("]", "");
        Device dev = JsonMapper.ToObject<Device>(p);

        Debug.Log(dev.设备);
        deviceDic.Add(devName, dev);
    }
    #endregion

    #region getData



    IEnumerator LoadCtypeHS5(string _url)
    {
        WWW getdata = new WWW(_url);
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
            ctype_hs5 = JsonMapper.ToObject<Ctype>(p);

            Debug.Log(ctype_hs5.ctype);
           
        }   
    }
    IEnumerator LoadCtypeHS7(string _url)
    {
        WWW getdata = new WWW(_url);
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
            ctype_hs7 = JsonMapper.ToObject<Ctype>(p);

            Debug.Log(ctype_hs7.ctype);

        }
    }
    IEnumerator LoadRepair(string _url)
    {
        WWW getdata = new WWW(_url);
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
            repair = JsonMapper.ToObject<Repair>(p);

            Debug.Log(repair.repairing);

        }
    }

    IEnumerator LoadCtypeTotal(string _url)
    {
        WWW getdata = new WWW(_url);
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
            JsonData pa = JsonMapper.ToObject(s);
            totalCtype = new Ctype[pa.Count];
            for (int i = 0; i < totalCtype.Length; i++)
            {
                Ctype temp = new Ctype();
                temp.ctype = pa[i]["ctype"].ToString();
                temp.dayPlanHQA1 = pa[i]["dayPlanHQA1"].ToString();
                temp.dayHQA1 = pa[i]["dayHQA1"].ToString();
                temp.dayHQA8 = pa[i]["dayHQA8"].ToString();
                temp.weekHQA1 = pa[i]["weekHQA1"].ToString();
                temp.weekHQA8 = pa[i]["weekHQA8"].ToString();
                temp.monthHQA1 = pa[i]["monthHQA1"].ToString();
                temp.monthHQA8 = pa[i]["monthHQA8"].ToString();
                temp.yearHQA1 = pa[i]["yearHQA1"].ToString();
                temp.yearHQA8 = pa[i]["yearHQA8"].ToString();
                totalCtype[i] = temp;
                Debug.Log(totalCtype[i].ctype);
               
            }



        }
    }

    IEnumerator LoadDetail(string _url)
    {
        WWW getdata = new WWW(_url);
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
            JsonData pa = JsonMapper.ToObject(s);
            detail = new Detail[pa.Count];
            for (int i = 0; i < detail.Length; i++)
            {
                Detail temp = new Detail();
                temp.VIN = pa[i]["VIN"].ToString();
                temp.enterTime = pa[i]["enterTime"].ToString();
                temp.ParkingSpace = pa[i]["ParkingSpace"].ToString();
                temp.Duration = pa[i]["Duration"].ToString();
                temp.Seconds = pa[i]["Seconds"].ToString();
                temp.status = pa[i]["status"].ToString();
                temp.repairMan = pa[i]["repairMan"].ToString();
                temp.bulMod = pa[i]["bulMod"].ToString();
                detail[i] = temp;
                Debug.Log(detail[i].repairMan);
            }

            

        }
    }
    IEnumerator LoadDevice(string _url,string devName)
    {
        
        WWW getdata = new WWW(_url+devName);
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
            Device dev = JsonMapper.ToObject<Device>(p);

            Debug.Log(dev.设备);
            deviceDic.Add(devName, dev);

        }
    }
    IEnumerator LoadTimes(string _url)
    {
        WWW getdata = new WWW(_url);
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
             times = JsonMapper.ToObject<Times>(p);

            Debug.Log(times.底盘);

        }
    }
    #endregion
}
