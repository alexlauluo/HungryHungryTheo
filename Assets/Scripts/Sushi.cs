using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sushi : MonoBehaviour
{
    private int maxHealth;
    private int currHealth;
    private int points;
    private int index;

    public Sprite[] images;
    private SpriteRenderer spriteRenderer;
    public GameObject HealthTextPrefab;

    private LevelManager levelManager;



    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Init(LevelManager levelManager, int sushiIndex){
        index = sushiIndex;
        this.levelManager = levelManager;
        maxHealth = Constants.sushiHealth[sushiIndex];
        currHealth = maxHealth;
        points = Constants.sushiPoints[sushiIndex];
    }

    public void TakeDamage()
    {
        if(currHealth == 0) return;
        currHealth--;
        UpdateSprite();
        if (currHealth == 0)
        {
            Eaten();
        } 
        else{
            AudioManager.instance.Play("bite");
            GameObject HealthText = Instantiate(HealthTextPrefab, this.transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity, this.transform);
            HealthText.GetComponent<TextMesh>().text = currHealth.ToString();
        }
        
    }

    private void Eaten()
    {
        // this.tag = "Plate";
        this.GetComponent<CircleCollider2D>().isTrigger = true; //removes the physical hitbox for the plate by turning it into a trigger
        //FindObjectOfType<GachaponManager>().Enable();
        levelManager.UpdateScore(points);

        AudioManager.instance.Play("finish");

        // data
        GameManager.instance.sushiEatenCounter[index]++;

        // Pop up text
        GameObject HealthText = Instantiate(HealthTextPrefab, this.transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity, this.transform);
        HealthText.transform.localScale = Vector3.one * 3f;
        HealthText.GetComponent<TextMesh>().text = "+" + points;
    }

    private void UpdateSprite()
    {
        int spriteHealth = (int)((float)currHealth / maxHealth * 3);
        
        if (currHealth != 0 && spriteHealth == 0)
        {
            spriteRenderer.sprite = images[1];
        } else
        {
            spriteRenderer.sprite = images[spriteHealth];
        }
    }
}
