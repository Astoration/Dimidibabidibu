using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoController : MonoBehaviour {
    public VideoClip[] clips;
    public VideoPlayer player;

	// Use this for initialization
	void Start () {
        player.loopPointReached += OnEnd;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        player.clip = clips[SelectManager.instance.current];
        gameObject.SetActive(true);
        player.Play();
    }

    public void OnEnd(VideoPlayer source)
    {
        gameObject.SetActive(false);
    }
}
