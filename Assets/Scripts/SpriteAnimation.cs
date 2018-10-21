﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimation : MonoBehaviour {
    public bool loopFrame = true;
    public int frame = 0;
    public string thing = "0";
    public int size = 200;
    public float duration = 3f;
    public float framePer{
        get { return duration / sprites.Count; }
    }
    public float time;
    Image image;
    List<Sprite> sprites = new List<Sprite>();

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        int loadFrame = 0;
        while(Resources.Load<Sprite>("things/"+ thing +"/"+size+"/"+loadFrame.ToString("D5"))!=null){
            Sprite i = Resources.Load<Sprite>("things/" + thing + "/" + size + "/" + loadFrame.ToString("D5"));
            sprites.Add(i);
            loadFrame += 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(time<framePer){
            time += Time.deltaTime;
            return;
        }
        image.sprite = sprites[frame];
        frame += (int)Mathf.Floor(time / framePer);
        time -= Mathf.Floor(time / framePer) * framePer;
        if (sprites.Count<=frame){
            frame = 0;
        }
	}
}
