using UnityEngine;
using Vuforia;

public class MarkerTrigger : MonoBehaviour
{
    private ObserverBehaviour observer;

    private void Awake()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer == null)
        {
            Debug.LogError("MarkerTrigger ERROR: ObserverBehaviour tidak ditemukan!");
            return;
        }

        // Daftar event status
        observer.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnDestroy()
    {
        if (observer != null)
            observer.OnTargetStatusChanged -= OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool isTracked =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED ||
            status.Status == Status.LIMITED;

        if (isTracked)
        {
            Debug.Log("Marker ditemukan: " + behaviour.TargetName);
            UIManager.Instance.ShowInfo(behaviour.TargetName);
        }
        else
        {
            Debug.Log("Marker hilang: " + behaviour.TargetName);
            UIManager.Instance.HideInfo();
        }
    }
}
