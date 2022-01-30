using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _radioSource;
    [SerializeField] private AudioSource _uiSource;

    [SerializeField] private SoundClip[] _radioClips;
    [SerializeField] private TextMeshProUGUI _text;

    public event Action EndLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRadioSound(int newSound)
    {
        _radioSource.clip = _radioClips[newSound].Clip;
        _radioSource.Play();
        StartCoroutine(SubtitlesPlay(_radioClips[newSound]));
    }

    /*[Serializable]
    public struct SoundClip
    {
        public AudioClip Clip;
        public SubtitleLine[] Lines;
        public bool loopable;
    }

    [Serializable]
    public struct SubtitleLine
    {
        public String line;
        public float wait;
    }*/

    public enum RadioSounds
    {
        RadioIntro = 0,
        FirstDoor = 1,
        OneFilter = 2,
        AliceFallingHard = 3,
        AliceColliding = 4,
        AliceCoughing = 5,
        AliceScreaming = 6,
        AliceCrying = 8,
        AliceGrowing = 9,
        AliceShrinking = 10,
        AliceGravity = 11
    }

    IEnumerator SubtitlesPlay(SoundClip soundclips)
    {
        foreach(SoundClip.SubtitleLine sb in soundclips.Lines)
        {
            if(sb.endline == true)
            {
                EndLine?.Invoke();
            }
            _text.text = sb.line;
            yield return new WaitForSeconds(sb.wait);
        }
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
