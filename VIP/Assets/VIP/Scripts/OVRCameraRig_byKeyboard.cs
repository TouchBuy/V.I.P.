using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRCameraRig_byKeyboard : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<OVRCameraRig>().transform.Rotate(GetComponent<OVRCameraRig>().transform.right, -1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<OVRCameraRig>().transform.Rotate(GetComponent<OVRCameraRig>().transform.right, 1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<OVRCameraRig>().transform.Rotate(GetComponent<OVRCameraRig>().transform.up, -1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<OVRCameraRig>().transform.Rotate(GetComponent<OVRCameraRig>().transform.up, 1f);
        }
    }
}
