using UnityEngine;

public class LockInput: MonoBehaviour {

    #region PRIVATE VARS
    private LockDial[] _lockDials;
    private LockManager _lockManager;
    private LockDial _currentDial;
    private Vector2 _lThumbStickInput;
    private Vector2 _rThumbStickInput;
    private int _currentDialIndex = 0;
    private bool _turnDial = true;
    private bool _changeDial = true;
    #endregion

    // Start is called before the first frame update
    void Start() {
        _lockManager = GetComponentInParent<LockManager>();
        _lockDials = _lockManager.lockDials;
        _currentDial = _lockDials[_currentDialIndex];
    }

    // Update is called once per frame
    void Update() {
        if(_lockManager.GetComponent<IPickable>().Grabbed) {
            _lThumbStickInput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
            _rThumbStickInput = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

            //LEFT CONTROLLER GRAB
            if(_lockManager.GetComponent<IPickable>().CurrentController == IPickable.Controller.LTouch) {
                UpdateCurrentDial(0);
                //Lock interaction
                //turning current dial
                if(_turnDial){
                    _turnDial = false;

                    //Up and Down = changing numbers
                    if(_lThumbStickInput.y < -0.03f || _lThumbStickInput.y > 0.03f) {
                        //if the input is more than 0.5f way in either y direction, rotate the dial
                        _currentDial.CurrentNumber = Normalise(_lThumbStickInput.y);
                    }
                }

                //changing current dial
                else if(_changeDial){
                    _changeDial = false;
                    //Left and Right = changing selected dial
                    if(_lThumbStickInput.x < -0.03f || _lThumbStickInput.x > 0.03f) {
                        //if the input is more than 0.5f in either x direction, change dials
                        UpdateCurrentDial(Normalise(_lThumbStickInput.x));
                    }
                }

                if(_lThumbStickInput.y == 0 && _lThumbStickInput.x == 0){
                    _turnDial = true;
                    _changeDial = true;
                }
            }
            //RIGHT CONTROLLER GRAB
            else if(_lockManager.GetComponent<IPickable>().CurrentController == IPickable.Controller.RTouch) {
                UpdateCurrentDial(0);
                //Lock interaction
                //turning current dial
                if(_turnDial) {
                    _turnDial = false;

                    //Up and Down = changing numbers
                    if(_rThumbStickInput.y < -0.03f || _rThumbStickInput.y > 0.03f) {
                        //if the input is more than 0.5f way in either y direction, rotate the dial
                        _currentDial.CurrentNumber = Normalise(_rThumbStickInput.y);
                    }
                }

                //changing current dial
                else if(_changeDial) {
                    _changeDial = false;
                    //Left and Right = changing selected dial
                    if(_rThumbStickInput.x < -0.03f || _rThumbStickInput.x > 0.03f) {
                        //if the input is more than 0.5f in either x direction, change dials
                        UpdateCurrentDial(Normalise(_rThumbStickInput.x));
                    }
                }

                if(_rThumbStickInput.y == 0 && _rThumbStickInput.x == 0) {
                    _turnDial = true;
                    _changeDial = true;
                }
            }
        }
    }

    private void UpdateCurrentDial(int input){
        //incrementing the current dial index

        _currentDialIndex += input;
        //setting the old dial to white before the change
        _currentDial.GetComponentInChildren<MeshRenderer>().material.color = Color.white;

        //error proofing for dial index
        if(_currentDialIndex >= _lockDials.Length) {
            //if the current dial index is greater than the length, set it to the first element
            _currentDialIndex = 0;
            _currentDial = _lockDials[_currentDialIndex];
        }
        else if(_currentDialIndex < 0) {
            //if the current dial index is less than 0, set it to the highest possible indexs
            _currentDialIndex = _lockDials.Length - 1;
            _currentDial = _lockDials[_currentDialIndex];
        }
        else {
            //if the current dial index falls within the array length, set the new current dial
            _currentDial = _lockDials[_currentDialIndex];
        }

        //CODE FOR UI CHANGE AND OTHER EFFECTS BELOW HERE
        //setting the colour to red after the new dial has been selected
        _currentDial.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    private int Normalise(float f){ 
        if(f < 0){
            return -1;
        }
        else if(f > 0){
            return 1;
        }
        else{
            return 0;
        }
    }
}
