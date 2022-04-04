using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text targetsLeftText;
    public TMP_Text difficultyText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateTimer(float _timer)
    {
        // gives the timer text value on the screen.
        // ToString gives the string representation of the given object.
        // ToString("0") stops giving the decimal values in the screen.
        timerText.text = "Time Remaining:" + _timer.ToString("0");
        // changes timer text color from initially yello to red when the time left is less than 10 secs. 
        timerText.color = _timer < 10f ? Color.red : Color.yellow;
    }
    public void UpdateScore(float _score)
    {
        // gives the score text value on the screen.
        scoreText.text = "Score:" + _score.ToString();
    }

    public void UpdateTargets()
    {
        // gives the targets left value in text on the screen.
        targetsLeftText.text = "Targets left:" + _TM.targets.Count.ToString();
    }
    public void UpdateDifficulty()
    {
        // gives the difficulty text for the mode on the screen.
        difficultyText.text = "Difficulty:" + _GM.difficulty.ToString();
    }
}
