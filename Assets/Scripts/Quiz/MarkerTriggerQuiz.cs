using UnityEngine;
using Vuforia;

public class MarkerTriggerQuiz : MonoBehaviour
{
    public string answerID; // "A", "B", "C", "D"

    ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged += OnMarkerChanged;
    }

    void OnMarkerChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            QuizManager.Instance.ReceiveMarkerAnswer(answerID);
        }
    }
}
