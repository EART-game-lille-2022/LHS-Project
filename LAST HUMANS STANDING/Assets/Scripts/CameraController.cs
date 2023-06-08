using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camTarget;
    public float delayed;
    public Vector3 PositionOffSet;
    public Ease ease = Ease.InOutBounce;
    public float time;
    public void UpdateCam(TurnBasedBehaviour targeted)
    {
        camTarget.position = new Vector3(targeted.transform.position.x, targeted.transform.position.y, camTarget.position.z);
        // transform.DOMove(camTarget.position, time).SetEase(ease);
        transform.DOMoveX(camTarget.position.x, time).SetEase(Ease.Linear);
        transform.DOMoveY(camTarget.position.y, time).SetEase(ease);
    }
}
