using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class HorseController : MonoBehaviour
{
    //private visual values
    [SerializeField] private float _timeRotate;

    //private values
    private Vector3 _toRotate;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Awake()
    {
        _toRotate = new Vector3(0f, 0f, -90f);
    }

    private void OnMouseDown()
    {
        GameManager._Gm.ClickOn();
        transform.DORotate( _toRotate, _timeRotate, RotateMode.WorldAxisAdd);
        //animation text
    }
}
