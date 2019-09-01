using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifierManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private TextMeshProUGUI _textBoostModifier;
    [SerializeField] private TextMeshProUGUI _textPriceModifier;
    [SerializeField] private TextMeshProUGUI _textCurrentModifier;

    //private values
    private float _boostModifier;
    private float _priceModifier;
    private float _currentModifier;
    private float _deltaClickBoost;
    private float _deltaClickPrice;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        _priceModifier = Resources.Load<ModifierSettings>("Settings/ModifierSettings").PriceModifier;
        _currentModifier = Resources.Load<ModifierSettings>("Settings/ModifierSettings").CurrentModifier;
        _deltaClickBoost = Resources.Load<ModifierSettings>("Settings/ModifierSettings").DeltaClickBoost;
        _deltaClickPrice = Resources.Load<ModifierSettings>("Settings/ModifierSettings").DeltaClickPrice;
        _boostModifier = _currentModifier * _deltaClickBoost;

        ChangeText();
    }

    private void ChangeText()
    {
        _textBoostModifier.text = "Click\nModifier\n+" + _boostModifier.ToString("F0");
        _textPriceModifier.text = "Price\n" + _priceModifier.ToString("F0");
        _textCurrentModifier.text = "Current\n+" + _currentModifier.ToString("F0");
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ClickOnButtonBoost()
    {
        if (GameManager._Gm.GetBalance() >= _priceModifier)
        {
            GameManager._Gm.BalanceMinus(_priceModifier);
			GameManager._Gm.ClickBuyModifier(_boostModifier);
            _currentModifier = _boostModifier;
            _boostModifier *= _deltaClickBoost;
            _priceModifier *= _deltaClickPrice;

            ChangeText();
        }
    }
}
