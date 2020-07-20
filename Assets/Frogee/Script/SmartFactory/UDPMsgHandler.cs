
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDPMsgHandler : MonoBehaviour
{

    FroHoloUdp myUDP;
    MsgClass recvdMsg;
    string msg;
    //public AnchorModuleScript anchorManager;

    
    // Start is called before the first frame update
    void Start()
    {
        myUDP = FroHoloUdp.Instance;
    }

    // Update is called once per frame
    void Update()
    {
      

      if(myUDP.msgCount>0)
      {
          msg = myUDP.HandleMsg();
          Debug.Log(msg);
            recvdMsg = JsonHandle.Json2Msg(msg);
            switch (recvdMsg.msgType)
            {
                case MsgType.ShareAnchor:
                   // anchorManager.currentAzureAnchorID = recvdMsg.parameter;
                    //anchorManager.FindAzureAnchor();
                  //  anchorManager.SaveAzureAnchorIdToDisk();
                    Debug.Log(recvdMsg.objName + "  OK");
                    break;
            }
      //    if(myUDP.canRecv)
      //    {
      //        recvdMsg = JsonHandle.Json2Msg(msg);
      //        switch (recvdMsg.msgType)
      //        {
      //            case MsgType.OnClick:
      //                //GameObject.Find(recvdMsg.objName).GetComponent<UIScript>().MsgCurlAlarm();
      //                GameObject.Find(recvdMsg.objName).GetComponent<BaseInteractiveObj>().OnInteract();
      //                break;
      //            case MsgType.OnRot:
      //                GameObject.Find(recvdMsg.objName).GetComponent<CarRotScale_BIO>().OnGetRotMsg(recvdMsg.parameter);
      //                break;
      //            case MsgType.OnScale:
      //                GameObject.Find(recvdMsg.objName).GetComponent<CarRotScale_BIO>().OnGetScaleMsg(recvdMsg.parameter);
      //                break;
      //            case MsgType.Room:
      //                myUDP.canSend = false;
      //                break;
      //            default:
      //                break;
      //        }
      //    }
      }
    }


    public void ShareAnchor()
    {

        //Debug.Log(anchorManager.currentAzureAnchorID);
     //   MsgClass shareAnchorMsg = new MsgClass();
     //   shareAnchorMsg.msgType = MsgType.ShareAnchor;
     //   shareAnchorMsg.objName = "shareAnchor";
     //   shareAnchorMsg.parameter = anchorManager.currentAzureAnchorID;
     //   FroHoloUdp.Instance.AsyncSend(JsonHandle.Msg2Json(shareAnchorMsg));
        
    }
}
