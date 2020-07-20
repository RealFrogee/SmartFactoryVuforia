using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFixRot : MonoBehaviour
{
    public void AutoFix()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}
