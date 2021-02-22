using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SushiCounter : MonoBehaviour
{
    private Spawner spawner;
    private Text counterText;

    private int counter;

    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
        counterText = this.GetComponentInChildren<Text>();
        counter = spawner.sushiList.Length;
        counterText.text = counter.ToString();
    }

    public void DecrementCounter()
    {
        counter--;
        counterText.text = counter.ToString();
    }
}
