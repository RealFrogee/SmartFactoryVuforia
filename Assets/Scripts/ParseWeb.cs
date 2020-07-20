using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Xml;
using System;
using System.Xml.Linq;
using UnityEngine.UI;
using System.IO;
#region 红旗总装空间
[Serializable]
public class Group
{
    public string code;
    public data[] data;
    public string message;
}
[Serializable]
public class data
{
    public string PRODUCTGROUPNAME;
    public string PLANT;
    public string P2;
    public string P4;
    public string P5;
    public string YIELDLY;
    public string PLANQTY;
    public string ACTQTY;
    public string PRODUCTLINELEVEL;
}
#endregion
[Serializable]
public class Product
{
    public date[] date;
}
[Serializable]
public class date
{
    public string CHEJIAN;
    public string RIQI;
    public string CARTYPE;
    public string JHS;
    public string WCS;
}
public class ParseWeb : MonoBehaviour
{
   
    UnityWebRequest www;
    UnityWebRequest www2;
    UnityWebRequest www3;
    UnityWebRequest www4;
    IEnumerator Upload1;
    IEnumerator Upload2;
    IEnumerator Upload3;
    IEnumerator Upload4;

    public string di1;
    string di2;
    public string Di2Type;
    public string di3;
    string TimeDate1;
    string di4;


    private string result1;
    private string result2;
    private string result3;
    private string result4;

    Group group;
    Product product;
    string url;
    public Text chanpingxilie;
    public Text kaishiriqi;
    public Text jiezhiriqi;
    public Text jihuaxiaxian;
    public Text shijixiaxian;



    public Text Chejian;
    public Text riqi;
    public Text cartype;
    public Text jhs;
    public Text wcs;
    public GameObject zhengque;
    public GameObject cuowu;



    //可能会改动
    public int zonghe;
    public int wancheng;
    public string shengchanchexing;

