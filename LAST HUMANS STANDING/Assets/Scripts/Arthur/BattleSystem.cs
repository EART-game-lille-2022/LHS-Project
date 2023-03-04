using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENNEMYTURN,}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;
}
