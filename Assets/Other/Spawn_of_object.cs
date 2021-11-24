using System.Collections;
using UnityEngine;


 class Spawn_gameObjects : MonoBehaviour{
    private GameObject _gm; 
    public virtual void GameObject_spawn(Vector3 _position,  Vector3 _v){}
};


class Square :  Spawn_gameObjects 
{
    private GameObject _gm = Instantiate(GameObject.Find("_right_line"));
    public override void GameObject_spawn(Vector3 _position, Vector3 _v)
    {
        Instantiate(_gm);
        _gm.transform.position = new Vector3(_position.x, _position.y + 1.2f, _v.z + 30f);
        _gm.transform.localScale = new Vector3(1f, 1f, 1f);
    }

};

class Wall : Spawn_gameObjects
{
    private GameObject _gm = Instantiate(GameObject.Find("_right_line"));
    public override void GameObject_spawn(Vector3 _position, Vector3 _v)
    {
        Instantiate(_gm);
        _gm.transform.position = new Vector3(_position.x, _position.y + 1f, _v.z + 30f);
        _gm.transform.localScale = new Vector3(3f, 9f, 0.5f);
    }
    
};

class Rubin : Spawn_gameObjects
{
    private GameObject _gm;
    public Rubin(GameObject _gm){
        this._gm = _gm; 
    }

    public override void GameObject_spawn(Vector3 _position, Vector3 _v){
        if (Random.Range(0, 2) == 1){
            for (float i = 0; i < 0.20; i += 0.05f)
                Instantiate(_gm).transform.position = new Vector3(_position.x, _position.y + 1f, _v.z + i * 25);
        }
        else{
            for (float i = 0; i < 0.10; i += 0.05f)
                Instantiate(_gm).transform.position = new Vector3(_position.x, _position.y + 1f, _v.z + i * 25);
        }
    }
}

public class Spawn_of_object : MonoBehaviour
{ 
    public GameObject _rubin;
    public GameObject _right_line;
    public GameObject _left_line;
    public GameObject _middle_line;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(base_corutin(0.5f));
        StartCoroutine(base_corutin(1f));
        StartCoroutine(spawn_of_money(3f));
        StartCoroutine(spawn_of_money(2f));
    }

    private IEnumerator base_corutin(float x)
    {
        Spawn_gameObjects s = null;
        while (true)
        {

            _ = Random.Range(1, 3) == 1 ? s = new Square() : s = new Wall();


            switch (Random.Range(1, 4))
            {
                case 1:
                    s.GameObject_spawn(_right_line.transform.position, transform.position);
                    break;
                case 2:
                    s.GameObject_spawn(_left_line.transform.position, transform.position);
                    break;
                case 3:
                    s.GameObject_spawn(_middle_line.transform.position, transform.position);
                    break; 
            }


            yield return new WaitForSeconds(x);

        }
    }



    private IEnumerator spawn_of_money(float x)
    {
        Rubin _rb = new Rubin(_rubin);
        while (true)
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    _rb.GameObject_spawn(_right_line.transform.position, transform.position);
                    break;
                case 2:
                    _rb.GameObject_spawn(_middle_line.transform.position, transform.position);
                    break;
                case 3:
                    _rb.GameObject_spawn(_middle_line.transform.position, transform.position);
                    break;
            }
            yield return new WaitForSeconds(x);
        }
        
    }
}
