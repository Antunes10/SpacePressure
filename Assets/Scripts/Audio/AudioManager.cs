using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _radioSource;
    [SerializeField] private AudioSource _uiSource;

    [SerializeField] private SoundClip[] _radioClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRadioSound(RadioSounds newSound)
    {
        var i = (int)newSound;
        _radioSource.clip = _radioClips[i].Clip;
        _radioSource.Play();
    }

    [Serializable]
    public struct SoundClip
    {
        public AudioClip Clip;
        public bool loopable;
    }

    public enum RadioSounds
    {
        RadioIntro = 0,
        AliceJumping = 2,
        AliceFalling = 3,
        AliceFallingHard = 4,
        AliceColliding = 5,
        AliceCoughing = 6,
        AliceScreaming = 7,
        AliceCrying = 8,
        AliceGrowing = 9,
        AliceShrinking = 10,
        AliceGravity = 11
    }

    #region Singleton

    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<AudioManager>();
            return _instance;
        }
    }

    #endregion
}
