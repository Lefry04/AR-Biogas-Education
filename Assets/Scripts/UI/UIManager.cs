using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public GameObject uiPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    [Header("Database")]
    public MarkerDatabase database;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        if (uiPanel != null)
            uiPanel.SetActive(false);
        else
            Debug.LogError("UIManager ERROR: uiPanel belum diassign!");
    }

    public void ShowInfo(string markerID)
    {
        if (database == null)
        {
            Debug.LogError("UIManager ERROR: MarkerDatabase belum diassign!");
            return;
        }

        MarkerData data = database.GetData(markerID);

        if (data == null)
        {
            Debug.LogWarning("UIManager: Tidak ada data untuk marker " + markerID);
            return;
        }

        // Update UI
        titleText.text = data.title;
        descriptionText.text = data.description;

        uiPanel.SetActive(true);
        Debug.Log("UIManager: Menampilkan UI untuk marker " + markerID);
    }

    public void HideInfo()
    {
        if (uiPanel != null) 
            uiPanel.SetActive(false);
    }
}
