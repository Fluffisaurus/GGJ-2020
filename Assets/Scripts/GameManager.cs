using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
    float waitingTime = 0;
    // Update is called once per frame
    void Update()
    {
        if(waitingTime <= 0)
        {
            waitingTime = 0.3f;
            int x,y;
            x = GetX();
            y = GetY();
            if(x == 0 && y == 0)
            {
                return;
            }
            //Debug.Log(x + " " +y);

            Player player = entities.Find( e => e.GetComponent<Player>()).GetComponent<Player>();
            List<Stationary> stationary =  entities.FindAll( e => e.GetComponent<Stationary>()).Select( e => e.GetComponent<Stationary>()).ToList();
            List<Moving> moving =  entities.FindAll( e => e.GetComponent<Moving>()).Select( e => e.GetComponent<Moving>()).ToList();

            //List<Moving> moving =   entities.Select( e => e.GetComponent<Moving>()).ToList();

            player.SetupSimulate(stationary, x,y);
            Vector2Int newPlayerPos = player.Simulate();
            // Debug.Log(newPlayerPos);
             //Debug.Log(newPlayerPos);
            //Assuming no Overlap between moving entities
            //Assuming moving entities can step over stationary
            //Assuming player does not interaction with moving
            bool gameOver = false;
            foreach(Moving entity in moving)
            {
                Vector2Int newPos =  entity.Simulate();
                                Debug.Log( "moving " + entity.pos + " "+newPos);

                if(newPlayerPos.Equals(newPos))
                {
                    gameOver = true;
                }
                else
                {
                    entity.Move(grid, newPos);
                }
            }
            
            if(!gameOver)
            {
                player.Move(grid,newPlayerPos);
            }
            else
            {
                GameOver();
            }
          
        }
        else
        {
            waitingTime -= Time.deltaTime;
        }
    }
private int GetX()
{
    float dirX = Input.GetAxis("Horizontal");
    int x = 0;
    if(dirX > 0)
        {
            x = 1;
        }
        else if (dirX  < 0)
        {
            x = -1;
        }
        else if (dirX  == 0)
        {
            x = 0;
        }
        return x;
    }
    private int GetY(){
        float dirY = Input.GetAxis("Vertical");       
        int y = 0;
        if(dirY > 0)
        {
            y = -1;
        }
        else if (dirY  < 0)
        {
            y = 1;
        }
        else if (dirY  == 0)
        {
            y = 0;
        }
        return y;
    }
         
    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
