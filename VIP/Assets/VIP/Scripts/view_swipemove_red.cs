using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_swipemove_red : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0);
    }
}
