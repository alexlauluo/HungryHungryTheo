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

    public void PlayStory(){
        GameManager.instance.LoadLevel("Story");
    }

    public void PlayLevel(string name){
        GameManager.instance.LoadLevel(name);
    }

    private void DisableAll()
    {
        StartCanvas.SetActive(false);
        LevelCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
    }

    public void PlaySound(string name){
        AudioManager.instance.Play(name);
    }

    public void UpdateLevel()
    {

        bool buffet = true;
        

        for (int i=0; i<gm.levelList.Count; i++)
        {
            Level level = gm.levelList[i];
            print(level.maxScore());

            int stars = 0;

            if(level.highScore > level.minScore){
                float percent = (level.highScore - level.minScore) / (level.maxScore() - level.minScore);
                if(percent < .5){
                    stars = 1;
                }
                else if(percent < .99){
                    stars = 2;
                }
                else{
                    stars = 3;
                }
            }

            if(stars == 0) buffet = false;

            Transform levelGroup = LevelButtons.transform.GetChild(i);

            for(int j = 0; j < stars; j++){
                levelGroup.GetChild(j + 1).GetComponent<Image>().sprite = earnedStar;
            }

        }

        if(buffet || gm.DebugMode){
            LevelButtons.transform.GetChild(gm.levelList.Count).gameObject.SetActive(true); // Buffet Mode button
        }

        if(gm.DebugMode){
            LevelButtons.transform.GetChild(gm.levelList.Count + 1).gameObject.SetActive(true); // Debug Mode button

        }
    }
}
