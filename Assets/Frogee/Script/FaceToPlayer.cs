using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToPlayer : MonoBehaviour
{
    public Transform player;
    public bool lockXAxis = true;
    Vector3 faceRot;
    public bool flipY = false;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = Camera.main.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (flipY)
        {
            faceRot = Quaternion.LookRotation(player.position - transform.position).eulerAngles + new Vector3(0, 180f, 0);
        }
        else
            faceRot = Quaternion.LookRotation(player.position - transform.position).eulerAngles;
        if (lockXAxis)
            transform.eulerAngles = new Vector3(0, faceRot.y, 0);
        else
            transform.eulerAngles = new Vector3(faceRot.x, faceRot.y, 0);
    }
}
