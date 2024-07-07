using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCanvas : MonoBehaviour
{
    public static PassCanvas instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
