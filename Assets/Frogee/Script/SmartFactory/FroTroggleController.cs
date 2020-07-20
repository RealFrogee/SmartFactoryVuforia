using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
enum ProducePanelType
{
    day,
    week,
    month,
    year
}
public class FroTroggleController : MonoBehaviour
{
    InterfaceDataController dataController;
    public GameObject ctypeItemPrefab;
    public Transform ctypeContent;
    public Toggle[] toggles;
    ProducePanelType currentType = ProducePanelType.day;
    public DrawSquald Hs7AmountCycle;

    public GameObject planObj;
    public Text panelTypeName;
    public Text planText;
    public Text realProduceText;
    public Text realProduceDataText;
    public Text warehousingText;
    public Text warehousingDataText;
    //public Text hs5RealProduceText;
   // public Text hs7RealProduceText;

    public RectTransform realProduceImg;
    public RectTransform warehousingImg;
    public RectTransform planProduceImg;


    //float horizontalDataFillAmount=400f;

    //int hs5Warehousing;
    int hs5realPruduce;
  //  int hs7Warehousing;
    int hs7realPruduce;


    // Start is called before the first frame update
    void Start()
    {
        dataController = InterfaceDataController.Instance;
        RefreshPanelData();
    }



    public void OnToggleGroup(Toggle selectToggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i] != selectToggle)
            {
                toggles[i].isOn = false;
            }
        }
      
        switch (selectToggle.name)
        {
            case "day":
                currentType = ProducePanelType.day;
                break;
            case "week":
                currentType = ProducePanelType.week;
                break;
            case "month":
                currentType = ProducePanelType.month;
                break;
            case "year":
                currentType = ProducePanelType.year;
                break;

        }
        for (int i = ctypeContent.childCount-1; i >=0; i--)
        {
            Destroy(ctypeContent.GetChild(i).gameObject);
        }
        Debug.Log(currentType);
        RefreshPanelData();
    }

    public void RefreshPanelData()
    {
        realProduceImg.sizeDelta = new Vector2(400f, 30f);
        warehousingImg.sizeDelta = new Vector2(400f, 30f);
        planObj.SetActive(false);
        Ctype[] tCtype = dataController.totalCtype;
        int totalRealProduce=0;
        int totalWarehousing=0;
        int totalPlanProduce = 0;
        switch (currentType)
        {
            case ProducePanelType.day:
                planObj.SetActive(true);
                realProduceText.text = "日产量:";
                warehousingText.text = "日入库:";
                 panelTypeName.text = "日产车辆";
                for (int i = 0; i < tCtype.Length; i++)
                {
                    totalRealProduce += int.Parse(tCtype[i].dayHQA1);
                    totalWarehousing += int.Parse(tCtype[i].dayHQA8);
                    totalPlanProduce += int.Parse(tCtype[i].dayPlanHQA1);
                    GameObject itemObj = Instantiate(ctypeItemPrefab, ctypeContent);
                    CtypeItem item = itemObj.GetComponent<CtypeItem>();
                    item.InitCtypeItem(tCtype[i].dayHQA1, tCtype[i].ctype);
                }
              
                break;
            case ProducePanelType.week:
                realProduceText.text = "周产量:";
                warehousingText.text = "周入库:";
                 panelTypeName.text = "周产车辆";
                for (int i = 0; i < tCtype.Length; i++)
                {
                    totalRealProduce += int.Parse(tCtype[i].weekHQA1);
                    totalWarehousing += int.Parse(tCtype[i].weekHQA8);
                    GameObject itemObj = Instantiate(ctypeItemPrefab, ctypeContent);
                    CtypeItem item = itemObj.GetComponent<CtypeItem>();
                    item.InitCtypeItem(tCtype[i].weekHQA1, tCtype[i].ctype);
                }

                break;
            case ProducePanelType.month:
                realProduceText.text = "月产量:";
                warehousingText.text = "月入库:";
                  panelTypeName.text = "月产车辆";
                for (int i = 0; i < tCtype.Length; i++)
                {
                    totalRealProduce += int.Parse(tCtype[i].monthHQA1);
                    totalWarehousing += int.Parse(tCtype[i].monthHQA8);
                    GameObject itemObj = Instantiate(ctypeItemPrefab, ctypeContent);
                    CtypeItem item = itemObj.GetComponent<CtypeItem>();
                    item.InitCtypeItem(tCtype[i].monthHQA1, tCtype[i].ctype);
                }

                break;
            case ProducePanelType.year:
                realProduceText.text = "年产量:";
                warehousingText.text = "年入库:";
                  panelTypeName.text = "年产车辆";
                for (int i = 0; i < tCtype.Length; i++)
                {
                    totalRealProduce += int.Parse(tCtype[i].yearHQA1);
                    totalWarehousing += int.Parse(tCtype[i].yearHQA8);
                    GameObject itemObj = Instantiate(ctypeItemPrefab, ctypeContent);
                    CtypeItem item = itemObj.GetComponent<CtypeItem>();
                    item.InitCtypeItem(tCtype[i].yearHQA1, tCtype[i].ctype);
                }

                break;
            default:
                break;
        }

     //   if((hs5realPruduce+hs7realPruduce)==0)
     //   {
     //       Hs7AmountCycle.FillAmount = 0.5f;
     //       
     //   }
     //   else if(hs5realPruduce==0)
     //   {
     //       Hs7AmountCycle.FillAmount = 1f;
     //   }
     //   else if(hs7realPruduce==0)
     //   {
     //       Hs7AmountCycle.FillAmount = 0f;
     //   }
     //   else
     //   {
     //       Hs7AmountCycle.FillAmount =(float) hs7realPruduce / ((float)hs5realPruduce + (float)hs7realPruduce);
     //   }
     //
     //
     //   float totalRealProduce = hs7realPruduce + hs5realPruduce;
     //   float totalWarehousing = hs7Warehousing + hs5Warehousing;
     //


       warehousingDataText.text = totalWarehousing.ToString();
       realProduceDataText.text = totalRealProduce.ToString();
     //   hs5RealProduceText.text = hs5realPruduce.ToString();
     //   hs7RealProduceText.text = hs7realPruduce.ToString();
     //   
     //
     if(currentType==ProducePanelType.day)
     {
            Debug.Log(totalPlanProduce);
            planText.text = totalPlanProduce.ToString();
            if (totalPlanProduce > totalRealProduce && totalPlanProduce > totalWarehousing)
            {
                warehousingImg.sizeDelta = new Vector2(400f * ((float)totalWarehousing / (float)totalPlanProduce), 30f);
                realProduceImg.sizeDelta = new Vector2(400f * ((float)totalRealProduce / (float)totalPlanProduce), 30f);
            }
            else if(totalRealProduce > totalPlanProduce && totalRealProduce > totalWarehousing)
            {
                warehousingImg.sizeDelta = new Vector2(400f * ((float)totalWarehousing / (float)totalRealProduce), 30f);
                planProduceImg.sizeDelta = new Vector2(400f * ((float)totalPlanProduce / (float)totalRealProduce), 30f);
            }
            else if(totalWarehousing > totalPlanProduce && totalWarehousing > totalRealProduce)
            {
                planProduceImg.sizeDelta = new Vector2(400f * ((float)totalPlanProduce / (float)totalWarehousing), 30f);
                realProduceImg.sizeDelta = new Vector2(400f * ((float)totalRealProduce / (float)totalWarehousing), 30f);
            }
  
     }
     else
     {
            if (totalRealProduce == totalWarehousing)
            {
                realProduceImg.sizeDelta = new Vector2(400f, 30f);
                warehousingImg.sizeDelta = new Vector2(400f, 30f);
            }
            else if (totalWarehousing < totalRealProduce)
            {
                warehousingImg.sizeDelta = new Vector2(400f * ((float)totalWarehousing / (float)totalRealProduce), 30f);
            }
            else if (totalWarehousing > totalRealProduce)
            {
                realProduceImg.sizeDelta = new Vector2(400f * ((float)totalRealProduce / (float)totalWarehousing), 30f);
            }
        }
  
  
      

    }
}
