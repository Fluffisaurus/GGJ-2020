using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
   public Vector2Int direction;

    private List<Stationary> stationaries;
    internal void SetupSimulate(List<Stationary> stationaries, int x, int y)
    {
        this.stationaries  = stationaries;
        this.direction =  new Vector2Int(x,y);
    }
    internal override Vector2Int Simulate()
    {
        int size = GridObject.i.size;
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
