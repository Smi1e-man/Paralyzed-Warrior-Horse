using System;
using System.IO;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateGameSettings/BuyMinionSettings", fileName = "BuyMinionSettings")]
public class BuyMinionSettings : ScriptableObject
{
    [SerializeField] private float _deltaMinionBoost;
    [SerializeField, Range(1.1f, 10f)] private float _deltaMinionPrice;

    public float DeltaMinionBoost => _deltaMinionBoost;
    public float DeltaMinionPrice => _deltaMinionPrice;
}
