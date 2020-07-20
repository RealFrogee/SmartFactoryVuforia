using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevicePanelController : MonoBehaviour
{
    public bool staticPanel = false;
    public string startDevName;
    public Text devTitleText;
    public Text errCodeText;
    public Text errInfoText;
    public Text errLineText;
    public Text errStartTimeText;
    public Text errStopTimeText;
    public Text errOverText;
    public Text errKeepTimeText;
    public Text totalErrTimes;
    // Start is called before the first frame update
    void Start()
    {
        if(staticPanel)
        {
            StartCoroutine(RefreshStaticPanel());
        }
    }

    // Update is called once per frame
 
    IEnumerator RefreshStaticPanel()
    {
        yield return new WaitForSeconds(10f);
        RefreshDevicePanel(startDevName);
    }

    public void RefreshDevicePanel(string devName)
    {
        if (devName == "")
            devName = startDevName;
        Device temp = InterfaceDataController.Instance.deviceDic[devName];
        devTitleText.text = temp.设备;
        errCodeText.text = temp.报警码;
        errInfoText.text = temp.报警信息;
        errLineText.text = temp.线体;
        errStartTimeText.text = temp.报警开始;
        errStopTimeText.text = temp.报警结束;
        errOverText.text = temp.报警取消;
        errKeepTimeText.text = temp.报警时长;
        totalErrTimes.text = InterfaceDataController.Instance.GetErrorTimes(devName);
    }
}
