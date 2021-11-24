using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public GameObject _trail_render;
    public GameObject _base;
    public GameObject _canvas1;
    public GameObject _canvas2;


    public Text _text;
    public Text _text2;
    public Text _game_over;



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
    private Vector3 eul = new Vector3(0,0,0); 

    bool _end = true;
    bool game_continue = true; 

    int _count_of_rubin = 0;
    int _num = 0;

    float _speed = 50f;
    float _time = 0; 


    private AudioSource _audio;
    public AudioSource _audio_mp3;
    public AudioSource _audio_mp3_2;

    void Start()
    {
        _time = Time.timeScale;
        _line_now = number_of_lines._middle_line; 
        _location = transform.position;
        _left_line = new Vector3(-17.569f, _location.y,_location.z);
        _right_line = new Vector3(-11.058f, _location.y, _location.z);
        _middle_line = new Vector3(-14.43f, _location.y, _location.z);
        StartCoroutine(Speed(3.5f));
        Cursor.visible = false;
        _audio = this.GetComponent<AudioSource>();

    }

    // Update is called once per frame 
    void Update()
    {
        Time.timeScale = _time;
        if (game_continue) {

            _location = transform.position;
            transform.position = new Vector3(_location.x, _location.y, _base.transform.position.z - 60f);

            _base.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        
            //===============================================================
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _line_now == number_of_lines._right_line)
            {
                transform.position = new Vector3(_middle_line.x, _location.y, _location.z);
                _line_now = number_of_lines._middle_line;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {

                transform.position = new Vector3(_left_line.x, _location.y, _location.z);
                _line_now = number_of_lines._left_line;
            }
            //===============================================================
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _line_now == number_of_lines._left_line)
            {
                transform.position = new Vector3(_middle_line.x, _location.y, _location.z);
                _line_now = number_of_lines._middle_line;
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(_right_line.x, _location.y, _location.z);
                _line_now = number_of_lines._right_line;
            }
            //===============================================================
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_end)
                {
                    _end = false;
                    transform.Translate(Vector3.up * 3f);
                    _trail_render.GetComponent<TrailRenderer>().emitting = false;
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (transform.rotation.eulerAngles != eul)
                transform.eulerAngles = eul;

            if (Input.GetKeyDown(KeyCode.Escape) && _num == 0)
            {
                Cursor.visible = true;
                _game_over.text = "Pause";
                Time.timeScale = 0;
                _num++;
                Canvas_control();
            }
        }else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && _num == 1)
            {
                Time.timeScale = _time;
                _num--;
                _canvas1.SetActive(true);
                _canvas2.SetActive(false);
                game_continue = true;
                Cursor.visible = true;
            }

        };


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "gem_08(Clone)"){
            _text.text = (++_count_of_rubin).ToString();
            _text2.text = "Points " + (_count_of_rubin).ToString();
            _audio.Play(); 
        }
    }

    private void Canvas_control() {
        _canvas1.SetActive(false);
        _canvas2.SetActive(true);
        game_continue = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Base")
        {
            _end = true;
            _trail_render.GetComponent<TrailRenderer>().emitting = true;
        }
        else
        {
            _num = 3;
            _game_over.text = "Game Over";
            if (Random.Range(1, 3) == 1) 
                _audio_mp3_2.Play();
            else
                _audio_mp3.Play();
            Canvas_control(); 
            Cursor.visible = true;
        }
        
     
       
    }

    private IEnumerator Speed(float x)
    {
        _speed+=10;
        yield return new WaitForSeconds(x);
    }


}
