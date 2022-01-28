using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MirageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action Mirage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Mirage?.Invoke();
        }
    }

    #region Singleton

    private static MirageManager _instance;

    public static MirageManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<MirageManager>();
            return _instance;
        }
    }

    #endregion
}
