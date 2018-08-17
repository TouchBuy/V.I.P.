using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_swiipemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody car = GetComponent<Rigidbody>();
        if(OVRInput.Get(OVRInput.Button.Left)){
            //transform.Rotate(0, (float)-0.5, 0);
            car.AddForce(Vector3.forward * 0.1f,ForceMode.Impulse);
        }else if(OVRInput.Get(OVRInput.Button.Right)){
            //transform.Rotate(0, (float)0.5, 0);
            car.AddForce(Vector3.forward * 0.1f, ForceMode.Impulse);
        }
	}
}
