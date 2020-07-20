using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

[RequireComponent(typeof(BoxCollider))]
public class CarSelect_BIO : BaseInteractiveObj
{
    public GameObject carPrefab;
    public ShowMenuType showMenuType=ShowMenuType.Normal;
    public override void OnInteract(MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        //LevelController.Instance.ShowObj(carPrefab,showMenuType);
    }
}
