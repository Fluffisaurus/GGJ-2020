﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary : Entity
{
    private bool interactable;
    private bool passable;
    public StationaryType type;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Interact()
    {
        if(interactable)
        {
            //assuming not passable ->  passable only
            if(passable)
            {
                return false;
            }
            else
            {
                passable = true;
                return true;
            }          
        }
        else
        {
            return false;
        }

    }
  
    

}
