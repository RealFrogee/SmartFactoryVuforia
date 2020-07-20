using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;

//[RequireComponent(typeof(BoxCollider))]
public class CarRotScale_BIO : BaseInteractiveObj
{
    public GameObject testRot;//for test

    public float rotSpeed = 1000f;
    public float scaleSpeed = 2f;

   

    public float msgInterval = 1f;
    float sendMsgCoolDownTime = 0f;
    Transform controlTrans;
    

    bool onRot = false;
    bool onScale = false;
   
    
    private void Awake()
    {
       
        controlTrans = transform;

        sendCustomMsgOnClick = false;
        thisMsg = new MsgClass();
    }
   
    
    protected  void Update()
    {
   
        if(onRot)
        {
            SendMsgCoolDown();
        }
        if(onScale)
        {
            SendMsgCoolDown();
        }
    }

    public void SwitchSendCarRotMsg(bool bRot)
    {
        onRot = bRot;
        if(!onRot)
        {
            SendRotMsg();
        }
    }

    public void SwitchSendCarScaleMsg(bool bScale)
    {
        onScale = bScale;
        if(!onScale)
        {
            SendScaleMsg();
        }
    }

    public override void OnInteract(MixedRealityPointerEventData eventData = null)
    {
       // base.OnInteract(eventData);
       // if (eventData.Handedness == Handedness.Right)
       // {
       //
       //     startRHandPos = LevelController.GetHandPos(Handedness.Right);
       //     if (lHandDown != true)
       //         startRot = controlTrans.localEulerAngles;
       //     rHandDown = true;
       // }
       // else if (eventData.Handedness == Handedness.Left)
       // {
       //
       //     startLHandPos = LevelController.GetHandPos(Handedness.Left);
       //     if (rHandDown != true)
       //         startRot = controlTrans.localEulerAngles;
       //     lHandDown = true;
       // }
       //
       // if (rHandDown && lHandDown)
       // {
       //     SendRotMsg();
       //     startRHandPos = LevelController.GetHandPos(Handedness.Right);
       //     startLHandPos = LevelController.GetHandPos(Handedness.Left);
       //     startScale = controlTrans.localScale;
       //
       // }

    }

    



    void SendMsgCoolDown()
    {
        if (sendMsgCoolDownTime <= msgInterval)
        {
            sendMsgCoolDownTime += Time.deltaTime;
        }
        else
        {

            if (onScale)
            {
                SendScaleMsg();
            }
            else if(onRot)
            {
                SendRotMsg();
            }
        }
    }

   public void SendRotMsg()
    {
        sendMsgCoolDownTime = 0f;
        thisMsg = new MsgClass();
        thisMsg.msgType = MsgType.OnRot;
        
        if (testRot != null)
            thisMsg.objName = LevelController.GetObjFullName(testRot);//for test
        else
            thisMsg.objName = LevelController.GetObjFullName(gameObject);

       
        thisMsg.parameter = controlTrans.localEulerAngles.ToString();
        FroHoloUdp.Instance.AsyncSend(JsonHandle.Msg2Json(thisMsg));
    }
   public void SendScaleMsg()
    {
        sendMsgCoolDownTime = 0f;
        thisMsg = new MsgClass();
        thisMsg.msgType = MsgType.OnScale;
       
        if (testRot != null)
            thisMsg.objName = LevelController.GetObjFullName(testRot);//for test
        else
            thisMsg.objName = LevelController.GetObjFullName(gameObject);
        thisMsg.parameter = controlTrans.localScale.ToString();

        FroHoloUdp.Instance.AsyncSend(JsonHandle.Msg2Json(thisMsg));

    }


    public  void OnGetRotMsg(string rotTo)
    {
        
       // Debug.Log(rotTo);
        Vector3 temp = LevelController.String2Vec3(rotTo);
       // Debug.Log(temp);
        StartCoroutine(RotCarIEnum(temp));
    }

    IEnumerator RotCarIEnum(Vector3 rotTo)
    {
        Vector3 startRot = controlTrans.localEulerAngles;
        float currentTime = 0f;
        while(currentTime<= msgInterval)
        {
            currentTime += Time.deltaTime;
            controlTrans.localEulerAngles = Vector3.Lerp(startRot, rotTo, currentTime / msgInterval);
            // transform.localEulerAngles = new Vector3(0, Mathf.Lerp(startRot.y, rotTo.y, currentTime / msgInterval));
            yield return null;
        }
    }
    public  void OnGetScaleMsg(string scaleTo)
    {
        
        Vector3 temp = LevelController.String2Vec3(scaleTo);
        StartCoroutine(ScaleCarIEnum(temp));
    }

    IEnumerator ScaleCarIEnum(Vector3 scaleTo)
    {
        Vector3 startScale = controlTrans.localScale;
        float currentTime = 0f;
        while(currentTime<=msgInterval)
        {
            currentTime += Time.deltaTime;
            controlTrans.localScale = Vector3.Lerp(startScale, scaleTo, currentTime / msgInterval);
            yield return null;
        }
    }



}
