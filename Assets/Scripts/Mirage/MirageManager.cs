using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MirageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action Mirage;
    private bool lockmirage = true;

    private GameManager _gameManager;
    private ScreenManager _screenManager;
    void Start()
    {
        _gameManager = GameManager.Instance;
        _screenManager = ScreenManager.Instance;
        _screenManager.ShowingE += UnlockMirage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !lockmirage)
        {
            Mirage?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private void UnlockMirage()
    {
        lockmirage = false;
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
