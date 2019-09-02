using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    //private visual values
    [SerializeField] private float _timeRotate;
    [SerializeField] private float _angleRotate;
    [SerializeField] private TextBoostSpawnerData _spawnerTextData;
    [SerializeField] private TextBoostSpawner _spawnerText;

    //private values
    private Vector3 _toRotate;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _toRotate = new Vector3(0f, 0f, _angleRotate);
        _spawnerText.InitValue(_spawnerTextData);
    }

    private void OnMouseDown()
    {
        //current modifier
        float currenMod = ModifierManager._Modif.CurrentModifier;
        GameManager._Gm.BalanceBananas += currenMod;
        transform.DORotate(_toRotate, _timeRotate, RotateMode.WorldAxisAdd);
        //animation text
        _spawnerText.AddText(currenMod, transform.position);
    }
}
