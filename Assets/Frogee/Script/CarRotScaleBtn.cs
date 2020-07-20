using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotScaleBtn : BaseInteractiveObj
{
    SpriteRenderer sr;
    Sprite unSelectedSprite;
    public Sprite selectedSprite;
    bool bSelected = false;
    public GameObject slider;
    public bool colorBtn = false;
    [HideInInspector]
  public  MenuAutoFit menuController;

    private void Awake()
    {
        sendCustomMsgOnClick = false;
        sr = GetComponent<SpriteRenderer>();
        unSelectedSprite = sr.sprite;
    }
    private void OnEnable()
    {
        ResetBtn();
    }


    public override void OnInteract(Microsoft.MixedReality.Toolkit.Input.MixedRealityPointerEventData eventData = null)
    {
        
        base.OnInteract(eventData);
        bSelected = !bSelected;
        if(bSelected)
        {

            menuController.ToggleBtn(gameObject);
          
        }
        else
        {
            if (colorBtn)
            {
                sr.enabled = true;
            }
            else
            {
                sr.sprite = unSelectedSprite;
            }
            
            slider.SetActive(false);
        }
    }

    public void ResetBtn()
    {
        bSelected = false;
        if (colorBtn)
        {
            sr.enabled = true;
        }
        else
        {
            sr.sprite = unSelectedSprite;
        }

        if(!colorBtn)
        {
            slider.SetActive(true);
            slider.GetComponent<Microsoft.MixedReality.Toolkit.UI.PinchSlider>().SliderValue = 0f;
            slider.SetActive(false);
        }
        
    }


    public void SwitchBtnState(bool toggleOn)
    {
        if(toggleOn)
        {
            bSelected = true;
            if (colorBtn)
            {
                sr.enabled = false;
            }
            else
            {
                sr.sprite = selectedSprite;
            }

            slider.SetActive(true);

        }
        else
        {
            bSelected = false;
            if (colorBtn)
            {
                sr.enabled = true;
            }
            else
            {
                sr.sprite = unSelectedSprite;
            }

            slider.SetActive(false);
        }

    }

    
}
