using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    private GameManager _gameManager;
    private AudioManager _audioManager;

    [SerializeField] private TextMeshProUGUI _timer;

    private int count = 0;
    private float _timernumber;

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

        _timernumber = GameManager.Instance._timeRemaining;
        int minutes = Mathf.FloorToInt(_timernumber / 60F);
        int seconds = Mathf.FloorToInt(_timernumber % 60F);
        _timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
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
        if((_gameManager._ProgressGame == 0 || _gameManager._ProgressGame == 1) && count < 2)
        {
            ShowingE?.Invoke();
            ShowE();
            count += 1;
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
