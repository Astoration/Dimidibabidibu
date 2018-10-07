using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetailPage : MonoBehaviour {
    public Text description, title;
    public Image image;
	// Use this for initialization
    public void SetDetailPage(Thing thing){
        title.text = string.Format("{0}이(가) 되는 마법", thing.name);
        description.text = thing.description;
        image.sprite = thing.Image;
    }
}
