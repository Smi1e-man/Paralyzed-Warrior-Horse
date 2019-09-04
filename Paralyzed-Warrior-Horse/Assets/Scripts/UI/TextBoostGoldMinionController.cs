using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class TextBoostGoldMinionController : MonoBehaviour
{
    //private visual
    [SerializeField] private float _timeFadeDown;
    [SerializeField] private float _timeFadeUp;

    //private values
    private TextMeshProUGUI _boost;

    // Start is called before the first frame update
    void Start()
    {
        _boost = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_boost.alpha > 0.99)
            _boost.DOFade(0, _timeFadeDown);
        else if (_boost.alpha < 0.01)
            _boost.DOFade(1, _timeFadeUp);
    }
}
