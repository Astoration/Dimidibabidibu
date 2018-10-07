using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimation : MonoBehaviour {
    public float time = 0f;
    public float seed = 0f;
	// Use this for initialization
	void Start () {
        seed = Random.RandomRange(0f, 2f);
        time += seed;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        var velocity = Vector2.up * Time.deltaTime;
        velocity += Vector2.left * Mathf.Sin(time*5) * (0.3f+seed) * Time.deltaTime;
        transform.Translate(velocity);
	}

    // OnBecameInvisible은 어느 카메라에서든 렌더러가 더 이상 표시되지 않는 경우 호출됩니다.
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
