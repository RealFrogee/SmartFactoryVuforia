using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Today_Alarm : MonoBehaviour
{
    public List< UIScript> uis;
    public List<UIScript> xiuuis;
    public int max;
    public GameObject []cell;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 冒泡排序
    /// </summary>
    public void findTimeLong()
    {
        foreach (UIScript a in uis)
        {
            if (a.报警取消 == "否")
            {
                xiuuis.Add(a);
            }
        }
        for (int i = 0; i < xiuuis.Capacity - 1; i++)
        {
            for (int j = 0; j < xiuuis.Capacity - 1 - i; j++)
            {
                if (int.Parse (xiuuis[j].报警时长) > int.Parse(xiuuis[j + 1].报警时长))
                {
                    UIScript temp = xiuuis[j];
                    xiuuis[j] = xiuuis[j + 1];
                    xiuuis[j + 1] = temp;
                }
            }
        }
        max =int.Parse( xiuuis[xiuuis.Capacity].报警时长);

    }

   public void CreateCell()
    {
        findTimeLong();
        for (int i = 0; i < xiuuis.Capacity; i++)
        {
            cell[i].gameObject.SetActive(true);
            Utils.Utility.findChild(cell[i].transform, "shuju").GetComponent<Image>().fillAmount = int.Parse(xiuuis[i].报警时长) / max;
            Utils.Utility.findChild(cell[i].transform, "时间").GetComponent<Text>().text = xiuuis[i].报警开始;
            Utils.Utility.findChild(cell[i].transform, "持续时间").GetComponent<Text>().text = xiuuis[i].报警时长;
            
        }

    }
}
