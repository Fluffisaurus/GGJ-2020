using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[,] grid;
    private List<GameObject> entities;
    private GridObject gridObject;
    // Start is called before the first frame update
    void Start()
    {
        gridObject = GridObject.i;
        grid = gridObject.Grid();
        entities = gridObject.GetEntities();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown ("w")) 
        {
            foreach(var entity in entities)
            {
                
                Debug.Log(entity);
            }
        }
    }
}