    void Start()
    {
        TimeDate1 = DateTime.Now.ToString("yyyy-MM-dd");
        print(TimeDate1);
         di4 = "<?xml version=\"1.0\" encoding=\"utf-16\"?> <soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">   <soap:Body>     <getProduceInfo xmlns=\"http://service.wbs.prm.ptzn/\">       <workShop xmlns=\"\">RIQI</workShop>       <day xmlns=\"\">" + TimeDate1 + "</day>     </getProduceInfo>   </soap:Body> </soap:Envelope>";
        di2 = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">     <soap:Body>       <getCdrDataByType       xmlns=\"http://service.wbs.dmm.ptzn/\" >      <DeviceTypes xmlns=\"\" >" + Di2Type + "</DeviceTypes>       </getCdrDataByType>     </soap:Body> </soap:Envelope>";
        if (di1 != null)
        { 
            Upload1 = SendMessage1(di1);
            StartCoroutine(Upload1);
        }
        if(di2!=null)
        {
            Upload2 = SendMessage2(di2);
            StartCoroutine(Upload2);

        }
        if (di3 != null)
        {
            Upload3 = SendMessage3(di3);
            StartCoroutine(Upload3);
        }
        if (di4 != null)
        {
            Upload4 = SendMessage4(di4);
            StartCoroutine(Upload4);
        }

        group = new Group();

        product = new Product();
        




        url = "http://www.rflagii.com/msserver/10.4.1.20:9091/api/getProductRollsOfflineInfo";
        StartCoroutine(Request());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Request()
    {
        UnityWebRequest www = new UnityWebRequest();
        WWWForm form = new WWWForm();
        www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
        while (!www.isDone)
        {
            yield return new WaitForEndOfFrame();

        }
        if (www.error == null)
        {
           string  sourcexml = www.downloadHandler.text;
            print("这条信息"+ sourcexml);
           group = JsonUtility.FromJson<Group>(sourcexml);
            //这里注释掉，不需要第一个接口，以后可能会更改
            //chanpingxilie.text = group.data[0].PRODUCTGROUPNAME;
            //kaishiriqi.text = group.data[0].P4;
            //jiezhiriqi.text = group.data[0].P5;
            //jihuaxiaxian.text = group.data[0].PLANQTY;
            //shijixiaxian.text = group.data[0].ACTQTY;
            kaishiriqi.text = TimeDate1;
            jiezhiriqi.text = TimeDate1;
        }
    }

        IEnumerator SendMessage1(string mes)
    {
        
        // byte[] message = Encoding.UTF8.GetBytes(mes);
   
         string Ip = "http://www.rflagii.com/msserver/10.7.68.90:8080/QMERP/webservice/WSDIM001ServiceImpl?wsdl";



        WWWForm form = new WWWForm();
        //form.AddField("xmlns:soap", "http://schemas.xmlsoap.org/soap/envelope/");
        //form.AddField("xmlns", "http://service.wbs.dmm.ptzn/");
        if(Ip!=null)
        {
            www = UnityWebRequest.Post(Ip, form);

        }

        byte[] postBytes = Encoding.UTF8.GetBytes(mes);
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


       www.SetRequestHeader("Content-Type", "text/xml:charset=utf-8");


        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("报错");
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("form upload complete");
            ulong mess = www.uploadedBytes;
            print(www.responseCode);
            if (www.responseCode == 200)
                //print(www.downloadHandler.text);

            result1 = www.downloadHandler.text;
            //print(result1);
            dillMsg(mes);

        }
        www.Abort();
        //停止协程
        StopCoroutine(Upload1);

    }
    IEnumerator SendMessage2(string mes)
    {
        string Ip = "http://www.rflagii.com/msserver/10.7.68.90:8080/QMERP/webservice/WSDIM001ServiceImpl?wsdl";






        WWWForm form = new WWWForm();
        //form.AddField("xmlns:soap", "http://schemas.xmlsoap.org/soap/envelope/");
        //form.AddField("xmlns", "http://service.wbs.dmm.ptzn/");
        if (Ip != null)
        {
            www2 = UnityWebRequest.Post(Ip, form);

        }

        byte[] postBytes = Encoding.UTF8.GetBytes(mes);
        www2.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        www2.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


        www2.SetRequestHeader("Content-Type", "text/xml:charset=utf-8");


        yield return www2.SendWebRequest();

        if (www2.isNetworkError)
        {
            Debug.Log("报错");
            Debug.Log(www2.error);
        }
        else
        {
            Debug.Log("form upload complete");
            ulong mess = www2.uploadedBytes;
            print(www2.responseCode);
            if (www2.responseCode == 200)
                //print(www.downloadHandler.text);
  

            result2 = www2.downloadHandler.text;
            //print(result2);
            dillMsg(mes);
        }
    }
    IEnumerator SendMessage3(string mes)
    {
        string Ip = "http://www.rflagii.com/msserver/10.7.68.90:8080/QMERP/webservice/WSDIM001ServiceImpl?wsdl";
        WWWForm form = new WWWForm();
        //form.AddField("xmlns:soap", "http://schemas.xmlsoap.org/soap/envelope/");
        //form.AddField("xmlns", "http://service.wbs.dmm.ptzn/");
        if (Ip != null)
        {
            www3 = UnityWebRequest.Post(Ip, form);

        }

        byte[] postBytes = Encoding.UTF8.GetBytes(mes);
        www3.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        www3.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


        www3.SetRequestHeader("Content-Type", "text/xml:charset=utf-8");


        yield return www3.SendWebRequest();

        if (www3.isNetworkError)
        {
            Debug.Log("报错");
            Debug.Log(www3.error);
        }
        else
        {
            Debug.Log("form upload complete");
            ulong mess = www3.uploadedBytes;
            print(www3.responseCode);
            if (www3.responseCode == 200)
                //print(www.downloadHandler.text);


            result3 = www3.downloadHandler.text;
            XmlDocument document = new XmlDocument();
            document.LoadXml(result3);
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            document.WriteTo(xmlTextWriter);
            string x = document.GetElementsByTagName("return")[0].ChildNodes[0].Value;
            if(x.Contains("ok"))
            {
                //这里写入状态正确的逻辑
                if(zhengque&&cuowu)
                {
                    zhengque.SetActive(true);
                    cuowu.SetActive(false);
                    print("能够走逻辑");
                }
               
            }
            else
            {
                zhengque.SetActive(false);
                cuowu.SetActive(true);
            }
            
            dillMsg(mes);
        }
    }
    IEnumerator SendMessage4(string mes)
    {
        string Ip = "http://www.rflagii.com/msserver/10.7.68.90:9080/QMERP/webservice/WSProduceMsgServiceImpl?wsdl";

        WWWForm form = new WWWForm();
        //form.AddField("xmlns:soap", "http://schemas.xmlsoap.org/soap/envelope/");
        //form.AddField("xmlns", "http://service.wbs.dmm.ptzn/");
        if (Ip != null)
        {
            www4 = UnityWebRequest.Post(Ip, form);

        }

        byte[] postBytes = Encoding.UTF8.GetBytes(mes);
        www4.uploadHandler = (UploadHandler)new UploadHandlerRaw(postBytes);
        www4.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


        www4.SetRequestHeader("Content-Type", "text/xml:charset=utf-8");


        yield return www4.SendWebRequest();

        if (www4.isNetworkError)
        {
            Debug.Log("报错");
            Debug.Log(www4.error);
        }
        else
        {
            Debug.Log("form upload complete");
            ulong mess = www4.uploadedBytes;
            print(www4.responseCode);
            if (www4.responseCode == 200)
                //print(www.downloadHandler.text);
            result4 = www4.downloadHandler.text;
            XmlDocument document = new XmlDocument();
            document.LoadXml(result4);
            StringBuilder stringBuilder = new StringBuilder();
            StringWriter stringWriter = new StringWriter(stringBuilder);
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            document.WriteTo(xmlTextWriter);
            string x= document.GetElementsByTagName("return")[0].ChildNodes[0].Value;
            //string x1= document.GetElementsByTagName("return")[1].ChildNodes[1].Value;
            string result = "{\"date\": "+x +"}";
            
            product=JsonUtility.FromJson<Product>(result);
            if(chanpingxilie&&cartype)
            {
                chanpingxilie.text = "";
                cartype.text = "";
            }

            //这里写入接口所有数据的总和数量
            for (int i=0;i<product.date.Length;i++)
            {
                if(product.date[i]!=null)
                {
                    if(cartype&&chanpingxilie)
                    {
                        cartype.text = cartype.text + " " + product.date[i].CARTYPE;
                        chanpingxilie.text = chanpingxilie.text + " " + product.date[i].CARTYPE;
                        zonghe = int.Parse(product.date[i].JHS) + zonghe;
                        wancheng = int.Parse(product.date[i].WCS) + wancheng;
                    }

                }
            }
            if(Chejian)
            {
                Chejian.text = product.date[0].CHEJIAN;
                riqi.text = product.date[0].RIQI;
                jihuaxiaxian.text = zonghe.ToString();
                shijixiaxian.text = wancheng.ToString();

                jhs.text = zonghe.ToString();
                wcs.text = wancheng.ToString();
            }

            dillMsg(mes);
        }
    }
    public void dillMsg( string msg)
    {
       if(msg==di1)
        {

        }
       else if(msg==di2)
        {

        }
        else if (msg == di3)
        {

        }
        else if (msg == di4)
        {

        }

    }


    private void OnDestroy()
    {
        //表示不再使用此UnityWebRequest，并应清除它正在使用的任何资源。
        www.Dispose();
        www2.Dispose();
        www3.Dispose();
        www4.Dispose();
    }
    //public string CreateJsonMes()
    //{
    //    string filePath = Application.dataPath + "/xml/test.xml";
    //    if(File.Exists(filePath))
    //    {
    //        XmlDocument xmlDoc = new XmlDocument();
    //        xmlDoc.Load(filePath);


    //    }
    //}

    static string Convert(string xml)
    {
        XmlDocument _doc = new XmlDocument();
        _doc.LoadXml(xml);
        return _doc.ToString();

    }

}
