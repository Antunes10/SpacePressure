using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceTrigger : MonoBehaviour
{
    private AudioManager _audioManager;
    private GameManager _gameManager;
    [SerializeField] bool _progress;

    [SerializeField] private int _clip;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.Instance;
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioManager.PlayRadioSound(_clip);
        if (_progress)
        {
            _gameManager.AdvanceQuest();
        }
        gameObject.SetActive(false);
    }
}
