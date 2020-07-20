using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleLine : MonoBehaviour
{
  public  Transform triangleUp;
  public  Transform triangleDown;
  public  Transform line;
    // Start is called before the first frame update
    void Start()
    {
       
        //triangleUp.localPosition = line.localPosition + line.up  * line.localScale.y+new Vector3(0,0.15f,0);
        //triangleDown.localPosition = line.localPosition - line.up  * line.localScale.y-new Vector3(0,0.15f,0);
        //triangleUp.localPosition = line.localPosition + line.up * line.localScale.y*2 - new Vector3(0, 0.03f, 0);
        //triangleDown.localPosition = line.localPosition - line.up  * line.localScale.y*2 + new Vector3(0, 0.03f, 0);
       
    }

    // Update is called once per frame
    void Update()
    {
        triangleDown.localPosition = new Vector3(0, Vector3.Magnitude(line.up * 2*line.localScale.y )+0.03f  + line.localPosition.y, 0);
        triangleUp.localPosition = new Vector3(0, -Vector3.Magnitude(line.up * 2*line.localScale.y)-0.03f + line.localPosition.y, 0);
    }
}
