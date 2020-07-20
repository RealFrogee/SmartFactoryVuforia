using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TipPoint_BIO : BaseInteractiveObj
{
    public Sprite selectedSprite;
    public Sprite hoverSprite;
    public Sprite normalSprite;
    SpriteRenderer sr;
    TipController tipController;
    bool bOpen = false;

    protected  void Start()
    {
        
        tipController =transform.parent.gameObject.GetComponent<TipController>();
        sr = GetComponent<SpriteRenderer>();
    }

    public override void OnPointerHover(FocusEventData eventData)
    {
        base.OnPointerHover(eventData);
        sr.sprite = hoverSprite;
    }

    public override void OnPointerUnhover(FocusEventData eventData)
    {
        base.OnPointerUnhover(eventData);
        SetSprite();
    }

    public override void OnInteract(MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        bOpen = !bOpen;
        tipController.ShowTip(bOpen);
        SetSprite();



    }

    void SetSprite()
    {
        if (bOpen)
        {
            sr.sprite = selectedSprite;
        }
        else
        {
            sr.sprite = normalSprite;
        }
    }

}
