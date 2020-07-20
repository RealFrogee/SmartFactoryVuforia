using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;


[SerializeField]
public enum RotAxis
{
    x,
    y,
    z
}
[RequireComponent(typeof(BoxCollider))]
public class CarDoor_BIO : BaseInteractiveObj
{
    protected bool bOpen;
    private BoxCollider boxCollider;
    float OpenTime = 2f;

    public float rotValue = 60f;
    public RotAxis rotAxis = RotAxis.x;
    AudioClip openDoorClip;
    AudioClip closeDoorClip;

    bool canHandTouch = true;

    private void Awake()
    {
        openDoorClip = Resources.Load<AudioClip>("Sound/UI Sound/S_Open");
        closeDoorClip = Resources.Load<AudioClip>("Sound/UI Sound/S_Closed");
        // openDoorClip = (AudioClip)Resources.Load("Sound/S_Open") as AudioClip;
        boxCollider = GetComponent<BoxCollider>();
    }
    public override void OnInteract(MixedRealityPointerEventData eventData)
    {
        base.OnInteract(eventData);
       
            StartCoroutine(OpenDoor());
        
            
    }

    IEnumerator OpenDoor()
    {
        if(canHandTouch)
        {
            canHandTouch = false;
            if (bOpen)
                OpenHoodEvent(!bOpen);
            boxCollider.enabled = false;
            float realRotValue = bOpen ? rotValue : -rotValue;
            Vector3 starRotVector = transform.localEulerAngles;
            Vector3 rotVector = Vector3.zero;
            switch (rotAxis)
            {
                case RotAxis.x:
                    rotVector = transform.localEulerAngles + new Vector3(realRotValue, 0, 0);
                    break;
                case RotAxis.y:
                    rotVector = transform.localEulerAngles + new Vector3(0, realRotValue, 0);
                    break;
                case RotAxis.z:
                    rotVector = transform.localEulerAngles + new Vector3(0, 0, realRotValue);
                    break;

            }
            float lerpTime = 0f;
            OpenDoorSoundEffect(bOpen);
            while (lerpTime <= OpenTime)
            {
                lerpTime += Time.deltaTime;
                transform.localEulerAngles = Vector3.Lerp(starRotVector, rotVector, lerpTime / OpenTime);
                yield return null;
            }
            bOpen = !bOpen;
            OpenHoodEvent(bOpen);
            boxCollider.enabled = true;
            canHandTouch = true;
        }
        
    }


    protected virtual void OpenHoodEvent(bool bOpen)
    {



    }
    void OpenDoorSoundEffect(bool bOpen)
    {
        if (bOpen)
        {
            LevelController.Instance.PlayEffectSound(closeDoorClip);
        }
        else
        {
            LevelController.Instance.PlayEffectSound(openDoorClip);
        }
    }

}
