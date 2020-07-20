using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CarMenuBackBtn_BIO : BaseInteractiveObj
{
    public Sprite hoveredSprite;
    Sprite unHoveredSprite;
    SpriteRenderer sr;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        unHoveredSprite = sr.sprite;
    }
    

    public override void OnPointerHover(FocusEventData eventData)
    {
        base.OnPointerHover(eventData);
        sr.sprite = hoveredSprite;
        //unHoveredSprite.texture.
    }

    public override void OnPointerUnhover(FocusEventData eventData)
    {
        base.OnPointerUnhover(eventData);
        sr.sprite = unHoveredSprite;
    }

    public override void OnInteract(MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        LevelController.Instance.ShowObjEnd();

    }

    private void OnDisable()
    {
        sr.sprite = unHoveredSprite;
    }

}
