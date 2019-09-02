using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoostSpawner : MonoBehaviour
{
    //private values
    private TextBoostSpawnerData _data;
    private Queue<GameObject> _currentTextBoosts;

    //public values
    private Dictionary<GameObject, TextBoost> _textes;

    //public methods;
    public void InitValue(TextBoostSpawnerData data)
    {
        _data = data;
        //init pool
        InitPool();
    }
    //private methods;
    private void InitPool()
    {
        _textes = new Dictionary<GameObject, TextBoost>();
        _currentTextBoosts = new Queue<GameObject>();
        for (int i = 0; i < _data.PoolCount; ++i)
        {
            var prefab = Instantiate(_data.TextBoostPrefab, transform, true);
            var script = prefab.GetComponent<TextBoost>();
            prefab.transform.localScale = Vector3.one;
            prefab.SetActive(false);
            _textes.Add(prefab, script);
            _currentTextBoosts.Enqueue(prefab);
        }
    }

    private void ReturnText(GameObject boostText)
    {
        _currentTextBoosts.Enqueue(boostText);
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void AddText(float textBoost, Vector2 pos)
    {
        if (_currentTextBoosts.Count > 0)
        {
            var boostText = _currentTextBoosts.Dequeue();
            var script = _textes[boostText];
            boostText.SetActive(true);

            boostText.transform.position = transform.position;
            script.InitValue(_data.DataBoost, textBoost, pos);
            ReturnText(boostText);
        }
    }
}
