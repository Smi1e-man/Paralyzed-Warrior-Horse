using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    //visual private value
    [SerializeField] private GameSettings _gameSet;
    [SerializeField] private float _deltaTimeSave;

    [SerializeField] private MinionSpawnerOld _spawnerOldMinions;

    //private values
    private float _balanceBananas;
    private string _path;

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
        //load game settings
        LoadValues();
        SpawnOldMinions();
        StartCoroutine(Saver());
        Advertisement.Initialize("1234567", true);
    }

    private void LoadValues()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        _path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (File.Exists(_path))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(_path), _gameSet);
        }
        //init values
        _balanceBananas = _gameSet.Balance;
        BuyMinionManager._Mm.InitValue(_gameSet.PriceMinion, _gameSet.MinionNb);
        ModifierManager._Modif.InitValue(_gameSet.PriceModif, _gameSet.CurrentMod);
        ScoreManager._Sm.InitValue(_gameSet.BalanceAdsView, _gameSet.DeltaAdsView);
    }

    private void SpawnOldMinions()
    {
        List<Vector2> coords = _gameSet.MinionCoords;
        List<int> dataNb = _gameSet.MinionDateNb;

        if (coords != null && coords.Count > 0)
            _spawnerOldMinions.SpawnMinions(coords, dataNb);
    }

    private IEnumerator Saver()
    {
        while(true)
        {
            yield return new WaitForSeconds(_deltaTimeSave);
            SaveValues();
        }
    }
    /// <summary>
    /// Public Methods.
    /// </summary>
    public float BalanceBananas { get => _balanceBananas; set => _balanceBananas = value; }

    public void SaveValues()
    {
        _gameSet.Balance = _balanceBananas;
        _gameSet.CurrentMod = ModifierManager._Modif.CurrentModifier;
        _gameSet.PriceModif = ModifierManager._Modif.PriceModifier;
        _gameSet.MinionNb = BuyMinionManager._Mm.MinionNb;
        _gameSet.PriceMinion = BuyMinionManager._Mm.MinionPrice;
        _gameSet.BalanceAdsView = ScoreManager._Sm.BalanceAdsView;
        _gameSet.DeltaAdsView = ScoreManager._Sm.DeltaAdsView;

#if UNITY_ANDROID && !UNITY_EDITOR
        File.WriteAllText(_path, JsonUtility.ToJson(_gameSet));
#else
        File.WriteAllText(_path, JsonUtility.ToJson(_gameSet));
#endif
    }

    public void SetCoordsMinion(Vector2 pos)
    {
        _gameSet.MinionCoords.Add(pos);
    }
    public void SetDataNbMinions(int nb)
    {
        _gameSet.MinionDateNb.Add(nb);
    }
}
