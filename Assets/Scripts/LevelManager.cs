using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // Serialized Fields
    [SerializeField] private int levelIndex; 
    [Header("UI")]
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text minScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private TextMeshProUGUI sushiCounterText;

    public Canvas UICanvas;

    [HideInInspector] public Level level;

    private int counter;
    private int Score;

    private void Awake()
    {
        if(levelIndex >= 0){
            level = GameManager.instance.levelList[levelIndex];
        }
        else{
            level = null; // Buffet Mode
        }  

        if(level == null){
            highScoreText.text = "";
            minScoreText.text = "";
            scoreText.text = "Score: 0";
        }
        else{
            highScoreText.text = "High Score: " + level.highScore;
            minScoreText.text = "Required Score: " + level.minScore;
            scoreText.text = "Score: 0";
        }

        //setup sushicounter
        if(level != null) counter = level.spawnString.Length;
        sushiCounterText.text = counter.ToString();

    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            GameManager.instance.LoadLevel("Menu");
        }
    }

    public void UpdateScore(int points)
    {
        Score += points;
        scoreText.text = "Score: " + Score.ToString();
    }

    public void DecrementCounter()
    {
        counter--;
        sushiCounterText.text = counter.ToString();
        if (counter == 0) //level ends
        {
            UpdateHS();
            GameManager.instance.LoadLevel("Menu");
        }
    }


    private void UpdateHS()
    {
        if (level != null && Score > level.highScore)
        {
            level.highScore = Score;
        }
    }
}
