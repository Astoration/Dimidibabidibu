using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOnlyAfter : MonoBehaviour {
    Camera camera;
	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	private void OnPreRender()
	{
        camera.Render();
	}
}
