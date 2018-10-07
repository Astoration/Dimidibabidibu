using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThingObject : MonoBehaviour {
    public Image image;
    public Text objectName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetThing(Thing thing,Member member){
        image.sprite = thing.Image;
        objectName.text = thing.name + "으로 변한 <color=\"#f8e71c\">" + member.name + "</color>" ;
    }

    public void SetThing(Thing thing)
    {
        image.sprite = thing.Image;
        objectName.text = thing.name;
    }
}
