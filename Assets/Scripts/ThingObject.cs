using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThingObject : MonoBehaviour {
    public Thing thing;
    public Member member;
    public Image image;
    public Text objectName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetThing(Thing thing, Member member, bool useCategory = false)
    {
        this.thing = thing;
        this.member = member;
        image.GetComponent<SpriteAnimation>().thing = thing.image;
        objectName.text = useCategory?thing.category:thing.name + "으로 변한 <color=\"#f8e71c\">" + member.name + "</color>" ;
    }

    public void SetThing(Thing thing, bool useCategory = false,bool useStatic = false)
    {
        this.thing = thing;
        if (useStatic)
        {
            image.sprite = Resources.Load<Sprite>("things/" + thing.image + "/200/00000");
        }
        else
        {
            image.GetComponent<SpriteAnimation>().thing = thing.image;
        }
        objectName.text = useCategory ? thing.category : thing.name;
    }
}
