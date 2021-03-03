using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI debugText;

    void Start(){
        AudioManager.instance.Stop();
        LoadDebug();
    }

    
    void LoadDebug(){
        string output = "";
        for(int i = 0; i < GameManager.instance.levelList.Count; i++){
            Level level = GameManager.instance.levelList[i];
            if(level.highScore == level.maxScore()){
                output += "Level " + (i+1) + " has been maxed out\n";
            }
            else{
                output += "Level " + (i+1) + " has NOT been maxed out\n";
            }
        }

        output += "\n";

        for(int i = 0; i < 4; i++){
            output += "Sushi " + (i+1) + " was eaten " + GameManager.instance.sushiEatenCounter[i] + " times.\n";
        }

        debugText.text = output;
    }

    public void GoBack(){
        GameManager.instance.LoadLevel("Story");
    }
}
