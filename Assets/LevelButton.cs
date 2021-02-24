using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private Button button;
    public int level;

    private void Awake()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(Load);
    }

    private void Load()
    {
        GameManager.instance.LoadLevel("Level " + level.ToString());
    }
}
