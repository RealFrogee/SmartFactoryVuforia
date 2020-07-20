using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMono<T> : MonoBehaviour where T:class{

    private static  T instance;
    
    public  static T Instance
    {
        get { return instance; }
        private set
        {
            instance = value;
        }
    }
    protected  virtual void Awake()
    {
        Instance = this as T;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
