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

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        _minionPrice = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").MinionPrice;
        _minionNb = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").MinionNb;
        _deltaMinionBoost = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").DeltaMinionBoost;
        _deltaMinionPrice = Resources.Load<BuyMinionSettings>("Settings/BuyMinionSettings").DeltaMinionPrice;

        ChangeText();
    }

    private void ChangeText()
    {
        _textPrice.text = "Price\n" + _minionPrice.ToString("F0");
        _textNow.text = "NB Current\n" + _minionNb.ToString("F0");
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ClickOnButtonBuyMinion()
    {
        if (GameManager._Gm.GetBalance() >= _minionPrice)
        {
            //Add minion from Pool on minion zone
            AddMinion(_minionNb);
            GameManager._Gm.BalanceMinus(_minionPrice);

            _minionNb += _deltaMinionBoost;

            _minionPrice *= _deltaMinionPrice;

            ChangeText();
        }
    }
}
