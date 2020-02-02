using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesWatcher : MonoBehaviour
{
    private GridObject gridObject;
    // Start is called before the first frame update
    void Start()
    {
        gridObject = FindObjectOfType<GridObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gridObject)
        {
            //this.GetComponent<Text>() = gridObject.numMoves;
        }
    }
}
