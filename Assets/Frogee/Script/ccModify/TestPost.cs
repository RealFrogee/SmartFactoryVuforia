using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendGet("http://10.4.20.45:88/momtoar/WebService.asmx/GetNumByCtype?Ctype=HS5"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendGet(string url)
    {
        WWW getdata = new WWW(url);
        yield return getdata;
        if(getdata.error!=null)
        {
            Debug.Log(getdata.error);
        }
        else
        {
            Debug.Log(getdata.text);
        }
    }
}
