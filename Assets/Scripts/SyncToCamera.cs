using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncToCamera : MonoBehaviour {
    public float ratio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Camera.main.transform.position.x;
        var pos = GetComponent<RectTransform>().anchoredPosition;
        pos.x = x * ratio;
        GetComponent<RectTransform>().anchoredPosition = pos;
	}
}
