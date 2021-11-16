using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Run : MonoBehaviour
{

    public GameObject _base;
    enum number_of_lines{
        _left_line,
        _right_line,
        _middle_line,
    }

    number_of_lines _line_now;

    private Vector3 _location;
    private Vector3 _left_line;
    private Vector3 _right_line;
    private Vector3 _middle_line;

    void Start()
    {
        _line_now = number_of_lines._middle_line; 
        _location = transform.position;
        _left_line = new Vector3(GameObject.Find("_left_line").transform.position.x, _location.y,_location.z);
        _right_line = new Vector3(GameObject.Find("_right_line").transform.position.x, _location.y, _location.z);
        _middle_line = new Vector3(GameObject.Find("_middle_line").transform.position.x, _location.y, _location.z);
    }
 


    // Update is called once per frame
    void Update()
    {     
        _location = transform.position; 
        transform.Translate(Vector3.forward * Time.deltaTime * 2.5f);
        _base.transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        //===============================================================
        //===============================================================
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _line_now == number_of_lines._right_line)
        {   
                transform.position = new Vector3 (_middle_line.x,_location.y,_location.z);
                _line_now = number_of_lines._middle_line;
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position = new Vector3(_left_line.x, _location.y, _location.z);
            _line_now = number_of_lines._left_line;
        }
        //===============================================================
        //===============================================================
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _line_now == number_of_lines._left_line ){
            transform.position = new Vector3(_middle_line.x, _location.y, _location.z);
            _line_now = number_of_lines._middle_line;
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(_right_line.x, _location.y, _location.z);
            _line_now = number_of_lines._right_line;
        }
    }
}
