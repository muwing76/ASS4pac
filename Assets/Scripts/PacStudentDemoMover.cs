using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentDemoMover : MonoBehaviour
{
    public Vector3[] waypoints;        //填坐标
    public float cellsPerSecond = 6f;  //速度）
    int idx = 0; Vector3 from, to; float t;
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints == null || waypoints.Length < 2) return;
        transform.position = waypoints[0];
        NextP();
    }
    void NextP()
    {
        from = waypoints[idx];
        idx = (idx + 1) % waypoints.Length;
        to = waypoints[idx];
        t = 0f;
    }
        // Update is called once per frame
        void Update()
    {
        t += Time.deltaTime * cellsPerSecond / Mathf.Max(0.001f, Vector3.Distance(from, to));
        transform.position = Vector3.Lerp(from, to, t);   // 线性匀速
        if (t >= 1f) NextP();
    }
}
