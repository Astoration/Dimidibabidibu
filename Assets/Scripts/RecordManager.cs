using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour {
    public static RecordManager _instance;
    public static RecordManager instance
    {
        get
        {
            if (!_instance) _instance = (RecordManager)FindObjectOfType(typeof(RecordManager));
            return _instance;
        }
    }
    public Image progress;
    public AudioSource source;
    private bool isPlaying;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if(source.isPlaying)
            progress.fillAmount = source.time / 15f;
    }

    public void Record(){
        isPlaying = true;
        source.clip = Microphone.Start(null, false, 15, 16600);
        source.volume = 0;
        source.Play();
    }

    public void Stop(){
        isPlaying = false;
        Microphone.End(null);
        source.Stop();
    }

    public void Play(){
        if (isPlaying) return;
        source.volume = 1;
        source.Play();
    }
}
