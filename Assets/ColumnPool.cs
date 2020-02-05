﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public float spawnRate = 4f;
    public int columnPoolSize = 5;
    public float columnYMin = -2f;
    public float columnYMax = 2f;

    private float timeSinceLastSpawn;
    private float spawnXPosition = 5f;
    private int currentColumn = 0;

    public GameObject columnsPrefab;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-14,-15f);

    // Use this for initialization
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i=0; i< columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnsPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(!GameController.Instance.isGameOver && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = Random.Range(columnYMin, columnYMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentColumn++;

            if(currentColumn >= columnPoolSize) { currentColumn = 0; }
        }
    }
}
