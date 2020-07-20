using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColorController : MonoBehaviour
{
    public GameObject[] colorMesh;
    public GameObject colorMeshAdd;

    public virtual void ChangeColor(Material colorMaterial)
    {
       foreach (var item in colorMesh)
       {
           item.GetComponent<MeshRenderer>().material = colorMaterial;
       }
    }
   
}
