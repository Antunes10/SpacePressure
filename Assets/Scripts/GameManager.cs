using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private MirageManager _mirManager;
    private bool _onMirageWorld = false;
    private int _RadioProgQuests = 0;
    private int _RadioProgMirage = 0;
    private int _RadioProgNarrative = 0;
    private int _ProgressMirage = 0;

    [SerializeField]  private float _timeRemaining;
    [SerializeField] private Camera _cam;
    [SerializeField] private Volume _volume;
    void Start()
    {
        _mirManager = MirageManager.Instance;
        _mirManager.Mirage += ChangeWorld;
    }

    // Update is called once per frame
    void Update()
    {
        if (_onMirageWorld)
        {
            _timeRemaining -= Time.deltaTime;
            _volume.weight = 1 - _timeRemaining / 45;
        }
        Debug.Log(_timeRemaining);
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
}
