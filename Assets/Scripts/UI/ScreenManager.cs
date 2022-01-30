using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    private GameManager _gameManager;
    private AudioManager _audioManager;

    private event Action OnScreenFade;
    public event Action ShowingE;
    void Start()
    {
        _gameManager = GameManager.Instance;
        _audioManager = AudioManager.Instance;

        _audioManager.EndLine += FinalLine;
        _gameManager._advQuest += FinalLine;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnScreenFade?.Invoke();
            FadeScreen();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            ShowE();
        }
    }

    void FadeScreen()
    {
        _animator.SetTrigger("Fade");
    }

    void ShowE()
    {
        _animator.SetTrigger("ShowE");
        _animator.SetBool("EShown", !_animator.GetBool("EShown"));
    }

    void FinalLine()
    {
        if(_gameManager._ProgressGame == 0 || _gameManager._ProgressGame == 1)
        {
            ShowingE?.Invoke();
            Debug.Log("SHOW E");
            ShowE();
        }
    }


    #region Singleton

    private static ScreenManager _instance;

    public static ScreenManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<ScreenManager>();
            return _instance;
        }
    }

    #endregion

}
