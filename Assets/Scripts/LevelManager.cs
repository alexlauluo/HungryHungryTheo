using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Canvas UICanvas;

    public int level; //still decrements, i.e. all levels in code and in hierarchy are always -1

    private Spawner spawner;
    private Text counterText;
    private int counter;

    private Text HSText;
    private Text ScoreText;
    private int Score;

    private void Awake()
    {
        instance = this;

        //setup scores
        HSText = UICanvas.transform.Find("High Score").GetComponent<Text>();
        ScoreText = UICanvas.transform.Find("Score").GetComponent<Text>();

        HSText.text = "High Score: " + GameManager.instance.lvlHS[level];
        ScoreText.text = "Score: 0";

        //setup sushicounter
        spawner = FindObjectOfType<Spawner>();
        counterText = UICanvas.transform.Find("Sushi Counter").GetComponentInChildren<Text>();
        counter = spawner.sushiList.Length;
        counterText.text = counter.ToString();
    }

    public void UpdateScore(int points)
    {
        Score += points;
        ScoreText.text = "Score: " + Score.ToString();
    }

    public void DecrementCounter()
    {
        counter--;
        counterText.text = counter.ToString();
        if (counter == 0) //level ends
        {
            UpdateHS();
            GameManager.instance.LoadLevel("Menu");
        }
    }

    private void UpdateHS()
    {
        if (Score > GameManager.instance.lvlHS[level])
        {
            GameManager.instance.lvlHS[level] = Score;
        }
    }
}
