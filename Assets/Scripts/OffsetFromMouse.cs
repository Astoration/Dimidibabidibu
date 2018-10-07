using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetFromMouse : MonoBehaviour {
    public float offset = 0f;
	void Start () {
		
	}
	
	void Update () {
        transform.localPosition = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - new Vector3(0.5f, 0.5f)) * offset;
	}
}
