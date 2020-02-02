using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public GameObject stationary;
    public GameObject player;
    public GameObject moving;
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
                grid[k, l] = transform.GetChild(k).GetChild(l).gameObject;

             //  Debug.Log(k + " "+l + " " + transform.GetChild(k) + " "+transform.GetChild(k).GetChild(l));
                // Debug.Log(curr);
            }
        }

        //AHMED For Testing!
        GameObject stationaryObj = Instantiate(stationary, Vector3.zero, Quaternion.identity);
        stationaryObj.transform.parent = grid[1,1].transform;
        stationaryObj.transform.localPosition = Vector3.zero;
        stationaryObj.GetComponent<Entity>().pos  = new Vector2Int(1,1);

        //AHMED For Testing!
        GameObject playerObj = Instantiate(player, Vector3.zero, Quaternion.identity);
        playerObj.transform.parent = grid[3,1].transform;
        playerObj.transform.localPosition = Vector3.zero;
        playerObj.GetComponent<Entity>().pos  = new Vector2Int(1,3);

        //AHMED For Testing!
        GameObject movingObj = Instantiate(moving, Vector3.zero, Quaternion.identity);
        movingObj.transform.parent = grid[2,0].transform;
        movingObj.transform.localPosition = Vector3.zero;
        movingObj.GetComponent<Moving>().active = true;
        movingObj.GetComponent<Moving>().direction = Vector2Int.up;
        movingObj.GetComponent<Moving>().pos  = new Vector2Int(0,2);

    }

    // Update is called once per frame
    public GameObject[,]  Grid()
    {
        return grid;
    }

    public List<GameObject> GetEntities()
    {
        List<GameObject> entities = new List<GameObject>();
         for (int k = 0; k < grid.GetLength(0); k++){
            for (int l = 0; l < grid.GetLength(1); l++)
            {
                if(grid[k, l].transform.childCount > 0)
                {
                    foreach (Transform child in grid[k, l].transform) 
                    {
                            entities.Add(child.gameObject);
                           // break; //Asumming a single child under each child 
                    }
                }
            }
        }
        return entities;
    }
}
