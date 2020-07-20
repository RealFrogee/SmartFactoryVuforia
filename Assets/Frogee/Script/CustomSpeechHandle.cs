using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSpeechHandle : MonoBehaviour
{
    public BaseInteractiveObj interactiveObj;
    // Start is called before the first frame update
    public void SpeechFunc()
    {
        Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData tempEventData = new Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData(UnityEngine.EventSystems.EventSystem.current);
        interactiveObj.OnPointerDown(tempEventData);

    }
}
