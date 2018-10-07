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

    public void SetThing(Thing thing,Member member,bool useThumb = true, bool useCategory = false){
        image.sprite =useThumb?thing.Thumb:thing.Image;
        objectName.text = useCategory?thing.category:thing.name + "으로 변한 <color=\"#f8e71c\">" + member.name + "</color>" ;
    }

    public void SetThing(Thing thing,bool useThumb = true,bool useCategory = false)
    {
        image.sprite = useThumb ? thing.Thumb : thing.Image;
        objectName.text = useCategory ? thing.category : thing.name;
    }
}
