using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System;
using System.Text;
using UnityEngine;



public class FroHoloUdp : MonoBehaviour
{
    public static FroHoloUdp Instance;
    FroDatagarmUDP server;
   // public AnchorModuleScript anchorController;
    public GameObject RootObj;
    #region legacy property


    // List<string> msgList = new List<string>();
    public int msgCount { get { return server.msg.Count; } }
    [HideInInspector]
    public string localIP;
    [HideInInspector]
    public bool canSend = true;
    [HideInInspector]
    public bool canRecv = true;

    #endregion

    private void Awake()
    {
        //Debug.Log("init");
        Instance = this;
        InitUDP();


    }

    private void Start()
    {
        //  Debug.Log("start");
        // JoinGroup();
        Invoke("JoinGroup", 1f);
    }

    void JoinGroup()
    {
        MsgClass temp = new MsgClass();
        temp.msgType = MsgType.JoinRoom;
        temp.objName = "anywhere";
        temp.parameter = localIP;
        server.SendMsg(JsonHandle.Msg2Json(temp));
    }

    void InitUDP()
    {
        server = new FroDatagarmUDP();
        server.InitServer();
        localIP = server.GetLocalIP();
    }

    public void AsyncSend(string msg)
    {
        if (canSend)
        {            
            server.SendMsg(msg);
        }
    }

    public string HandleMsg()
    {
        return server.HandleMsg();
    }


    private void OnDestroy()
    {
        server.CloseDatagarmSocket();

    }





    


}

