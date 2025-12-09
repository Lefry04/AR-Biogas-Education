using UnityEngine;
using Vuforia;

public class MarkerInfo : MonoBehaviour
{
    public string title;
    [TextArea] public string description;
    public Sprite infoImage;

    public GameObject uiPanel;
    public UnityEngine.UI.Text titleText;
    public UnityEngine.UI.Text descriptionText;
    public UnityEngine.UI.Image imageDisplay;

    ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        observer.OnTargetStatusChanged += OnTargetStatusChanged;
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        bool visible =
            status.Status == Status.TRACKED ||
            status.Status == Status.EXTENDED_TRACKED ||
            status.Status == Status.LIMITED;

        if (visible)
            ShowUI();
        else
            HideUI();
    }

    void ShowUI()
    {
        uiPanel.SetActive(true);
        titleText.text = title;
        descriptionText.text = description;

        if (infoImage != null)
            imageDisplay.sprite = infoImage;
    }

    void HideUI()
    {
        uiPanel.SetActive(false);
    }
}
