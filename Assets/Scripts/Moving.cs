using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : Entity
{
    public Vector2Int direction;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    internal void SwitchDirection()
    {
        direction = direction * -1;
    }
    internal override Vector2Int Simulate()
    {
        int size = GridObject.i.size;
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
