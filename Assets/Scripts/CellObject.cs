using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CellObject : MonoBehaviour {
    public Image image;
    public Text title;
    public Image progress;
    public Text timeStamp;
    AudioSource source;
    public Text currentTime, afterTime;
    AudioSource bgmSource;
    public Text description;

    public void Record(){
        ArchivePanel.instance.OnRecord();
    }

    IEnumerator FadeOut()
    {
        for (int i = 0; i < 90; i++)
        {
            bgmSource.volume = Mathf.Lerp(bgmSource.volume, 0.001f, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeIn()
    {

        for (int i = 0; i < 90; i++)
        {
            bgmSource.volume = Mathf.Lerp(bgmSource.volume, 0.1f, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void Init(Member member,Thing thing, string clip)
    {
        bgmSource = Camera.main.gameObject.GetComponent<AudioSource>();
        image.GetComponent<SpriteAnimation>().Thing = thing.image;
        image.GetComponent<SpriteAnimation>().size = 900;
        title.text = string.Format("{0}는 '{1}'로 변해있습니다.", member.name, thing.name);
        description.text = string.Format("{0}를 변하게한\n"
                                            +"마법 메시지 들어보기", member.name);
        StartCoroutine(LoadWave(clip));
        var dataString = clip.Replace(".wav", "");
        var date = DateTime.Parse(dataString);
        var timeDiff =  DateTime.Now.Ticks - date.Ticks;
        var minutes = timeDiff / (60 * 1000 * 10000);
        var hour = timeDiff / (60 * 1000 * 10000) / 60;
        var day = timeDiff / (60 * 1000 * 10000) / 60 / 24;
        string result = "";
        if(0<day){
            if(day==1){
                result = "어제";
            }else{
                result = "그저께";
            }
        }else if(0<hour){
            result = string.Format("{0}시간 전", hour);
        }else if(1<minutes){
            result = string.Format("{0}분 전", minutes);
        }else{
            result = "지금";
        }
        timeStamp.text = result;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (source.clip == null) return;
        progress.fillAmount = source.time / source.clip.length;
        currentTime.text = string.Format("00:{0}", ((int)Mathf.Floor(source.time)).ToString("D2"));
        afterTime.text = string.Format("00:{0}",((int)Mathf.Floor(source.clip.length-source.time)).ToString("D2"));
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
        if (source.isPlaying) return;
        StartCoroutine(FadeOut());
        Invoke("OnExit", 15f);
        GetComponent<AudioSource>().Play(); 
    }

    public void OnExit()
    {
        StartCoroutine(FadeIn());
        GetComponent<AudioSource>().Stop();
    }
}
