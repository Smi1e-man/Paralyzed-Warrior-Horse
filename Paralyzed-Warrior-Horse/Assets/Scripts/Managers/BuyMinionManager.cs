using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyMinionManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private TextMeshProUGUI _textPrice;
    [SerializeField] private TextMeshProUGUI _textNow;

    //private values
    private float _minionPrice;
    private float _minionNb;
    private float _deltaMinionBoost;
    private float _deltaMinionPrice;

    //public values
    public static Action<float> AddMinion;
    public static BuyMinionManager _Mm;

    public float MinionPrice { get => _minionPrice; set => _minionPrice = value; }
    public float MinionNb { get => _minionNb; set => _minionNb = value; }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (_Mm == null)
            _Mm = this;
        _deltaMinionBoost = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").DeltaMinionBoost;
        _deltaMinionPrice = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").DeltaMinionPrice;
    }

    private void ChangeText()
    {
        _textPrice.text = "Price\n" + _minionPrice.ToString("F0");
        _textNow.text = "Current\n" + _minionNb.ToString("F0");
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void InitValue(float price, float nb)
    {
        MinionPrice = price;
        MinionNb = nb;

        ChangeText();
    }

    public void ClickOnButtonBuyMinion()
    {
        float balance = GameManager._Gm.BalanceBananas;
        if (balance >= _minionPrice)
        {
            //Add minion from Pool on minion zone
            AddMinion(_minionNb);

            GameManager._Gm.BalanceBananas -= _minionPrice;
            _minionNb += _deltaMinionBoost;
            _minionPrice *= _deltaMinionPrice;

            ChangeText();
        }
    }
}
