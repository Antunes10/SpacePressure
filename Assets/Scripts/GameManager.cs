using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private MirageManager _mirManager;
    private bool _onMirageWorld;

    [SerializeField]  private float _timeRemaining;
    void Start()
    {
        _mirManager = MirageManager.Instance;
        _mirManager.Mirage += ChangeWorld;
        _timeRemaining = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (_onMirageWorld)
        {
            _timeRemaining -= Time.deltaTime;
        }
        Debug.Log(_timeRemaining);
    }

    void ChangeWorld()
    {
        _onMirageWorld = !_onMirageWorld;
    }
}
