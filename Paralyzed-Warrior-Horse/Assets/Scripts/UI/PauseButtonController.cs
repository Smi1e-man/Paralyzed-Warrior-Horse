using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseButtonController : MonoBehaviour
{
    //visual private values
    [SerializeField] TextMeshProUGUI _textButtonPause;

    public void PauseGame()
    {
        if (Time.timeScale > 0.9)
        {
            Time.timeScale = 0;
            _textButtonPause.text = "Play";
            GameManager._Gm.SaveValues();
        }
        else
        {
            Time.timeScale = 1;
            _textButtonPause.text = "Pause";
        }
    }
}
