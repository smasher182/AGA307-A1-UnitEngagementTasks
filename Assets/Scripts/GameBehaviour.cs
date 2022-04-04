using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    // singleton class references shortened for ease of use.
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static TargetManager _TM { get { return TargetManager.instance; } }
    
}
