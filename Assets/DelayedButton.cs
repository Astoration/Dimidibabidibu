using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DelayedButton : MonoBehaviour {
    public bool enabled = false;
    public float time = 0f;
    public float delay = 1f;
    public UnityEvent action;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(enabled){
            time += Time.deltaTime;
        }else{
            time = 0f;
        }
        if(delay<time){
            time = 0f;
            action.Invoke();
        }
    }

    public void OnButtonEnter(){
        enabled = true;
    }

    public void OnButtonExit()
    {
        enabled = false;
    }
}
