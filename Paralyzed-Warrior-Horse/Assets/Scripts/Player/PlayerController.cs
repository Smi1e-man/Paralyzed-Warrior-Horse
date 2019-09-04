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
    private float _oldcurrenMod;
    private int _goldMinionBoost;

    public int GoldMinionBoost { get => _goldMinionBoost; set => _goldMinionBoost = value; }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _goldMinionBoost = 1;
        _toRotate = new Vector3(0f, 0f, _angleRotate);
        _spawnerText.InitValue(_spawnerTextData);
        _oldcurrenMod = ModifierManager._Modif.CurrentModifier;
    }

    private void OnMouseDown()
    {
        //current modifier
        float currenMod = ModifierManager._Modif.CurrentModifier;
        GameManager._Gm.BalanceBananas += currenMod * _goldMinionBoost;
        //check changes mod
        if (currenMod > _oldcurrenMod)
        {
            _oldcurrenMod = currenMod;
            ChangeDirMove();
        }
        //rotate
        transform.DORotate(_toRotate, _timeRotate, RotateMode.WorldAxisAdd);
        //animation text
        _spawnerText.AddText(currenMod * _goldMinionBoost, transform.position);
    }

    private void ChangeDirMove()
    {
        float xS = transform.localScale.x;
        float yS = transform.localScale.y;
        float zS = transform.localScale.z;

        xS *= -1;
        transform.localScale = new Vector3(xS, yS, zS);
        _toRotate *= -1;
    }
}
