using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty { EASY, MEDIUM, HARD }
public class GameManager : Singleton<GameManager>

{
    // reference to difficulty.
    public Difficulty difficulty;
    // reference to score.
    public int score;
    // reference to value by which score is multiplied.
    int scoreMultiplier = 1;

    private void Start()
    {
        ChangeDifficulty();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            // sets the difficulty to easy with key (4) press.
            difficulty = Difficulty.EASY;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // sets the difficulty to easy with key (5) press.
            difficulty = Difficulty.MEDIUM;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // sets the difficulty to easy with key (6) press.
            difficulty = Difficulty.HARD;
        }
    }
    public void ChangeDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                
                break;
            case Difficulty.MEDIUM:
               

                break;
            case Difficulty.HARD:
               
                break;
            default:
                break;
        }
    }

}
