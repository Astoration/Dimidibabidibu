using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CellObject : MonoBehaviour {
    public Image image;
    public Text title;

    public void Record(){
        ArchivePanel.instance.OnRecord();
    }

    public void Init(Thing thing,string clip)
    {
        image.sprite = thing.Image;
        title.text = thing.name + " 마법으로 변한";
        StartCoroutine(LoadWave(clip));
    }

    public IEnumerator LoadWave(string clip)
    {
        var path = "file://" + Application.persistentDataPath + "/" + clip;
        Debug.Log(path);
        WWW www = new WWW(path);
        yield return www;
        var clipData = www.GetAudioClip(true, true);
        GetComponent<AudioSource>().clip = clipData;
    }

    public void OnEnter()
    {
        GetComponent<AudioSource>().Play(); 
    }

    public void OnExit()
    {
        GetComponent<AudioSource>().Stop();
    }
}
