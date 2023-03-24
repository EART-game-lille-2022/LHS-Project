using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableBehaviour : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent<OnDisableBehaviour> onDisable;
    void OnDisable()
    {
        onDisable.Invoke(this);
    }
}
