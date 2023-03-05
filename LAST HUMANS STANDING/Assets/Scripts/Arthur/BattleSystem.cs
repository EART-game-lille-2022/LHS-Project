using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { NOFIGHT,STARTFIGHT, PLAYERTURN, ENNEMYTURN, NEWENNEMI, WIN, LOOSE}
public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    private void Start()
    {
        state = BattleState.NOFIGHT;

    }
}
