using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class view_swiipemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.Get(OVRInput.Button.Left)){
            transform.Rotate(0, (float)-0.5, 0);
        }else if(OVRInput.Get(OVRInput.Button.Right)){
            transform.Rotate(0, (float)0.5, 0);
        }
	}
}
