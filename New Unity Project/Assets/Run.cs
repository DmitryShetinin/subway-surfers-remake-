using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 location;
    void Start()
    {
        location = this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(location.x + 1, location.y, location.z);
    }
}
