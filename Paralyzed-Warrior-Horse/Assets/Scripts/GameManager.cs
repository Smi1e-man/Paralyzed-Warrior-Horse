using System;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    //private values
    private float _balanceBananas;
    private float _currentModifier;

    //public values
    public static GameManager _Gm;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (_Gm == null)
            _Gm = this;
        DOTween.Init();
    }

    private void Start()
    {
        _currentModifier = 10;
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ClickOn() => BalancePlus(_currentModifier);

    public void ClickBuyModifier(float newCurrentModifier)
    {
        _currentModifier = newCurrentModifier;
    }

    public void BalanceMinus(float minus)
    {
        _balanceBananas -= minus;
    }

    public void BalancePlus(float plus)
    {
        _balanceBananas += plus;
    }

    public float GetBalance()
    {
        return (_balanceBananas);
    }

    public void AddMinionPos(int count, Vector2 minionCoord)
    {
        var listTypeMinion = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").MinionCurrentPos;
        listTypeMinion.Add(minionCoord);
    }
}
