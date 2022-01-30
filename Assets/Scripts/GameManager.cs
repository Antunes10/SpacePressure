using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private MirageManager _mirManager;
    private AudioManager _audioManager;
    private bool _onMirageWorld = false;
    public int _ProgressGame = 0;
    private int _RadioProgMirage = 0;
    private int _RadioProgNarrative = 0;
    private int _ProgressDementia = 1;

    [SerializeField]  private float _timeRemaining;
    [SerializeField] private Camera _cam;
    [SerializeField] private Volume _volume;

    public event Action _advQuest;
    void Start()
    {
        _mirManager = MirageManager.Instance;
        _audioManager = AudioManager.Instance;
        _mirManager.Mirage += ChangeWorld;

        _audioManager.PlayRadioSound(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_onMirageWorld)
        {
            _timeRemaining -= Time.deltaTime;
            _volume.weight = 1 - _timeRemaining / 45;

            if(_volume.weight > 0.2 * _ProgressDementia && _ProgressDementia < 5)
            {
                _ProgressDementia += 1;
                Debug.Log(_ProgressDementia);
            }
        }
        //Debug.Log(_timeRemaining);
    }

    void ChangeWorld()
    {
        _onMirageWorld = !_onMirageWorld;
        if (!_onMirageWorld)
        {
            _cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Number"));
        }
        else
        {
            _cam.cullingMask = -1;
        }
    }

    public void AdvanceQuest()
    {
        _ProgressGame += 1;
        _advQuest?.Invoke();
    }

    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    #endregion
}
