using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySFX(AudioClip clipToPlay)
    {
        audioSource.PlayOneShot(clipToPlay);
    }
}
