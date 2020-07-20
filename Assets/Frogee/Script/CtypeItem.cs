using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtypeItem : MonoBehaviour
{
    public Text ctypeProduceText;
    public Text ctypeNameText;

    public void InitCtypeItem(string ctypeProduce,string ctypeName)
    {
        ctypeProduceText.text = ctypeProduce;
        ctypeNameText.text = ctypeName;
    }
}
