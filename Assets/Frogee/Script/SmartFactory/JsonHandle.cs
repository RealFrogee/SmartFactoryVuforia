using LitJson;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public enum MsgType
{
  
    OnClick,
    JoinRoom,
    Room,
    StartGame,
    OnRot,
    OnScale,
    ShareAnchor
   
}

[System.Serializable]
public class MsgClass
{
    public MsgType msgType;
    public string objName;
    public string parameter;
}
public class JsonHandle 
{
   

    public static string Msg2Json(MsgClass msg)
    {
        string jsonString = JsonMapper.ToJson(msg);

        return jsonString;
    }

    public static MsgClass Json2Msg(string msgString)
    {
        MsgClass msg = JsonMapper.ToObject<MsgClass>(msgString);

        return msg;
    }

}
