using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //assume everything is zero-indexed, i.e. level 2 is found in [1]

    //highscores for each lvl
    public int[] lvlHS;

    //earned stars for each lvl
    public int[] lvlStar;

    //max score possible per lvl, change later to not be hardcoded
    public int[] lvlMax;

    //percents required to fullfill star
    public float[] StarPercent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
