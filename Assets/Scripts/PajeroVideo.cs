using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class PajeroVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        videoPlayer.Stop();

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.mute = true;
        }
    }

    private void OnTargetStatusChanged(
        ObserverBehaviour behaviour,
        TargetStatus status)
    {
        // ONLY TRACKED = target is actually detected
        if (status.Status == Status.TRACKED)
        {
            if (audioSource != null)
            {
                audioSource.mute = false;
                audioSource.Play();
            }

            videoPlayer.Play();
        }
        else
        {
            videoPlayer.Stop();

            if (audioSource != null)
            {
                audioSource.Stop();
                audioSource.mute = true;
            }
        }
    }

    void OnDestroy()
    {
        if (observer != null)
        {
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}