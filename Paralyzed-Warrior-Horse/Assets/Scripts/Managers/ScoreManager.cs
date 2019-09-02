using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private TextMeshProUGUI _textBalanceBananas;
    [SerializeField] private TextMeshProUGUI _textClickPerSec;

    //private values
    private int _clicks;
    private float _timer;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        StartCoroutine(printBalance());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            _textClickPerSec.text = _clicks.ToString();
            _timer = 0;
            _clicks = 0;
        }
    }

    private IEnumerator printBalance()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            float balance = GameManager._Gm.BalanceBananas;
            _textBalanceBananas.text = balance.ToString("F0");
        }
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ClickCount() => ++_clicks;
}
