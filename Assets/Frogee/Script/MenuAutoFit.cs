using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAutoFit : MonoBehaviour
{
    public GameObject backBtn;
    public Transform[] colorPicker;
    public Transform[] btns;
    
    public GameObject[] toggleBtns;
    // Start is called before the first frame update

   
    void Start()
    {
        for (int i = 0; i < toggleBtns.Length; i++)
        {
            toggleBtns[i].GetComponent<CarRotScaleBtn>().menuController = this;
        }
    }

 


    void AutoFit()
    {
        Vector3 btnStartPos = Vector3.zero;
        if (backBtn.activeInHierarchy==true)
        {
            btnStartPos = new Vector3(0, -0.45f, 0);
        }

       
        foreach (var item in colorPicker)
        {
            if(item.gameObject.activeSelf==true)
            {
                item.localPosition = btnStartPos;
                btnStartPos += new Vector3(0, -0.45f, 0);              
                break;
            }
        }
        
       

        for (int i = 0; i < btns.Length; i++)
        {
            if(btns[i].gameObject.activeSelf==true)
            {
                btns[i].localPosition = btnStartPos;
                btnStartPos += new Vector3(0, -0.45f, 0);
            }
        }


    }

    public void ToggleBtn(GameObject btn)
    {
        for (int i = 0; i < toggleBtns.Length; i++)
        {
            if(toggleBtns[i]==btn)
            {
                toggleBtns[i].GetComponent<CarRotScaleBtn>().SwitchBtnState(true);
            }
            else
            {
                if(toggleBtns[i].activeInHierarchy==true)
                toggleBtns[i].GetComponent<CarRotScaleBtn>().SwitchBtnState(false);
            }
        }
    }

    private void OnEnable()
    {
     
        AutoFit();
    }
}
