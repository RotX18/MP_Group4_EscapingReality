using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner for the grid that takes in a prefab and instantiates
/// it according to the given dimensions of the desired grid
/// </summary>

public class GridSpawner : MonoBehaviour
{
    [Header("Object to be instantiated")]
    public GameObject gridElement;

    [Header("Grid size of lenX * lenY")]
    public int lenX;
    public int lenY;

    [Header("X-axis spacing of spaceX, Y-axis spacing of spaceY")]
    public float spaceX;
    public float spaceY;

    private void Start() {
        for(int i = 0; i < lenY; i++){
            //for each column
            for(int j = 0; j < lenX; j++){
                //for each row in each column
                //instantiating each cube with space inbetween
                Instantiate(gridElement, new Vector3(transform.position.x + j + (j * spaceX), transform.position.y + i + (i * spaceY), transform.position.z), Quaternion.identity);
            }
        }
    }
}
