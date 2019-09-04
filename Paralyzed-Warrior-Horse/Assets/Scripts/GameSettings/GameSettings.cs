using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "CreateGameSettings/GameSettings", fileName = "GameSettings")]
[Serializable]
public class GameSettings : ScriptableObject
{
    public float Balance;
    public float CurrentMod;
    public float MinionNb;
    public float PriceModif;
    public float PriceMinion;
    public float BalanceAdsView;
    public float DeltaAdsView;
    public List<Vector2> MinionCoords;
    public List<int> MinionDateNb;
}
