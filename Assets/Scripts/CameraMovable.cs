using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovable : MonoBehaviour {
    public static bool enable = true;
    public float direction = 0f;
    public float speed = 3f;
    public float curve;
    public float accel = 1f;
    public float max = 3f;
    float timer = 0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!enable) return;
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
            if(direction < 0){
                direction = Mathf.Clamp(direction += Time.deltaTime, -99, 0);
            }else if(distance > 0){
                direction = Mathf.Clamp(direction -= Time.deltaTime, 0, 99);
            }
            accel = Mathf.Clamp(accel * 0.01f,1f,100);
            max = Mathf.Clamp(max * 0.01f,3f,100);
            timer = 0f;
        }
        var pos = transform.position;
        pos.y = 0;
        accel += Time.deltaTime * 2;
        accel = Mathf.Clamp(accel, 1f, max);
        if(3f<=accel){
            timer += Time.deltaTime;
            if(3f<=timer){
                max = 6f;
            }
        }
        pos.x += direction * Time.deltaTime * speed * accel;
        pos.x = Mathf.Clamp(pos.x, -37f, 37f);
        transform.position = pos;
    }
}
