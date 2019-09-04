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

    //public values
    public static ModifierManager _Modif;

    public float PriceModifier { get => _priceModifier; set => _priceModifier = value; }
    public float CurrentModifier { get => _currentModifier; set => _currentModifier = value; }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (_Modif == null)
            _Modif = this;
        _deltaClickBoost = Resources.Load<ModifierSettings>("Settings/ModifierSettings").DeltaClickBoost;
        _deltaClickPrice = Resources.Load<ModifierSettings>("Settings/ModifierSettings").DeltaClickPrice;
    }

    private void ChangeText()
    {
        _textPriceModifier.text = "Price\n" + _priceModifier.ToString("F0");
        _textCurrentModifier.text = "Current\n+" + _currentModifier.ToString("F0");
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void InitValue(float price, float current)
    {
        PriceModifier = price;
        CurrentModifier = current;
        _boostModifier = _currentModifier * _deltaClickBoost;

        ChangeText();
    }
    public void ClickOnButtonBoost()
    {
        float balance = GameManager._Gm.BalanceBananas;
        if (balance >= _priceModifier)
        {
            GameManager._Gm.BalanceBananas -= _priceModifier;
            _currentModifier = _boostModifier;
            _boostModifier *= _deltaClickBoost;
            _priceModifier *= _deltaClickPrice;

            ChangeText();
        }
    }
}
