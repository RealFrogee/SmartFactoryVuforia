using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Utility
    {
        public static Transform findChild(Transform transParent, string childName)
        {
            Transform transChild = transParent.Find(childName);
            if (transChild == null)//如果没有找到
            {
                foreach (Transform t in transParent)//父物体下面的所有子物体
                {
                    transChild = findChild(t, childName);
                    if (transChild != null)
                    {
                        return transChild;
                    }
                }
            }
            return transChild;
        }


    }
}
