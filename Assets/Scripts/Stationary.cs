using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stationary : Entity
{
    public bool interactable;
    public bool passable;
    public StationaryType type;

    public Sprite[] tableImgs;

    public Sprite[] vaseImgs;

    public Sprite[] exitImgs;
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(tableImgs.Length);
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
                gameObject.GetComponent<SpriteRenderer>().sprite = tableImgs[1];
            }else {
               // gameObject.GetComponent<SpriteRenderer>().sprite = tableImgs[0];
            }
        }
        if(type == StationaryType.Vase)
        {
            //TODO vase destroyed here
        }
        if(type == StationaryType.Exit)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = exitImgs[1];
        }
 
    }



}
