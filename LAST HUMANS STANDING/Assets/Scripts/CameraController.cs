using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform camTarget;
    public float delayed;
    public Vector3 PositionOffSet;
    public void UpdateCam(TurnBasedBehaviour targeted )
    {
        camTarget.position = new Vector3(targeted.transform.position.x,targeted.transform.position.y,camTarget.position.z);
        transform.DOMove(camTarget.position, 0.5f);
    }
}
