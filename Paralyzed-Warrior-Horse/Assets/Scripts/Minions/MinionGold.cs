using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MinionGold : MonoBehaviour
{
    //private visual
    [SerializeField] private MinionsData _data;
    [SerializeField] private float _minTimeWait;
    [SerializeField] private float _maxTimeWait;
    [SerializeField] private float _limitY;
    [SerializeField] private float _limitX;
    [SerializeField] private Vector3 _endRotate;
    [SerializeField] private float _timeRotate;
    [SerializeField] private float _endMove;
    [SerializeField] private float _timeMove;

    //private
    private bool _border;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _data.MainSprite;
        RandPos();
        StartCoroutine(SpawnMove());
    }

    private IEnumerator SpawnMove()
    {
        float randTime = Random.Range(_minTimeWait, _maxTimeWait);
        yield return new WaitForSeconds(randTime);
        if (_border)
        {
            transform.DOLocalRotate(-_endRotate, _timeRotate);
            transform.DOLocalMoveX(-_endMove, _timeMove);
        }
        else
        {
            transform.DOLocalRotate(_endRotate, _timeRotate);
            transform.DOLocalMoveX(_endMove, _timeMove);
        }
    }

    private void RandPos()
    {
        float posY = Random.Range(-_limitY, _limitY);
        float posX = _limitX;
        int scaleX = 1;
        if (Random.Range(0f, 2f) < 1)
        {
            posX = -_limitX;
            scaleX = -1;
            _border = true;
        }
        else
            _border = false;
        Vector2 nPos = new Vector2(posX, posY);
        Vector3 nScale = new Vector3(scaleX, 1, 1);

        transform.localPosition = nPos;
        transform.localScale = nScale;
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void MinionClick()
    {
		//stop animation
		DOTween.KillAll(true);
        //move to new pos
        transform.DOLocalRotate(Vector3.zero, 0);
        RandPos();
        StartCoroutine(SpawnMove());
        //start GoldMinionBoost
        ScoreManager._Sm.GoldMinionBoost(_data.BoostBalance, _data.DeltaBoostTime);
    }
}
