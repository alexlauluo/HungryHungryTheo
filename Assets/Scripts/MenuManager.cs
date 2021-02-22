using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject LevelCanvas;
    public GameObject CreditsCanvas;

    public GameObject LevelButtons;
    private GameManager gm;

    public Sprite earnedStar;

    private void Awake()
    {
        gm = GameManager.instance;
        UpdateLevel();
    }

    public void EnableCredits()
    {
        DisableAll();
        CreditsCanvas.SetActive(true);
    }
    public void EnableLevel()
    {
        DisableAll();
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

    private void UpdateLevel()
    {
        for (int i=0; i<gm.lvlMax.Length; i++)
        {
            float prop = (float)gm.lvlHS[i] / gm.lvlMax[i];
            if (prop >= gm.StarPercent[2])
            {
                gm.lvlStar[i] = 3;
            } else if (prop >= gm.StarPercent[1])
            {
                gm.lvlStar[i] = 2;
            } else if (prop >= gm.StarPercent[0])
            {
                gm.lvlStar[i] = 1;
            } else
            {
                gm.lvlStar[i] = 0;
            }
        }
        for (int i = 0; i<gm.lvlMax.Length; i++)
        {
            Image[] stars = LevelButtons.transform.GetChild(i).GetComponentsInChildren<Image>();
            for (int j=1; j<=gm.lvlStar[i]; j++)
            {
                stars[j].sprite = earnedStar;
            }
        }
    }
}
