using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    public float cellsPerSecond = 6f; 
    public Vector2 cellSize = Vector2.one;
    public LayerMask wallMask;
    Vector2Int gridPos, lastInput, currentInput; 
    bool lerp; 
    Vector3 fromPos, toPos; 
    float t;

    Vector3 G2W(Vector2Int gp) => new(gp.x * cellSize.x, gp.y * cellSize.y, 0);
    Vector2Int W2G(Vector3 wp) => new(Mathf.RoundToInt(wp.x / cellSize.x), Mathf.RoundToInt(wp.y / cellSize.y));
    // Start is called before the first frame update
    void Start()
    {
        gridPos = W2G(transform.position); 
        currentInput = Vector2Int.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) lastInput = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.S)) lastInput = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.A)) lastInput = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.D)) lastInput = Vector2Int.right;
        if (!lerp) { if (!TMove(lastInput)) TMove(currentInput); }
        else
        {
            t += Time.deltaTime * cellsPerSecond; transform.position = Vector3.Lerp(fromPos, toPos, t);
            if (t >= 1f) { lerp = false; gridPos += currentInput; transform.position = toPos; }
        }
        bool TMove(Vector2Int dir)
        {
            if (dir == Vector2Int.zero) 
                return false;
            var next = gridPos + dir; 
            if (!Walk(next)) 
                return false; currentInput = dir;
            fromPos = G2W(gridPos); 
            toPos = G2W(next); t = 0; 
            lerp = true; 
            return true;
        }
        bool Walk(Vector2Int gp)
        { 
            var p = G2W(gp); 
            float r = 0.4f * Mathf.Min(cellSize.x, cellSize.y); 
            return !Physics2D.OverlapCircle(p, r, wallMask); 
        }
      
    }
}
