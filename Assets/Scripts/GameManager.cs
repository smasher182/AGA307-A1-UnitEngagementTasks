using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty { EASY, MEDIUM, HARD }
public enum GameState { TITLE, INGAME, GAMEOVER }
public class GameManager : Singleton<GameManager>

{
    // reference to difficulty.
    public Difficulty difficulty;
    // reference to game state.
    public GameState gameState;
    // reference to score.
    public int score;
    // reference to value by which score is multiplied.
    int scoreMultiplier = 1;
    // reference to max time remaining.
    public float timeRemaining = 30;

    private void Start()
    {
        ChangeDifficulty();
    }
    private void Update()
    {
        // checks if the gameState is INGAME.
        if (gameState == GameState.INGAME)
        {
            if (timeRemaining > 0)
            {
                // continuously reduces timeRemaining by the time it took since the last frame.
                timeRemaining -= Time.deltaTime;
            }
            // stops the value from going below zero.
            else timeRemaining = 0;
            // gets the timer update function from UIManager script.
            _UI.UpdateTimer(timeRemaining);
            // gets the score update function from UIManager script.
            _UI.UpdateScore(score);
            // gets the targets update function from UIManager script.
            _UI.UpdateTargets();
            // gets the difficulty update function from UIManager script.
            _UI.UpdateDifficulty();

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
    void AddTime()
    {
        // adds 5 seconds to the remaining time.
        timeRemaining += 5f;
    }

    public void AddScore(int _points)
    {
        {
            // updates the main score with every score change.
            score += _points * scoreMultiplier;
        }
    }
    private void OnEnable()
    {
        // subscribes to the event call.
        //calls OnTargetHit function after the GameEvents has happened.
        //calls OnTargetDestroyed function after the GameEvents has happened.
        GameEvents.OnTargetHit += OnTargetHit;
        GameEvents.OnTargetDestroyed += OnTargetDestroyed;
    }
    private void OnDisable()
    {
        // unsubscribes to the event call.
        //calls OnTargetHit function after the GameEvents has happened.
        //calls OnTargetDestroyed function after the GameEvents has happened.
        GameEvents.OnTargetHit -= OnTargetHit;
        GameEvents.OnTargetDestroyed -= OnTargetDestroyed;
    }
    void OnTargetHit(GameObject _target)
    {
        // adds score of 10 after each target hit.
        AddScore(10);
        // adds extra time to the timeRemaining with every target hit. 
        AddTime();
        //Debug.Log("Time Remaining:" + timeRemaining + 5f);
    }
    void OnTargetDestroyed(GameObject _target)
    {
        // adds score of 100 after each target is destroyed.
        AddScore(100);
    }
}
