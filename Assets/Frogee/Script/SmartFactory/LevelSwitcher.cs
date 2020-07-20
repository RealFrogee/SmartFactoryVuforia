using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : BaseInteractiveObj
{

    public LevelState level;
    public override void OnInteract(Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        LevelController.Instance.SwitchLevel(level);
    }
}
