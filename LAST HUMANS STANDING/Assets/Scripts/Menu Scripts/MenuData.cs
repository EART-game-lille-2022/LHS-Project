using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "new Lvl Data", menuName = "ScriptableObjects/LvlData", order = 1)]
public class MenuData : ScriptableObject
{
    public string lvl;
    public bool finished;
    public bool unlocked;
}
