using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagneticScrollView;

public class IndexItem : MonoBehaviour {
    public int index = 0;
    public MagneticScrollRect scroll;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetIndex(){
        scroll.ScrollTo(index);
    }
}
