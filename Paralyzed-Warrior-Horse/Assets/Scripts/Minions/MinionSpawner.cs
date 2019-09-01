using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    //private visual values
    [SerializeField] private List<MinionsData> _minionsData;
    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _minionPrefab;
    [SerializeField] private Transform _minionParentZone;
    [SerializeField] private float _borderWidth;
    [SerializeField] private float _borderHeight;


    //public values
    public static Dictionary<GameObject, Minion> _minions;

    //private values
    private Queue<GameObject> _currentMinions;

    private void Start()
    {
        _minions = new Dictionary<GameObject, Minion>();
        _currentMinions = new Queue<GameObject>();
        for (int i = 0; i < _poolCount; ++i)
        {
            var prefab = Instantiate(_minionPrefab, _minionParentZone, true);
            var script = prefab.GetComponent<Minion>();
            prefab.SetActive(false);
            _minions.Add(prefab, script);
            _currentMinions.Enqueue(prefab);
        }
        BuyMinionManager.AddMinion += SpawnMinion;
    }

    private void SpawnMinion(float minionNb)
    {
        if (_currentMinions.Count > 0 && minionNb < _poolCount)
        {
            var minion = _currentMinions.Dequeue();
            var script = _minions[minion];
            minion.SetActive(true);

            //rand position in minion zone
            float posX = Random.Range(-_borderWidth, _borderWidth);
            float posY = Random.Range(-_borderHeight, _borderHeight);
            //rand minion settings
            int rand = Random.Range(0, _minionsData.Count);

            Vector2 _newCoord = new Vector2(posX, posY);
            //save coords in asset
            GameManager._Gm.AddMinionPos(rand, _newCoord);

            minion.transform.position = _newCoord;
            script.ValueInit(_minionsData[rand]);
        }
    }

    private void ReturnMinion(GameObject minion)
    {
        minion.SetActive(false);
        _currentMinions.Enqueue(minion);
    }
}
