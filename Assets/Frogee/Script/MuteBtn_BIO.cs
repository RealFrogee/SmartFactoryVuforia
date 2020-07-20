using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBtn_BIO : BaseInteractiveObj
{
    public Sprite selectedSprite;
    Sprite unSelectedSprite;
    SpriteRenderer sr;
    bool bMute = false;
    protected  void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        unSelectedSprite = sr.sprite;

    }


    public override void OnInteract(MixedRealityPointerEventData eventData = null)
    {
        base.OnInteract(eventData);
        bMute = !bMute;
        if(bMute)
        {
            sr.sprite = selectedSprite;
        }
        else
        {
            sr.sprite = unSelectedSprite;
        }
        LevelController.Instance.MuteAudio(bMute);

    }
}
