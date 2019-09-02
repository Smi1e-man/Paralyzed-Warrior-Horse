using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextBoostCreate/TextBoostData", fileName = "TextBoostData")]
public class TextBoostData : ScriptableObject
{
    //visual private
    [SerializeField, Range(0f, 2000f)] private float _endMove;
    [SerializeField, Range(0f, 5f)] private float _timeMove;
    [SerializeField, Range(0f, 1f)] private float _endFade;
    [SerializeField, Range(0f, 5f)] private float _timeFade;
    [SerializeField, Range(0f, 5f)] private float _startFade;

    //public methods
    public float EndMove { get => _endMove; set => _endMove = value; }
    public float TimeMove { get => _timeMove; set => _timeMove = value; }
    public float EndFade { get => _endFade; set => _endFade = value; }
    public float TimeFade { get => _timeFade; set => _timeFade = value; }
    public float StartFade { get => _startFade; set => _startFade = value; }
}
