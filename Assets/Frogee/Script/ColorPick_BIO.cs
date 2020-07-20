using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ColorPick_BIO : BaseInteractiveObj
{
    public Material colorMat;
    public override void OnInteract(MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        LevelController.Instance.ChangeCarColor(colorMat);
    }
}
