using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary : Entity
{
    public bool interactable;
    public bool passable;
    public StationaryType type;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Interact()
    {
        if(type == StationaryType.Table)
        {
            if(!passable)
            {
                passable = true;
                //TODO Table flipped here
            }
        }
        if(type == StationaryType.Vase)
        {
            //TODO vase destroyed here
            
        }

    }
  
    

}
