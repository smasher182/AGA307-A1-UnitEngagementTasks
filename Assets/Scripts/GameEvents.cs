using System;
using UnityEngine;



public static class GameEvents
{
    // declares the event actions to be invoked.
    public static event Action<GameObject> OnTargetHit = null;
    public static event Action<GameObject> OnTargetDestroyed = null;
    public static event Action<Difficulty> OnDifficultyChanged = null;


    // function to be reported to by a script when a target is hit.
    public static void ReportTargetHit(GameObject _target)
    {
        Debug.Log("Target" + _target.name + "was hit");
        // invokes the event action that gets listened to after the target hit report is made.
        OnTargetHit?.Invoke(_target);
    }

    // function to be reported to by a script when a target is destroyed.
    public static void ReportTargetDestroyed(GameObject _target)
    {
        Debug.Log("Target" + _target.name + "was destroyed");
        // invokes the event action that gets listened to after the target destroyed report is made.
        OnTargetDestroyed?.Invoke(_target);
    }

    // // function to be reported to by a script when difficulty is changed.
    public static void ReportDifficultyChanged(Difficulty _difficulty)
    {
        // invokes the event action that gets listened to after the difficulty changed report is made.
        OnDifficultyChanged?.Invoke(_difficulty);
    }
}
