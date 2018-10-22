using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CellObject : MonoBehaviour {
    public Image image;
    public Text title;
    public Image progress;
    AudioSource source;

    public void Record(){
        ArchivePanel.instance.OnRecord();
    }

    public void Init(Member member,Thing thing, string clip)
    {
        image.GetComponent<SpriteAnimation>().thing = thing.image;
        image.GetComponent<SpriteAnimation>().size = 900;
        title.text = string.Format("{0}는 '{1}'로 변해있습니다.", member.name, thing.name);
        StartCoroutine(LoadWave(clip));
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        progress.fillAmount = source.time / source.clip.length;
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
