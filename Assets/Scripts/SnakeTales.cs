using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class SnakeTales : MonoBehaviour
{
    public Transform Player;
    public float CircleDiameter;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Start()
    {
        positions.Add(Player.position);
        AddCircle();
        AddCircle();
    }

    private void Update()
    {
        float distance = ((Vector3)Player.position - positions[1]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = ((Vector3)Player.position - positions[1]).normalized;
            positions.Insert(0, positions[1] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i = 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
       
        Transform circle = Instantiate(Player, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }
}
