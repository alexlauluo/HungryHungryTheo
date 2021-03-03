using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Sprite open;
    public Sprite close;
    public SpriteRenderer reticle;
    private Camera main;

    void Start(){
        reticle = GetComponent<SpriteRenderer>();
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKey(KeyCode.Mouse0)){
            reticle.sprite = close;
        }
        else{
            reticle.sprite = open;
        }
    }
}
