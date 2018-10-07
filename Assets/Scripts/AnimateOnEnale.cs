using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateOnEnale : MonoBehaviour {

    private void OnEnable()
    {
        GetComponent<Animator>().Play("SearchInit");
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
