using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_swiipemove : MonoBehaviour {

    public float torque;
    public Rigidbody car;
    public bool debug;

	// Use this for initialization
	void Start () {
        car = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.Get(OVRInput.Button.Left) || Input.GetKey(KeyCode.LeftCommand)){
            car.AddTorque(0, -5, 0, ForceMode.Impulse);
        }else if(OVRInput.Get(OVRInput.Button.Right) || Input.GetKey(KeyCode.RightCommand)){
            car.AddTorque(0, 5, 0, ForceMode.Impulse);
        }
	}
}
