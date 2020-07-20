using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTip_BIO : BaseInteractiveObj
{
    public GameObject tip;
    public override void OnInteract(Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        tip.SetActive(true);
    }
}
