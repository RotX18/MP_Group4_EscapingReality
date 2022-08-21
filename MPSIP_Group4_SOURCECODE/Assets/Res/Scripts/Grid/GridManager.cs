using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class that manages any given GridSpawner
/// </summary>

public class GridManager : MonoBehaviour, IPuzzle
{
    #region PUBLIC VARS
    public GridSpawner spawner;
    public int[] correctElementIDs;
    #endregion

    #region PRIVATE VARS
    private List<GridElement> _elements = new();
    private List<GridElement> _currentRow = new();
    private List<GridElement> _currentRowCorrects = new();
    private int _currentRowNumber = 0;
    private int _totalCorrects = 0;
    private int _clickedCorrects = 0;
    private bool _getCorrects = true;
    private bool _doCorrectCheck = true;
    [SerializeField]
    private TextMeshProUGUI _text;
    #endregion

    #region PROPERTIES
    #region IPuzzle PROPERTIES
    public bool Completed {
        get;
        set;
    } = false;
    #endregion

    public int ClickedCorrects{
        get{
            return _clickedCorrects;
        }
        set{
            _clickedCorrects = value;
        }
    }
    #endregion

    #region INTERFACE METHODS
    public void OnComplete(){
        //ADD COMPLETED EFFECTS HERE
        Debug.Log("GRID HAS BEEN COMPLETED");
        _text.text = "Temasek Polytechnic was founded in June 1974.";
    }
    #endregion

    private void Start() {
        _elements = spawner.AllElements;

        //setting all elements to unclickable
        foreach(GridElement ele in _elements) {
            ele.Clickable = false;
        }

        //iterating through the correctElementIDs array to set the correct elements
        for(int i = 0; i < correctElementIDs.Length; i++){
            //setting all elements with the IDs in correctElementIDs to be correct
            spawner.FindElementByID(correctElementIDs[i]).GetComponent<GridElement>().Correct = true;
        }

        //settting the first current row
        _currentRow = spawner.FindElementsInRow(_currentRowNumber);

        //setting _currentRow as clickable
        foreach(GridElement ele in _currentRow){
            ele.Clickable = true;
        }

        foreach(GridElement ele in _elements){ 
            if(ele.Correct){
                //keeping count the total number of correct elements
                _totalCorrects++;
            }
        }
    }

    private void Update() {
        //get all correct elements in current row
        if(_getCorrects) {
            StartCoroutine(SetCurrentCorrects());
        }

        //check whether all correct elements have been clicked
        if(_doCorrectCheck){            
            StartCoroutine(CheckCorrects());
        }

        //completed check
        if(_clickedCorrects == _totalCorrects){
            //if the number of clicked correct elements = total number of correct elements
            Completed = true;
        }
    }

    private IEnumerator SetCurrentCorrects(){
        _getCorrects = false;

        _currentRowCorrects.Clear();
        
        //iterating through the current row of elements
        foreach(GridElement ele in _currentRow){ 
            if(ele.Correct){
                _currentRowCorrects.Add(ele);
            }
        }
        yield return new WaitForEndOfFrame();
    }

    private IEnumerator CheckCorrects(){
        _doCorrectCheck = false;
        List<GridElement> clickedCorrects = new();

        //iterating through all corrects elements in the current row
        foreach(GridElement ele in _currentRowCorrects){
            if(ele.Clicked){
                //if the element has been clicked, add it to the list
                clickedCorrects.Add(ele);
            }
        }

        //proceeds onto next row
        if(clickedCorrects.Count == _currentRowCorrects.Count){
            clickedCorrects.Clear();
            GoNext();
        }

        yield return new WaitForEndOfFrame();

        _doCorrectCheck = true;
    }

    private void GoNext() {
        //setting next current row
        if(_currentRowNumber != spawner.lenY - 1) {
            //if the current row is not the last row
            //increment the number
            _currentRowNumber++;

            //setting the next row
            _currentRow.Clear();
            _currentRow = spawner.FindElementsInRow(_currentRowNumber);

            //setting new row as clickable
            foreach(GridElement ele in _currentRow) {
                ele.Clickable = true;
            }

            _getCorrects = true;
        }
    }

    public void ResetGrid() {
        //resetting the grid elements
        foreach(GridElement ele in _elements) {
            ele.GetComponent<Renderer>().material.color = Color.white;
            ele.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
            ele.Clickable = false;
            ele.Clicked = false;
        }

        //resetting internal vars
        _currentRow.Clear();
        _currentRowCorrects.Clear();
        _currentRowNumber = 0;
        _clickedCorrects = 0;

        //getting the current row and its correct elements
        _currentRow = spawner.FindElementsInRow(_currentRowNumber);
        _getCorrects = true;

        //making the current row clickable
        foreach(GridElement ele in _currentRow){
            ele.Clickable = true;
        }
    }
}
