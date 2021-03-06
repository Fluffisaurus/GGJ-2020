﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Entity
{
    public Vector2Int direction;
    public bool active;
    public Sprite[] Cat_imgs;
    public Sprite[] CatImgsSleep;
    // Start is called before the first frame update
    void Start()
    {
        SwitchImages();
    }

    public void SwitchImages() {
        if(active){
            if(direction.x == 0 && direction.y == 1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = Cat_imgs[0];
            }
            else if(direction.x == 0 && direction.y == -1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = Cat_imgs[3];
            }  
            if(direction.x == -1 && direction.y == 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = Cat_imgs[2];
            }
            else if(direction.x == 1 && direction.y == 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = Cat_imgs[1];
            }
        } else {
            if(direction.x == 0 && direction.y == 1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = CatImgsSleep[0];
            }
            else if(direction.x == 0 && direction.y == -1) {
                gameObject.GetComponent<SpriteRenderer>().sprite = CatImgsSleep[3];
            }  
            if(direction.x == -1 && direction.y == 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = CatImgsSleep[2];
            }
            else if(direction.x == 1 && direction.y == 0) {
                gameObject.GetComponent<SpriteRenderer>().sprite = CatImgsSleep[1];
            }
        }
    }

    internal void SwitchDirection()
    {

        //direction change

        if (active) {
            direction = direction * -1;
            SwitchImages();
        }

    }
    internal override Vector2Int Simulate()
    {
        int size = FindObjectOfType<GridObject>().size;
        Vector2Int newPos =  pos + direction;
        if(active){
            if(newPos.x < 0 || newPos.x >= size || newPos.y < 0 || newPos.y >= size)
            {
                SwitchDirection();
                return Simulate();
            }
            else
            {
                return newPos;
            }
        }else {
            return pos;
        }
    }
}
