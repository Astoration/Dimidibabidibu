using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
    public GameObject[] list;

	// Use this for initialization
	void Start () {
        InvokeRepeating("spawn", 0.3f, 0.3f);
	}

    public void spawn(){
        var item = list[Random.RandomRange(0, list.Length)];
        var go = Instantiate(item, transform.position, Quaternion.identity);
        go.transform.Translate(Vector3.left * Random.RandomRange(-4f, 4f));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
