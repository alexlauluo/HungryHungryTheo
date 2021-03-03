using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManger : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            StartGame();
        }
    }

    public void StartGame(){
        GameManager.instance.LoadLevel("Menu");
    }
}
