using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovable : MonoBehaviour {
    public int direction;
    public Vector3 target;
    public float curve;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var distance = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        if (0.95f < distance)
        {
            direction = 1;
        }
        else if (0.05f > distance)
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }

        if(Vector3.Distance(transform.position,target)<0.05){
            curve = 0.95f;
            target.x += direction * 10;
            target.x = Mathf.Clamp(target.x, -37, 37);
        }else if (Vector3.Distance(transform.position, target) < 1){
            curve = 0.4f;
            target.x += direction * 10;
            target.x = Mathf.Clamp(target.x, -37, 37);
        }
        else
        {
            if (0.4f<curve)
            {
                curve -= Time.deltaTime;
            }
        }
        transform.position = Vector3.Lerp(transform.position,target, (1 - curve)/2f);
    }
}
