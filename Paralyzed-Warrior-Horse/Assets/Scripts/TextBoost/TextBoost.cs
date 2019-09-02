using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextBoost : MonoBehaviour
{
	//private values
	private TextBoostData _data;
    private TextMeshProUGUI _textObj;

    /// <summary>
    /// Public Methods.
    /// </summary>
	public void InitValue(TextBoostData data, float textBoost, Vector2 pos)
	{
		_data = data;
        _textObj = GetComponent<TextMeshProUGUI>();
        MotionText(textBoost);
        ReturnTextBoost(pos);
	}

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void MotionText(float textBoost)
    {
        if (_data)
        {
            _textObj.text = "+" + textBoost.ToString("F0");
            transform.DOLocalMoveY(transform.localPosition.y + _data.EndMove, _data.TimeMove);
            _textObj.DOFade(_data.EndFade, _data.TimeFade);
        }
    }

    private void ReturnTextBoost(Vector2 pos)
    {
        if (_data)
        {
            _textObj.alpha = _data.StartFade;
			transform.position = pos;
		}
    }
}
