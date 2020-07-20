using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectMenuController : MonoBehaviour
{
    public GameObject produceLineBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(ShowProducelineBtnDelay());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        produceLineBtn.SetActive(false);
    }


    IEnumerator ShowProducelineBtnDelay()
    {
        yield return new WaitForSeconds(3f);
        produceLineBtn.SetActive(true);
    }
}
