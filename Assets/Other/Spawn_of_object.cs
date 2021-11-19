using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


 class Spawn_gameObjects : MonoBehaviour{
    public virtual void GameObject_spawn(GameObject _gm, Vector3 _position) {
        Instantiate(_gm);
    }
};


class Square :  Spawn_gameObjects 
{
    public override void GameObject_spawn(GameObject _gm, Vector3 _position)
    {
        Instantiate(_gm);
        _gm.transform.position = new Vector3(_position.x, _position.y + 1f, _position.z - Random.Range(10, 15));
        _gm.transform.localScale = new Vector3(1f, 1f, 1f);
    }

};

class Wall : Spawn_gameObjects
{
    public override void GameObject_spawn(GameObject _gm, Vector3 _position)
    {
        Instantiate(_gm);
        _gm.transform.position = new Vector3(_position.x, _position.y + 1f, _position.z - Random.Range(10, 15));
        _gm.transform.localScale = new Vector3(3f, 10f, 0.5f);
    }
    
};


public class Spawn_of_object : MonoBehaviour
{
    private GameObject _object;

    private Vector3 tr1;
    private Vector3 tr2;
    private Vector3 tr3;

    // Start is called before the first frame update
    void Start()
    {
        _object = Instantiate(GameObject.Find("_right_line"));
        StartCoroutine(base_corutin());
    }

    private IEnumerator base_corutin()
    {
        Spawn_gameObjects s;
        while (true)
        {
            _ = Random.Range(1, 3) == 1 ? s = new Square() : s = new Wall();

            switch (Random.Range(1, 4))
            {
                case 1:
                    s.GameObject_spawn(_object, tr1 = GameObject.Find("_right_line").transform.position);
                    break;
                case 2:
                    s.GameObject_spawn(_object, tr2 = GameObject.Find("_left_line").transform.position);
                    break;
                case 3:
                    s.GameObject_spawn(_object, tr3 = GameObject.Find("_middle_line").transform.position);
                    break; 
            }
            yield return new WaitForSeconds(5f);
        }
    }
}
