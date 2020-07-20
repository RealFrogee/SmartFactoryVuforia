using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour
{
    public Transform tipTexture;
    public Transform tipPath;
    public Transform tipPoint;
    //public float pathWidth = 0.5f;
    //SpriteRenderer sr;
    float spriteOffsetX;
    float spriteOffsetY;
    bool bTexOnLeft = true;
   public bool bShow = false;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = tipTexture.GetComponent<SpriteRenderer>();
        spriteOffsetX = sr.sprite.texture.width / 2;
        spriteOffsetY = sr.sprite.texture.height / 2;
        bTexOnLeft = tipTexture.localPosition.x > tipPoint.localPosition.x ? true : false;
        tipTexture.gameObject.SetActive(false);
        tipPath.gameObject.SetActive(false);

        if(bShow)
        {
            ShowTip(bShow);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (bShow)
        {
           
            
                tipPath.position = (GetPathEndPosLossy()+ tipPoint.position) / 2;
                Vector3 dis = GetPathEndPosLossy() - tipPoint.position;

                tipPath.rotation = Quaternion.LookRotation(dis);
                tipPath.localEulerAngles += new Vector3(90f, 0, 0);

                tipPath.localScale = new Vector3(tipPath.localScale.x, 0.25f * Vector3.Distance(GetPathEndPosLossy(), tipPoint.position)/transform.lossyScale.x, tipPath.localScale.x);
           
        }


    }

    public void ShowTip(bool show)
    {
        bShow = show;
        if (bShow)
        {
            tipPath.gameObject.SetActive(true);
            tipTexture.gameObject.SetActive(true);
        }
        else
        {
            tipPath.gameObject.SetActive(false);
            tipTexture.gameObject.SetActive(false);
        }
    }

   // Vector3 GetPathEndPos()
   // {
   //     if(bTexOnLeft)
   //     {
   //         return tipTexture.position + tipTexture.right * spriteOffsetX * 0.01f * tipTexture.localScale.x - tipTexture.up * spriteOffsetY * 0.01f * tipTexture.localScale.y;
   //     }
   //     else
   //     {
   //         return tipTexture.position + tipTexture.right * -spriteOffsetX * 0.01f * tipTexture.localScale.x - tipTexture.up * spriteOffsetY * 0.01f * tipTexture.localScale.y;
   //     }
   //     
   // }

    Vector3 GetPathEndPosLossy()
    {
        if (bTexOnLeft)
        {
            return tipTexture.position + tipTexture.right * spriteOffsetX * 0.01f * tipTexture.lossyScale.x - tipTexture.up * spriteOffsetY * 0.01f * tipTexture.lossyScale.y;
        }
        else
        {
            return tipTexture.position + tipTexture.right * -spriteOffsetX * 0.01f * tipTexture.lossyScale.x - tipTexture.up * spriteOffsetY * 0.01f * tipTexture.lossyScale.y;
        }
    }
}
