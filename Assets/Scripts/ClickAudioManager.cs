using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAudioManager : MonoBehaviour {
    public string name;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseUp()
    {
        Debug.Log("down");
        StartCoroutine(PlayWav());
    }

    public IEnumerator PlayWav(){
        var path = "file://" + Application.persistentDataPath + "/" + name;
        Debug.Log(path);
        WWW www = new WWW(path);
        yield return www;
        var clip = www.GetAudioClip(true, true);
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
