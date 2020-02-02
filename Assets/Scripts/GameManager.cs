using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    private GameObject[,] grid;
    private List<GameObject> entities;
    private GridObject gridObject;
    private List<Stationary> stationary ;
    private Player player;
    List<Moving> moving;
    void Start()
    {
        gridObject = GridObject.i;
        grid = gridObject.Grid();
        entities = gridObject.GetEntities();
        player = entities.Find( e => e.GetComponent<Player>()).GetComponent<Player>();
        stationary  =  entities.FindAll( e => e.GetComponent<Stationary>()).Select( e => e.GetComponent<Stationary>()).ToList();
        moving =  entities.FindAll( e => e.GetComponent<Moving>()).Select( e => e.GetComponent<Moving>()).ToList();
    }

    float waitingTime = 0;
    GameObject closest = null;

    int closestX, closestY;
    // Update is called once per frame
    void Update()
    {
        float closestDistance = float.MaxValue;
        List<Tuple> nearby = GetNearCells(grid,player);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        foreach(Tuple tuple in nearby)
        {
            //Debug.Log(entity);
            float distance = Vector3.Distance(tuple.obj.transform.position, mousePos);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closest = tuple.obj;
                closestX = tuple.x;
                closestY = tuple.y;
            }
        }
  
        
       // if(waitingTime <= 0)
        {
            waitingTime = 0.3f;
            Vector2Int diffPos = new Vector2Int(closestY, closestX) - player.pos ;
            int x = diffPos.x;
            int y = diffPos.y;
            
            if(Input.GetMouseButtonDown(0))
            {     
                bool gameOver = false;
                bool gameWon = false;

                //Vases can be  
                foreach(Stationary entity in stationary)
                {
                    //Mouse trap
                    if(entity.type == StationaryType.Wall)
                    {
                        gameOver = true;
                    }
                    else if (entity.type == StationaryType.Table)
                    {
                        entity.Interact();
                    }
                    else if (entity.type == StationaryType.Vase)
                    {
                        entity.Interact();
                        //TODO collect key
                    }
                    else if (entity.type == StationaryType.Exit)
                    {
                        gameWon = true;
                    }
                    //Based on Type of stationary INteract has different effects;
                }

                player.SetupSimulate(stationary, x,y);
                Vector2Int newPlayerPos = player.Simulate();

                //Assuming no Overlap between moving entities
                //Assuming moving entities can step over stationary
                //Assuming player does not interaction with moving
                foreach(Moving movingEntity in moving)
                {
                    //Considering current positions
                    //TODO waking the moving here
                    if(newPlayerPos.Equals(movingEntity.pos))
                    {
                        if(!movingEntity.active)
                        {
                            movingEntity.active = true;
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }

                    //Considering future positions
                    Vector2Int newPos =  movingEntity.Simulate();
                    if(newPlayerPos.Equals(newPos))
                    {
                        gameOver = true;
                    }
                    else
                    {
                        movingEntity.Move(grid, newPos);
                    }
                }

                //TODO handle # of moves, if exceeded, gameOver = true


                if(gameWon)
                {
                    GameWon();
                }
                else if(gameOver)
                {
                      GameOver();           
                }
                else
                {
                    player.Move(grid,newPlayerPos);
                }
            }
          
        }
      //  else
        {
            waitingTime -= Time.deltaTime;
        }


        if(closest)
        {
            closest.transform.localPosition = 
            new Vector3(closest.transform.localPosition.x, 
            closest.transform.localPosition.y + 0.01f * dir,
            closest.transform.localPosition.z );

            dir *= -1;

        }
    }
    
    int dir = 1;
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
    void GameWon()
    {
        Debug.Log("Game WON :)");
    }
    List<Tuple> GetNearCells(GameObject[,] grid, Player p)
    {
         int size = GridObject.i.size;
        List<Tuple> nearby = new List<Tuple>();
        int y = p.pos.x;
        int x = p.pos.y;

        int rx = x + 1;
        int dy = y + 1;
        int lx = x - 1;
        int uy = y - 1;

        if(rx < size)
        {
            nearby.Add(new Tuple(grid[rx,y],rx,y));

        }
        if(lx >= 0)
        {
            nearby.Add(new Tuple(grid[lx,y],lx,y));
        }

        if(uy >= 0)
        {
            nearby.Add(new Tuple(grid[x,uy],x,uy));
        }
         if(dy < size)
        {
            nearby.Add(new Tuple(grid[x,dy],x,dy));
        }

        return nearby;
    }
    class Tuple
    {
        public Tuple(GameObject obj, int x, int y)
        {
            this.obj = obj;
            this.x = x;
            this.y = y;
        }
        public int x,y;
        public GameObject obj;
    }
}
