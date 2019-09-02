using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    //visual private
    [SerializeField] private TextBoostSpawnerData _spawnerTextData;
    [SerializeField] private TextBoostSpawner _spawnerText;
    //private values
    private MinionsData _data;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _spawnerText.InitValue(_spawnerTextData);
    }
    private IEnumerator BoostBalance()
    {
        while(true)
        {
            yield return new WaitForSeconds(_data.DeltaBoostTime);
            GameManager._Gm.BalancePlus(_data.BoostBalance);
            //animation number;
            _spawnerText.AddText(_data.BoostBalance, transform.position);
        }
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ValueInit(MinionsData data)
    {
        _data = data;

        GetComponent<SpriteRenderer>().sprite = _data.MainSprite;
        StartCoroutine(BoostBalance());
    }
}
