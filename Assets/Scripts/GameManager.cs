using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int levelOneHS;
    public int levelTwoHS;
    public int levelThreeHS;
    public int buffetHS;

    public bool unlockLevelTwo;
    public bool unlockLevelThree;
    public bool unlockBuffet;

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

    
    void Update()
    {
        
    }
}
