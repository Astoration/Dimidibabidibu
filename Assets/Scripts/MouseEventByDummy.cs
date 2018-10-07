using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEventByDummy : MonoBehaviour {
    public Camera camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        foreach(var hit in Physics2D.RaycastAll(ray.origin, ray.direction)){
            hit.collider.gameObject.SendMessage("OnMouseOver", SendMessageOptions.DontRequireReceiver);
            if(Input.GetMouseButtonUp(0)) hit.collider.gameObject.SendMessage("OnMouseUp",SendMessageOptions.DontRequireReceiver);
        }
	}
}
