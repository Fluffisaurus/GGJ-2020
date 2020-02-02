using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Entity : MonoBehaviour
{
    public Vector2Int pos;
    // Start is called before the first frame update

    virtual internal Vector2Int Simulate()
    {
        return pos;
    }
    virtual internal void Move(GameObject[,] grid, Vector2Int newPos)
    {
        this.gameObject.transform.parent = grid[newPos.y,newPos.x].transform;
        //this.gameObject.transform.localPosition = Vector3.zero;
        this.gameObject.transform.DOLocalMove(Vector3.zero,1f);
        this.pos = newPos;

    }
}
