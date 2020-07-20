using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NBDController : MonoBehaviour
{

    public GameObject[] objsToShow;
    public GameObject[] tips;
    public AudioClip speechClip;
    public AudioClip audioEffect;
    

    private void Awake()
    {
       
        
    }

    private void OnEnable()
    {
        StartCoroutine(ShowUIDelay());
        
    }

    private void OnDisable()
    {
        foreach (var item in objsToShow)
        {
            item.SetActive(false);
        }
        foreach (var item in tips)
        {
            item.SetActive(false);
        }
        
    }


    IEnumerator ShowUIDelay()
    {
        yield return new WaitForSeconds(2f);
        LevelController.Instance.PlayEffectSound(audioEffect);
        yield return new WaitForSeconds(3f);
        foreach (var item in objsToShow)
        {
            item.SetActive(true);
        }
        LevelController.Instance.PlayAudio(speechClip);
       


    }

    
}
