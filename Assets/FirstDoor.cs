using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    private AudioManager _audioManager;

    [SerializeField] private int _clip;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioManager.PlayRadioSound(_clip);
        gameObject.SetActive(false);
    }
}
