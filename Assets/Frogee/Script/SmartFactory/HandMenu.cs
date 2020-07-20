using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetHandPos(Handedness.Left);
    }


    Vector3 GetHandPos(Handedness hand)
    {
        Ray ray;
        Vector3 pos = new Vector3(100, 100, 100);
        if (InputRayUtils.TryGetHandRay(hand, out ray))
        {
            pos = ray.origin;
        }

        return pos;
    }
}
