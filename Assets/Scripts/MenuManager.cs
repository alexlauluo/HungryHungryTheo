using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject LevelCanvas;
    public GameObject CreditsCanvas;

    public void EnableCredits()
    {
        DisableAll();
        Debug.Log("AAAAAAAAAAAA");
        CreditsCanvas.SetActive(true);
    }
    public void EnableLevel()
    {
        DisableAll();
        Debug.Log("AAAAAAAAAAAA");
        LevelCanvas.SetActive(true);
    }

    public void EnableStart()
    {
        DisableAll();

        StartCanvas.SetActive(true);
    }

    private void DisableAll()
    {
        StartCanvas.SetActive(false);
        LevelCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
    }

}
