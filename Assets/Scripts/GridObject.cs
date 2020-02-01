using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{

    public static GridObject i;
    void Awake(){
        if(!i){
            i = this;
        } else {
            Destroy(this.gameObject);
            Debug.Log("singleton already exists.");
        }
    }
    private GameObject[,] grid;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[size, size];
        for (int k = 0; k < grid.GetLength(0); k++){
            for (int l = 0; l < grid.GetLength(1); l++){
                var curr = grid[k, l];
                curr = null;
                // Debug.Log(curr);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
