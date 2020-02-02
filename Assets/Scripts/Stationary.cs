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
            if(interactable){
                interactable = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = vaseImgs[1];
            } else {
                interactable = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = vaseImgs[0];
            }
        }

    }



}
