using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour {
	public void OnClick(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	// Use this for initialization
	void Start () {
		Debug.Log("Hello VIP!");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
