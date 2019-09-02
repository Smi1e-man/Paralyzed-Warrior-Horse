using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateGameSettings/ModifierSettings", fileName = "ModifierSettings")]
public class ModifierSettings : ScriptableObject
{
    [SerializeField, Range(1.1f, 10f)] private float _deltaClickPrice;
    [SerializeField, Range(1.1f, 10f)] private float _deltaClickBoost;

    public float DeltaClickPrice => _deltaClickPrice;
    public float DeltaClickBoost => _deltaClickBoost;
}