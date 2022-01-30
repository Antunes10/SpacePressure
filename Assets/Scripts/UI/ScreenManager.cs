using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;

    private event Action OnScreenFade;
    void Start()
    {

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
