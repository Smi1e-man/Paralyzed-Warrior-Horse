using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    //private values
    private MinionsData _data;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private IEnumerator BoostBalance()
    {
        while(true)
        {
            yield return new WaitForSeconds(_data.DeltaBoostTime);
            GameManager._Gm.BalancePlus(_data.BoostBalance);
            //animation number;
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
