using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour {
    public Camera target;
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.ScreenToWorldPoint(Input.mousePosition);
        transform.Translate(Vector3.forward);
	}
}
