using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Security.Cryptography;

[System.Serializable]
public enum ShowMenuType
{
    Normal,
    RotScale,
    Color,
    ColorHS3,
    Broken,
    DigitalFactory,
    None,
    NBDmenu
}

[System.Serializable]
public enum LevelState
{
    Main,
    ViewPanel,
    Car,
    ViewPanelDevice,
    ViewPanelRepair
}



public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    [Header("ViewPanels")]
    public GameObject producePanel;
    public GameObject repairPanle;
    public GameObject devicePanel;
    public DevicePanelController devicePanelController;

    [Header("LevelReference")]
    public GameObject mainLevel;
    public GameObject carLevel;
    public GameObject viewPanelLevel;
    public Transform showParent;
    public GameObject viewPanelMesh;
    public GameObject scanPanel;
    public AudioSource audioPlayer;
    public AudioSource effectSoundPlayer;
    public GameObject loadingLogo;

  //  public AnchorModuleScript anchorController;

    [Header("Debug")]
    public GameObject debugWindow;
    public GameObject anchorPanel;
    public MeshRenderer anchorMesh;
    public BoxCollider anchorCollider;
    public string anchorID;

    [Header("HandMenu")]
    public GameObject handMenu;
    public GameObject colorBtn;
    public GameObject rotBtn;
    public GameObject scaleBtn;
    public GameObject backBtn;


    [Header("SpawnPrefab")]
    public GameObject HS7;

    LevelState currentLevelState = LevelState.Main;
    GameObject objOnShow;
    Vector3 objOnShowStartRot;
    FroHoloUdp myUdp;
    string createRoomMsg = "";
    bool bViewPanelLoaded = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //DebugOn();
        //Debug.Log(Application.persistentDataPath);
        SetGazeEnabled(false);
        StartCoroutine(SceneLoading());
      //  StartCoroutine(AutoLoadAnchor());
        ShowHandMesh();
        myUdp = FroHoloUdp.Instance;
        
    }


    private void OnDestroy()
    {
       // anchorController.StopAzureSession();
    }


    #region menu&car control

    public void DebugOn()
    {
        debugWindow.SetActive(!debugWindow.activeInHierarchy);
        anchorPanel.SetActive(!anchorPanel.activeInHierarchy);
        anchorMesh.enabled = !anchorMesh.enabled;
        anchorCollider.enabled = !anchorCollider.enabled;
    }

    public void ShowObj(GameObject prefab)
    {

        objOnShow = Instantiate(prefab) as GameObject;

        objOnShow.transform.parent = showParent;

        objOnShow.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        objOnShow.transform.localEulerAngles = Vector3.zero;
        objOnShow.transform.localPosition = new Vector3(0, 0, 0);
        objOnShowStartRot = objOnShow.transform.localEulerAngles;



    }


    public void ShowObjEnd()
    {


        switch (currentLevelState)
        {

            case LevelState.ViewPanel:
                SwitchLevel(LevelState.Main);
                break;
            case LevelState.Car:
                SwitchLevel(LevelState.Main);
                break;
            case LevelState.ViewPanelDevice:
                SwitchLevel(LevelState.ViewPanel);
                break;
            case LevelState.ViewPanelRepair:
                SwitchLevel(LevelState.ViewPanel);
                break;
        }


        



    }





    void ResetHandMenuBtn()
    {
        handMenu.SetActive(false);
        colorBtn.SetActive(false);
        rotBtn.SetActive(false);
        scaleBtn.SetActive(false);
        backBtn.SetActive(true);

        switch (currentLevelState)
        {
            case LevelState.Main:
                rotBtn.SetActive(true);
                scaleBtn.SetActive(true);
                backBtn.SetActive(false);
                break;
            case LevelState.Car:
                colorBtn.SetActive(true);
                rotBtn.SetActive(true);
                scaleBtn.SetActive(true);
                break;
        }

        StartCoroutine(ResetHandMenuDelay());

    }

    IEnumerator ResetHandMenuDelay()
    {
        yield return new WaitForSeconds(1f);
        handMenu.SetActive(true);

    }


    void ShowHandMesh()
    {
        MixedRealityHandTrackingProfile htp = Microsoft.MixedReality.Toolkit.CoreServices.InputSystem?.InputSystemProfile?.HandTrackingProfile;
        if (htp != null)
        {
            htp.EnableHandMeshVisualization = true;
        }
    }

    public void PlayAudio(AudioClip clipToPlay)
    {
        audioPlayer.clip = clipToPlay;
        audioPlayer.Play();
    }
    public void CloseAudio()
    {
        if (audioPlayer.isPlaying)
            audioPlayer.Stop();
    }

    public void PlayEffectSound(AudioClip effectClip)
    {
        effectSoundPlayer.clip = effectClip;
        effectSoundPlayer.Play();
    }

    public void MuteAudio(bool mute)
    {
        if (mute)
        {
            audioPlayer.volume = 0;
        }
        else
        {
            audioPlayer.volume = 1;
        }
    }

    public void ChangeCarColor(Material mat)
    {
        if(objOnShow!=null)
        objOnShow.GetComponent<CarColorController>().ChangeColor(mat);
    }




    public void RotCarSlider(Microsoft.MixedReality.Toolkit.UI.SliderEventData eventData)
    {

        if (currentLevelState == LevelState.Main)
        {
            mainLevel.transform.localEulerAngles = new Vector3(0, 180f * eventData.NewValue, 0) + objOnShowStartRot;
        }
        else if (currentLevelState == LevelState.Car)
        {
            carLevel.transform.localEulerAngles = new Vector3(0, 180f * eventData.NewValue, 0) + objOnShowStartRot;
        }

    }
    public void ScaleCarSlider(Microsoft.MixedReality.Toolkit.UI.SliderEventData eventData)
    {


        if (currentLevelState == LevelState.Main)
        {
            mainLevel.transform.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(1.3f, 1.3f, 1.3f), eventData.NewValue);
        }
        else if (currentLevelState == LevelState.Car)
        {
            carLevel.transform.localScale = Vector3.Lerp(new Vector3(0.3f, 0.3f, 0.3f), new Vector3(1f, 1f, 1f), eventData.NewValue);
        }


    }
    [Header("Slider")]
    public Microsoft.MixedReality.Toolkit.UI.PinchSlider rotSlider;
    public Microsoft.MixedReality.Toolkit.UI.PinchSlider scaleSlider;
    public void RotCarVoice(bool bAdd)
    {
        float newSliderValue;

        newSliderValue = bAdd ? rotSlider.SliderValue + 0.1f : rotSlider.SliderValue - 0.1f;

        if (newSliderValue > 1f)
            newSliderValue = 1f;
        else if (newSliderValue < 0)
            newSliderValue = 0f;

        rotSlider.SliderValue = newSliderValue;

        if (currentLevelState == LevelState.Main)
        {
            mainLevel.GetComponent<CarRotScale_BIO>().SendRotMsg();
        }
        else if (currentLevelState == LevelState.Car)
        {
            carLevel.GetComponent<CarRotScale_BIO>().SendRotMsg();
        }


    }

    public void ScaleCarVoice(bool bAdd)
    {
        float newSliderValue;

        newSliderValue = bAdd ? scaleSlider.SliderValue + 0.1f : scaleSlider.SliderValue - 0.1f;

        if (newSliderValue > 1f)
            newSliderValue = 1f;
        else if (newSliderValue < 0)
            newSliderValue = 0f;

        scaleSlider.SliderValue = newSliderValue;

        if (currentLevelState == LevelState.Main)
        {
            mainLevel.GetComponent<CarRotScale_BIO>().SendScaleMsg();
        }
        else if (currentLevelState == LevelState.Car)
        {
            carLevel.GetComponent<CarRotScale_BIO>().SendScaleMsg();
        }
    }

    public void SendCarRotMsg(bool bSend)
    {
        if (currentLevelState == LevelState.Main)
        {
            mainLevel.GetComponent<CarRotScale_BIO>().SwitchSendCarRotMsg(bSend);
        }
        else if (currentLevelState == LevelState.Car)
        {
            carLevel.GetComponent<CarRotScale_BIO>().SwitchSendCarRotMsg(bSend);
        }


    }

    public void SendCarScaleMsg(bool bSend)
    {
        if (currentLevelState == LevelState.Main)
        {
            mainLevel.GetComponent<CarRotScale_BIO>().SwitchSendCarScaleMsg(bSend);
        }
        else if (currentLevelState == LevelState.Car)
        {
            carLevel.GetComponent<CarRotScale_BIO>().SwitchSendCarScaleMsg(bSend);
        }

    }

    #endregion

    #region Game Init

    public void SetGazeEnabled(bool isEnabled)
    {
        PointerUtils.SetGazePointerBehavior(isEnabled ? PointerBehavior.Default : PointerBehavior.AlwaysOff);
    }
    IEnumerator SceneLoading()
    {

        yield return new WaitForSeconds(9.6f);
        if (myUdp.canSend)
        {
            
            loadingLogo.SetActive(false);
           // mainLevel.SetActive(true);
            ResetHandMenuBtn();
            
        }
        else
        {
            loadingLogo.SetActive(false);
           // mainLevel.SetActive(true);
        }

    }


    private void CreateRoomInvoke()
    {
        myUdp.canRecv = false;
        if (createRoomMsg.Length == 0)
        {
            MsgClass temp = new MsgClass();
            temp.msgType = MsgType.Room;
            temp.objName = "anyway";
            temp.parameter = myUdp.localIP;
            createRoomMsg = JsonHandle.Msg2Json(temp);
        }
        myUdp.AsyncSend(createRoomMsg);
        // myUdp.BroadcastSend(createRoomMsg);
    }

    public void GameStart()
    {
        //StartGameObj.SetActive(false);
        CancelInvoke("CreateRoomInvoke");
        ResetHandMenuBtn();
        MsgClass startGameMsg = new MsgClass();
        startGameMsg.msgType = MsgType.StartGame;
        startGameMsg.objName = "anyway";
        myUdp.AsyncSend(JsonHandle.Msg2Json(startGameMsg));

        //  mainMenuObj.SetActive(true);
        //spatialColliderHandler.ToggleObservers();
        //anchorController.CreateAzureAnchor(sceneRoot);

    }


    public void GetStartGame()
    {
        if (!myUdp.canSend)
        {
            // mainMenuObj.SetActive(true);
            // spatialColliderHandler.ToggleObservers();   

        }


    }

    #endregion


    #region SmartFactory

    public void ShowDevicePanel(string devName)
    {
        devicePanelController.RefreshDevicePanel(devName);
    }
    public void SwitchLevel(LevelState toLevel)
    {
        CloseAudio();
        switch (currentLevelState)
        {
            case LevelState.Main:
                mainLevel.SetActive(false);
                break;
            case LevelState.ViewPanel:
                if (toLevel != LevelState.ViewPanelDevice&&toLevel!=LevelState.ViewPanelRepair)
                    viewPanelLevel.SetActive(false);
                viewPanelMesh.SetActive(false);
                producePanel.SetActive(false);
                break;
            case LevelState.Car:
                StopCoroutine(LoadCarLevel());
                for (int i = carLevel.transform.childCount - 1; i >= 0; i--)
                {
                    Destroy(carLevel.transform.GetChild(i).gameObject);
                }
                carLevel.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                carLevel.transform.localEulerAngles = new Vector3(0, 0, 0);
                carLevel.SetActive(false);
                break;
            case LevelState.ViewPanelDevice:
                Destroy(objOnShow);
                devicePanel.SetActive(false);
                break;
            case LevelState.ViewPanelRepair:
                repairPanle.SetActive(false);
                break;
            default:
                break;
        }

        currentLevelState = toLevel;
        ResetHandMenuBtn();

        switch (toLevel)
        {
            case LevelState.Main:
                mainLevel.SetActive(true);
                break;
            case LevelState.ViewPanel:
                if(bViewPanelLoaded)
                {
                    viewPanelLevel.SetActive(true);
                    viewPanelMesh.SetActive(true);
                    producePanel.SetActive(true);
                }
                else
                {
                    StartCoroutine(LoadViewPanelLevel());
                }
               
                break;
            case LevelState.Car:
                carLevel.SetActive(true);
                StartCoroutine(LoadCarLevel());
                break;
            case LevelState.ViewPanelDevice:
                devicePanel.SetActive(true);
                break;
            case LevelState.ViewPanelRepair:
                repairPanle.SetActive(true);
                break;
            default:
                break;
        }

    }

    IEnumerator LoadViewPanelLevel()
    {
        scanPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        scanPanel.SetActive(false);
        viewPanelLevel.SetActive(true);
        viewPanelMesh.SetActive(true);
        bViewPanelLoaded = true;
    }


    IEnumerator LoadCarLevel()
    {
        scanPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        scanPanel.SetActive(false);
     objOnShow=   Instantiate(HS7, carLevel.transform);

    }

    

    public void OnAnchorLocated()
    {
        mainLevel.SetActive(true);
        CancelInvoke("CreateRoomInvoke");
    }



    #endregion


    #region StaticToolFunc

    public static string GetObjFullName(GameObject obj)
    {
        string fullname = obj.name;

        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            fullname = obj.name + "/" + fullname;
        }

        return fullname;
    }



    public static Vector3 String2Vec3(string strVec)
    {
        strVec = strVec.Replace("(", "").Replace(")", "");
        string[] s = strVec.Split(',');

        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }
    #endregion
}
