﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Entity
{
    public Vector2Int direction;
    public bool active;
    public Sprite[] cat_imgs;
    // Start is called before the first frame update
    void Start()
    {
        if (active) 
        {
            if(direction.x == 1 && direction.y == 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = cat_imgs[1];
            }
            else if(direction.x == -1 && direction.y == 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = cat_imgs[2];
            }
            else if(direction.x == 0 && direction.y == 1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = cat_imgs[3];
            }  
            else if(direction.x == 0 && direction.y == -1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = cat_imgs[0];
            }
        }
    }

    
    internal void SwitchDirection()
    {
        //direction change
        direction = direction * -1;
    }
    internal override Vector2Int Simulate()
    {
        int size = FindObjectOfType<GridObject>().size;
        Vector2Int newPos =  pos + direction;
        if(newPos.x < 0 || newPos.x >= size || newPos.y < 0 || newPos.y >= size)
        {
            SwitchDirection();
            return Simulate();
        }
        else
        {
            return newPos;
        }
    }
}
