using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject aboutUsPanel;

    // Buka Main Menu, tutup About Us
    public void OpenMainMenu()
    {
        mainMenuPanel.SetActive(true);
        aboutUsPanel.SetActive(false);
    }

    // Buka About Us, tutup Main Menu
    public void OpenAboutUs()
    {
        mainMenuPanel.SetActive(false);
        aboutUsPanel.SetActive(true);
    }

    // Menutup kedua UI (opsional)
    public void CloseAll()
    {
        mainMenuPanel.SetActive(false);
        aboutUsPanel.SetActive(false);
    }
}
