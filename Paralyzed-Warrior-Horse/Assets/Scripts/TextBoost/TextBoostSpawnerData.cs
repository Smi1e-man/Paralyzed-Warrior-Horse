using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextBoostSpawnCreate/TextBoostSpawn", fileName = "TextBoostSpawnData")]
public class TextBoostSpawnerData : ScriptableObject
{
    [SerializeField] private int _poolCount;
    [SerializeField] private TextBoostData _dataBoost;
    [SerializeField] private GameObject _textBoostPrefab;

    public int PoolCount { get => _poolCount; set => _poolCount = value; }
    public TextBoostData DataBoost { get => _dataBoost; set => _dataBoost = value; }
    public GameObject TextBoostPrefab { get => _textBoostPrefab; set => _textBoostPrefab = value; }
}
