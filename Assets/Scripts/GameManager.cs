using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //assume everything is zero-indexed, i.e. level 2 is found in [1]
    [SerializeField] public List<Level> levelList;

    [HideInInspector] public bool DebugMode = false;

    public int[] sushiEatenCounter = new int[4];

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

    void Update() {
        if(Input.GetKeyDown(KeyCode.D)){
            DebugMode = !DebugMode;
            MenuManager menu = FindObjectOfType<MenuManager>();
            if(menu){
                menu.UpdateLevel();
            }
        }

    }

    //Scene names: "Level 1", "Level 2", ..., "Buffet Mode"
    public void LoadLevel(string name)
    {
        AudioManager.instance.PlayMusic(name);
        SceneManager.LoadScene(name);
    }

}

[System.Serializable]
public class Level {
    [HideInInspector] public int highScore;
    public int minScore;
    public string spawnString;

    public int maxScore(){
        int max = 0;
        foreach(char c in spawnString){
            int sushiIndex = c - '0';
            if(sushiIndex >= 0 && sushiIndex < 4){
                max += Constants.sushiPoints[sushiIndex];
            }
        }
        return max;
    }
}