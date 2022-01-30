using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockageIntro : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioManager _audioManager;
    private GameManager _gameManager;
    void Start()
    {
        _audioManager = AudioManager.Instance;
        _gameManager = GameManager.Instance;
        _audioManager.EndLine += StopBlocking;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopBlocking()
    {
        if(_gameManager._ProgressGame == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
