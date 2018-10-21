using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour {
    public Member member;
    public float time = 0f;
    public bool enable;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(enable){
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 1.6f, Time.deltaTime);
        }else{
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 1f, Time.deltaTime);
            time = 0f;
        }
        if(3f<time){
            Open();
            time = 0f;
        }
    }

    public void OnEnter(){
        enable = true;
    }

    public void OnExit(){
        enable = false;
    }

    public void Open(){
        ThingsManager.instance.OpenByName(member.name);
    }
}
