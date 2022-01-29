using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundClip", menuName = "SoundClip")]
public class SoundClip : ScriptableObject
{
    [System.Serializable]
    public struct SubtitleLine
    {
        public string line;
        public float wait;
    }

    public AudioClip Clip;
    public SubtitleLine[] Lines;
    public bool loopable;

}
