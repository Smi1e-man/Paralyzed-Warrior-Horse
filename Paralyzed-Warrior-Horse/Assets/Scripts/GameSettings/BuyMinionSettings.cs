using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateGameSettings/BuyMinionSettings", fileName = "BuyMinionSettings")]
public class BuyMinionSettings : ScriptableObject
{
    [SerializeField] private float _minionPrice;
    [SerializeField] private float _minionNb;
    [SerializeField] private float _deltaMinionBoost;
    [SerializeField, Range(1.1f, 10f)] private float _deltaMinionPrice;
    [SerializeField] private List<Vector2> _minionCurrentPos;

    public float MinionPrice => _minionPrice;
    public float MinionNb => _minionNb;
    public float DeltaMinionBoost => _deltaMinionBoost;
    public float DeltaMinionPrice => _deltaMinionPrice;

    public List<Vector2> MinionCurrentPos { get => _minionCurrentPos; set => _minionCurrentPos = value; }
}
