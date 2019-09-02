using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawnerOld : MonoBehaviour
{
    //visual private values
    [SerializeField] private List<MinionsData> _minionsData;
    [SerializeField] private GameObject _minionPrefab;
    [SerializeField] private Transform _minionParentZone;

    public void SpawnMinions(List<Vector2> coords, List<int> dataNb)
    {
        int count = coords.Count;
        for (int i = 0; i < count; ++i)
        {
            var prefab = Instantiate(_minionPrefab, _minionParentZone, true);
            Vector2 pos = coords[i];
            int nb = dataNb[i];

            prefab.GetComponent<Minion>().ValueInit(_minionsData[nb]);
            prefab.transform.localPosition = pos;
        }
    }
}
