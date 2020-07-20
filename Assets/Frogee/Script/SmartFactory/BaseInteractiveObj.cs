using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

[RequireComponent(typeof(NearInteractionTouchable))]
[RequireComponent(typeof(BoxCollider))]
public class BaseInteractiveObj : MonoBehaviour, IMixedRealityPointerHandler, IMixedRealityTouchHandler,IMixedRealityFocusHandler
{
   
    private bool canTouch = true;
    bool touchComplete = true;
    protected MsgClass thisMsg;
    public bool sendCustomMsgOnClick = true;
    private MsgType msgType = MsgType.OnClick;
    private string msgParameter;


    [Header("Audio")]
    public AudioClip speechClip;
    public AudioClip hoverClip;
    public AudioClip selectClip;

    public UnityEngine.Events.UnityEvent onClick = new UnityEngine.Events.UnityEvent();

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        if (FroHoloUdp.Instance.canSend)
        {
            OnInteract(eventData);
            if (sendCustomMsgOnClick)
            {
                InitMsg();
                FroHoloUdp.Instance.AsyncSend(JsonHandle.Msg2Json(thisMsg));
            }

        }
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {



    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {


    }




    protected virtual void InitMsg()
    {
        thisMsg = new MsgClass();
        thisMsg.msgType = msgType;
        thisMsg.objName = LevelController.GetObjFullName(gameObject);
        thisMsg.parameter = msgParameter;
    }
    
  // protected virtual void Start()
  // {
  //     
  // }
  //
  //
  // protected virtual void Update()
  // {
  //
  // }

    public virtual void OnInteract(MixedRealityPointerEventData eventData = null)
    {
        onClick.Invoke();

        if (hoverClip != null)
        {
            LevelController.Instance.PlayEffectSound(hoverClip);
            
        }
        if (speechClip!=null)
        {
            LevelController.Instance.PlayAudio(speechClip);
        }

    }

    void IMixedRealityTouchHandler.OnTouchStarted(HandTrackingInputEventData eventData)
    {
        if (eventData.Handedness == Microsoft.MixedReality.Toolkit.Utilities.Handedness.Right)
        {
            if (canTouch && touchComplete)
            {
                touchComplete = false;
                if (FroHoloUdp.Instance.canSend)
                {
                    OnInteract();
                    if (sendCustomMsgOnClick)
                    {
                        InitMsg();
                        FroHoloUdp.Instance.AsyncSend(JsonHandle.Msg2Json(thisMsg));
                    }

                }

            }
        }

    }

    void IMixedRealityTouchHandler.OnTouchCompleted(HandTrackingInputEventData eventData)
    {
        if (eventData.Handedness == Microsoft.MixedReality.Toolkit.Utilities.Handedness.Right)
        {
            touchComplete = true;
        }
    }

    void IMixedRealityTouchHandler.OnTouchUpdated(HandTrackingInputEventData eventData)
    {

    }

    public void OnFocusEnter(FocusEventData eventData)
    {
        OnPointerHover(eventData);
    }

    public void OnFocusExit(FocusEventData eventData)
    {
        OnPointerUnhover(eventData);
    }

    public virtual void OnPointerHover(FocusEventData eventData)
    {

    }
    public virtual void OnPointerUnhover(FocusEventData eventData)
    {

    }
}
