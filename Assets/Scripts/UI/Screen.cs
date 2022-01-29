using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Screen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator _animator;
    private AudioManager _audioM;

    private event Action OnScreenFade;
    void Start()
    {
        _audioM = AudioManager.Instance;
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
            _audioM.PlayRadioSound(0);
        }
    }

    void FadeScreen()
    {
        _animator.SetTrigger("Fade");
    }
}
