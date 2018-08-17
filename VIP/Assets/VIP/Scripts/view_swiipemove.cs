using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_swiipemove : MonoBehaviour {

    public float torque;
    public Rigidbody car;

	// Use this for initialization
	void Start () {
        car = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.Get(OVRInput.Button.Left)){
            car.AddTorque(10000, 10000, 10000);
        }else if(OVRInput.Get(OVRInput.Button.Right)){
            car.AddTorque(-10000, -10000, -10000);
        }
	}
}
