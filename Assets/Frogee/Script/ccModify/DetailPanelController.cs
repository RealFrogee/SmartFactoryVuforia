using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPanelController : MonoBehaviour
{
    public RectTransform content;
    public GameObject detailItemPrefab;
    VerticalLayoutGroup vlg;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("RefreshDetailPanel", 3f);
        RefreshDetailPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshDetailPanel()
    {
        InterfaceDataController controller = InterfaceDataController.Instance;
        for (int i = 0; i < 2; i++)
        {
            GameObject itemObj = Instantiate(detailItemPrefab);
            itemObj.transform.parent = content;
            itemObj.transform.localPosition = Vector3.zero;
            itemObj.transform.localScale = new Vector3(1, 1, 1);
            itemObj.transform.localEulerAngles = Vector3.zero;
            DetailItem item = itemObj.GetComponent<DetailItem>();
            item.InitDetailItem(controller.detail[i].VIN, controller.detail[i].enterTime, controller.detail[i].ParkingSpace, controller.detail[i].Duration, controller.detail[i].status, controller.detail[i].repairMan, controller.detail[i].bulMod);
          
            
        }
    }
}
