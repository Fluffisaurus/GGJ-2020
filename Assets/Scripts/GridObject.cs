using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GridObject : MonoBehaviour
{
    
    public string levelName;
    public int numMoves;
    public int maxNumPickups;
    public int numPickups;
    
    public GameObject[] stationaryObj; // Vase, Table, Wall, Exit
    public GameObject vase;
    public GameObject table;
    public GameObject wall;
    public GameObject exit;
    public GameObject player;
    public GameObject movingObj;
    private GameObject[,] grid;
    public int size;
    // Start is called before the first frame update

    public void LoadGrid(string levelName)
    {
        char[] seps = {',', '\n'};
        String[] data = File.ReadAllText("Assets/Resources/"+levelName+ ".txt").Split(seps);
        size = (int)Math.Sqrt(data.Length);
        String[,] symbols = new String[size, size];
        //Debug.Log(data.Length);

        //put 1D array into 2D array
        for (int k = 0; k < symbols.GetLength(0); k++){
            for (int l = 0; l < symbols.GetLength(1); l++){
                symbols[l, k] = data[k*size+l];
                // Debug.Log(symbols[l,k]);
            }
        }

        //check dimension
        // Debug.Log(symbols.GetLength(0));
        // Debug.Log(symbols.GetLength(1));


        // get grid references to nodes
        grid = new GameObject[size, size]; //adjust size to data length
        for (int k = 0; k < grid.GetLength(0); k++){
            for (int l = 0; l < grid.GetLength(1); l++){
                grid[k, l] = transform.GetChild(k).GetChild(l).gameObject;
            }
        }

        // switch case within a loop
        // insert based on character symbol
        for (int k = 0; k < symbols.GetLength(0); k++){
            for (int l = 0; l < symbols.GetLength(1); l++){
                string curr = symbols[k, l];

                GameObject currObj = null;
                switch(curr){
                    case "CAN":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = true;
                        currObj.GetComponent<Moving>().direction = Vector2Int.down;
                        break;
                    case "CAE":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = true;
                        currObj.GetComponent<Moving>().direction = Vector2Int.right;
                        break;
                    case "CAS":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = true;
                        currObj.GetComponent<Moving>().direction = Vector2Int.up;
                        break;
                    case "CAW": // Cat-Sleeping-Down
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = true;
                        currObj.GetComponent<Moving>().direction = Vector2Int.left;
                        break;
                    case "CSN":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = false;
                        currObj.GetComponent<Moving>().direction = Vector2Int.up;
                        break;
                    case "CSE":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = false;
                        currObj.GetComponent<Moving>().direction = Vector2Int.right;
                        break;
                    case "CSS":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = false;
                        currObj.GetComponent<Moving>().direction = Vector2Int.down;
                        break;
                    case "CSW":
                        currObj = Instantiate(movingObj, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Moving>().active = false;
                        currObj.GetComponent<Moving>().direction = Vector2Int.left;
                        break;
                    case "R":
                        currObj = Instantiate(player, Vector3.zero, Quaternion.identity);
                        break;
                    case "V":
                        currObj = Instantiate(vase, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Stationary>().interactable = true;
                        currObj.GetComponent<Stationary>().passable = false;
                        currObj.GetComponent<Stationary>().type = StationaryType.Vase;
                        maxNumPickups+= 1;
                        break;
                    case "T":
                        currObj = Instantiate(table, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Stationary>().interactable = true;
                        currObj.GetComponent<Stationary>().passable = false;
                        currObj.GetComponent<Stationary>().type = StationaryType.Table;
                        break;
                    case "W":
                        currObj = Instantiate(wall, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Stationary>().interactable = false;
                        currObj.GetComponent<Stationary>().passable = false;
                        currObj.GetComponent<Stationary>().type = StationaryType.Wall;
                        break;
                    case "E":
                        currObj = Instantiate(exit, Vector3.zero, Quaternion.identity);
                        currObj.GetComponent<Stationary>().interactable = true;
                        currObj.GetComponent<Stationary>().passable = true;
                        currObj.GetComponent<Stationary>().type = StationaryType.Exit;
                        break;
                    case "N": //null
                        break;
                    default:
                        //Debug.Log("shit dun exist fam");
                        break;
                }
                if(!(currObj is null)){
                    // Debug.Log(currObj);
                    // Debug.Log(currObj.transform.position);
                    // Debug.Log(currObj.transform.parent);
                    currObj.transform.parent = grid[l, k].transform;
                    currObj.transform.localPosition = Vector3.zero;
                    currObj.GetComponent<Entity>().pos = new Vector2Int(k, l);
                }

            }
        }


        /*
        //AHMED For Testing!
        GameObject stationaryObj = Instantiate(stationary, Vector3.zero, Quaternion.identity);
        stationaryObj.transform.parent = grid[1,0].transform;
        stationaryObj.transform.localPosition = Vector3.zero;
        stationaryObj.GetComponent<Entity>().pos  = new Vector2Int(0,1);

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
        */
    }
    void Start()
    {
        LoadGrid(levelName);
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
