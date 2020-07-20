using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairPanelController : MonoBehaviour
{
    public Text repairingText;
    public Text repairedText;
    public Text overtimeText;
    public Text dailyTotalText;
    public Text todayToRepairText;

    public Text repairingTextOther;
    public Text repairedTextOther;
    public Text overtimeTextOther;
    public Text dailyTotalTextOther;
    public Text todayToRepairTextOther;

    public DrawSquald repairedImg;
    public DrawSquald repairingImg;
    public RectTransform todayRepairImg;
    // Start is called before the first frame update
    void Start()
    {

        RefreshRepairPanel();
    }

    public void RefreshRepairPanel()
    {
        repairingText.text = InterfaceDataController.Instance.repair.repairing;
        repairedText.text = InterfaceDataController.Instance.repair.repaired;
        overtimeText.text = InterfaceDataController.Instance.repair.overtime;
        dailyTotalText.text = InterfaceDataController.Instance.repair.daliyTotal;
        todayToRepairText.text = InterfaceDataController.Instance.repair.todayToRepair;

        repairingTextOther.text = InterfaceDataController.Instance.repair.repairing;
        repairedTextOther .text= InterfaceDataController.Instance.repair.repaired;
        overtimeTextOther .text= InterfaceDataController.Instance.repair.overtime;
        dailyTotalTextOther.text = InterfaceDataController.Instance.repair.daliyTotal;
        todayToRepairTextOther.text = InterfaceDataController.Instance.repair.todayToRepair;

        int repairing = int.Parse(InterfaceDataController.Instance.repair.repairing);
        int repaired = int.Parse(InterfaceDataController.Instance.repair.repaired);
        int overtime = int.Parse(InterfaceDataController.Instance.repair.overtime);
        int dailyTotal = int.Parse(InterfaceDataController.Instance.repair.daliyTotal);
        int todayToRepair = int.Parse(InterfaceDataController.Instance.repair.todayToRepair);

        float a = (float)todayToRepair / (float)dailyTotal;
        todayRepairImg.sizeDelta = new Vector2(todayRepairImg.sizeDelta.x, 100f * a);

        float totalRepair = (float)(repairing + repaired + overtime);
        repairedImg.FillAmount = (float)repaired / totalRepair;

        repairingImg.FillAmount = (float)(repaired + repairing) / totalRepair;

    }
}
