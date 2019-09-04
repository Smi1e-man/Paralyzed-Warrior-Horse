using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Advertisements;

public class ScoreManager : MonoBehaviour
{
    //private visual values
    [SerializeField] private TextMeshProUGUI _textBalanceBananas;
    [SerializeField] private TextMeshProUGUI _textClickPerSec;
    [SerializeField] private TextMeshProUGUI _textGoldMinionBoost;
    [SerializeField] private PlayerController _player;

    //private values
    private int _clicks;
    private float _timer;
    //unityAds
    private float _balanceAdsView;
    private float _deltaAdsView;
    //GoldMinion
    private bool _activeGoldMinionBoost;
    private float _timerBoost;
    private float _timeBoostGoldMinion;

    //public values
    public static ScoreManager _Sm;

    public float BalanceAdsView { get => _balanceAdsView; set => _balanceAdsView = value; }
    public float DeltaAdsView { get => _deltaAdsView; set => _deltaAdsView = value; }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        if (_Sm == null)
            _Sm = this;
    }
    private void Start()
    {
        StartCoroutine(printBalance());
    }

    private void Update()
    {
        //Click Per Sec
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            _textClickPerSec.text = _clicks.ToString();
            _timer = 0;
            _clicks = 0;
        }
        //Boost Gold Minion
        if (_activeGoldMinionBoost)
        {
            _timerBoost += Time.deltaTime;
            if (_timerBoost >= _timeBoostGoldMinion)
            {
                _activeGoldMinionBoost = false;
                _timerBoost = 0;

                _player.GoldMinionBoost = 1;
                _textGoldMinionBoost.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator printBalance()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float balance = GameManager._Gm.BalanceBananas;
            _textBalanceBananas.text = balance.ToString("F0");

            //UnityAds
            if (balance >= _balanceAdsView)
            {
                _balanceAdsView *= _deltaAdsView;

                Advertisement.Show();
            }
        }
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void ClickCount() => ++_clicks;

    public void GoldMinionBoost(int boost, float timeBoost)
    {
        _textGoldMinionBoost.text = "X" + boost.ToString();
        _textGoldMinionBoost.gameObject.SetActive(true);

        _player.GoldMinionBoost = boost;
        _timeBoostGoldMinion = timeBoost;

        _activeGoldMinionBoost = true;
    }

    public void InitValue(float balanceAds, float deltaAds)
    {
        _balanceAdsView = balanceAds;
        _deltaAdsView = deltaAds;
    }
}
