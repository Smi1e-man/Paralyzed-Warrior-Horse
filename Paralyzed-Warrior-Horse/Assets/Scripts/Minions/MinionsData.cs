using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "Minions/New Minion", fileName = "New Minion")]
public class MinionsData : ScriptableObject
{
    //private visual values
    [SerializeField] private Sprite _mainSprite;
    [SerializeField] private GameObject _textBoost;
    [SerializeField] private int _boostBalance;
    [SerializeField] private float _deltaBoostTime;

    /// <summary>
    /// Public Methods. 
    /// </summary>
    public Sprite MainSprite { get => _mainSprite; set => _mainSprite = value; }
    public GameObject TextBoost { get => _textBoost; set => _textBoost = value; }
    public int BoostBalance { get => _boostBalance; set => _boostBalance = value; }
    public float DeltaBoostTime { get => _deltaBoostTime; set => _deltaBoostTime = value; }
}
