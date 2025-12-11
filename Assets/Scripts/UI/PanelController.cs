using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject openingPanel;
    public GameObject deskripsiPanel;

    public void ClosePanel()
    {
        openingPanel.SetActive(false);
        deskripsiPanel.SetActive(true);
    }
}
