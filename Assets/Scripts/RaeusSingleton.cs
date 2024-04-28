using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaeusSingleton : MonoBehaviour
{
    public static RaeusSingleton Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this) 
        {
            Debug.LogError("This Singleton should not be here, 2 or more singletons in scene");
            Destroy(this.gameObject);
            return;
        }      
        Instance = this;  
        //DontDestroyOnLoad(this);
        //Init();
    }
}
