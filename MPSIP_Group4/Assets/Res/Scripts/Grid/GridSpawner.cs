using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawner for the grid that takes in a prefab and instantiates
/// it according to the given dimensions of the desired grid
/// </summary>

public class GridSpawner : MonoBehaviour
{
    #region PUBLIC VARS

    //grid element that will be instantiated
    [Header("Object to be instantiated as elements of the grid")]
    public GameObject gridElement;

    //grid dimensions, lenX units by lenY units
    [Header("Grid size of lenX * lenY")]
    [Min(1)]
    public int lenX;
    [Min(1)]
    public int lenY;

    //spacing between each element along the X and Y axis
    [Header("X-axis spacing of spaceX, Y-axis spacing of spaceY")]
    [Min(0)]
    public float spaceX;
    [Min(0)]
    public float spaceY;

    #endregion

    #region PRIVATE VARS

    private GameObject _instantiatedObj;
    private List<GridElement> _elements = new();

    #endregion

    #region PROPERTIES

    public List<GridElement> AllElements{ 
        get{
            return _elements;
        }
    }

    #endregion

    private void Awake() {
        for(int i = 0; i < lenY; i++){
            //for each column
            for(int j = 0; j < lenX; j++){
                //for each row in each column
                //instantiating each gridElement with space inbetween
                _instantiatedObj = Instantiate(gridElement, new Vector3(transform.position.x + j + (j * spaceX), transform.position.y + i + (i * spaceY), transform.position.z), Quaternion.identity);

                //setting the X and Y position for the instantiated ibject
                _instantiatedObj.GetComponent<GridElement>().GridX = j;
                _instantiatedObj.GetComponent<GridElement>().GridY = i;

                //converting the gridX and gridY to strings, concatenating and converting value back to int and storing it as the ID
                //eg. if one of the obj is at position (1, 2), its id would be 12
                string idString = j.ToString() + i.ToString();
                _instantiatedObj.GetComponent<GridElement>().ID = int.Parse(idString);

                //setting the instantiated object as a child of the spawner
                _instantiatedObj.transform.parent = gameObject.transform;

                //adding to the elements list
                _elements.Add(_instantiatedObj.GetComponent<GridElement>());
            }
        }
    }

    public GameObject FindElementByID(int id){
        //iterating through the children array to find first element that has the same id as the query id
        foreach(GridElement ele in _elements){ 
            if(ele.ID == id){
                //returning gameObject if id matches
                return ele.gameObject;
            }
            else{
                continue;
            }
        }
        //returning null if none of the elements in children have the same id
        return null;
    }

    public List<GridElement> FindElementsInRow(int row){
        List<GridElement> result = new();

        for(int i = 0; i < _elements.Count; i++){
            //iterating through elements and adding to result if row matches
            if(_elements[i].GridY == row){
                result.Add(_elements[i]);
            }
            else{
                continue;
            }
        }
        return result;
    }
    
    public List<GridElement> FindElementsInColumn(int column){
        List<GridElement> result = new();

        for(int i = 0; i < _elements.Count; i++) {
            //iterating through elements and adding to result if row matches
            if(_elements[i].GridX == column) {
                result.Add(_elements[i]);
            }
            else {
                continue;
            }
        }
        return result;
    }
}
