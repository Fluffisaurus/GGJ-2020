using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
   public Vector2Int direction;

   public Sprite[] rat_imgs;

    private List<Stationary> stationaries;
    internal void SetupSimulate(List<Stationary> stationaries, int x, int y)
    {
        this.stationaries  = stationaries;
        this.direction =  new Vector2Int(x,y);
        //depending on what direction is, update image accordingly

        // if(x == 0 && y == 0) {
        //     rat.GetComponent<SpriteRenderer>().sprite = rat_imgs[0];
        // }
        if(x == 1 && y == 0) {
            gameObject.GetComponent<SpriteRenderer>().sprite = rat_imgs[1];
        }
        else if(x == -1 && y == 0) {
            gameObject.GetComponent<SpriteRenderer>().sprite = rat_imgs[2];
        }
        else if(x == 0 && y == 1) {
            gameObject.GetComponent<SpriteRenderer>().sprite = rat_imgs[0];
        }
        else if(x == 0 && y == -1) {
            gameObject.GetComponent<SpriteRenderer>().sprite = rat_imgs[3];
        }
    }
    
    internal override Vector2Int Simulate()
    {
        int size = FindObjectOfType<GridObject>().size;
        Vector2Int newPos =  pos + direction;
        
        if(newPos.x < 0 || newPos.x >= size || newPos.y < 0 || newPos.y >= size)
        {
            return pos;
        }
        
        foreach(Stationary stationary in stationaries)
        {
            if(newPos.Equals(stationary.pos))
            {
                Debug.Log("Stationary!");
                return pos;
            }
        }
   
        return newPos;
        
    }
}
