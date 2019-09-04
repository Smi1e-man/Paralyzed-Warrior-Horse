using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleLoader : MonoBehaviour
{
    //private visual values
    [SerializeField] private string _bundleUrl;
    [SerializeField] private int _version;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private MinionsData _minionOne;
    [SerializeField] private MinionsData _minionTwo;
    [SerializeField] private MinionsData _minionGold;

    public string BundleUrl { get => _bundleUrl; set => _bundleUrl = value; }
    public int Version { get => _version; set => _version = value; }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        StartCoroutine(LoadBundle());
    }

    private IEnumerator LoadBundle()
    {
        //when added Bundle URL -> dell unity_android
#if UNITY_EDITOR || UNITY_ANDROID
        _player.sprite = Resources.Load<Sprite>("Sprites/Horse");
        _minionOne.MainSprite = Resources.Load<Sprite>("Sprites/Pinguin");
        _minionTwo.MainSprite = Resources.Load<Sprite>("Sprites/Pinguin2");
        _minionGold.MainSprite = Resources.Load<Sprite>("Sprites/GoldPinguin");
        yield break;
#else
        while (!Caching.ready)
            yield return null;

        var download = WWW.LoadFromCacheOrDownload(_bundleUrl, _version);
        yield return download;

        if (!string.IsNullOrEmpty(download.error))
        {
            Debug.Log(download.error);
            yield break;
        }
        var _assetBundle = download.assetBundle;

        //Player
        var spritePlayer = _assetBundle.LoadAsset("Horse.png", typeof(Sprite));
        yield return spritePlayer;
        _player.sprite = spritePlayer as Sprite;

        //MinionOne
        var spriteMinionOne = _assetBundle.LoadAsset("Pinguin.png", typeof(Sprite));
        yield return spriteMinionOne;
        _minionOne.MainSprite = spriteMinionOne as Sprite;

        //MinionTwo
        var spriteMinionTwo = _assetBundle.LoadAsset("Pinguin2.png", typeof(Sprite));
        yield return spriteMinionTwo;
        _minionTwo.MainSprite = spriteMinionTwo as Sprite;

        //MinionGold
        var spriteMinionGold = _assetBundle.LoadAsset("GoldPinguin.png", typeof(Sprite));
        yield return spriteMinionGold;
        _minionGold.MainSprite = spriteMinionGold as Sprite;
#endif
    }
}
