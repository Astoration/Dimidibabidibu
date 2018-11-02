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
    public Text progressCount;
    public string stringSource;
    public AudioSource source;
    private bool isPlaying;
    public AudioSource bgmSource;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}

    private void Update()
    {
        progressCount.text = string.Format(stringSource, (int)Mathf.Floor(15f - source.time));
        if (source.isPlaying)
        {
            progress.fillAmount = source.time / 15f;
        }
    }

    IEnumerator FadeOut()
    {
        for (int i = 0; i < 90; i++)
        {
            bgmSource.volume = Mathf.Lerp(bgmSource.volume, 0.001f, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator FadeIn(){

        for (int i = 0; i < 90; i++)
        {
            bgmSource.volume = Mathf.Lerp(bgmSource.volume, 0.1f, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void Record(){
        StartCoroutine(FadeOut());
        isPlaying = true;
        source.clip = Microphone.Start(null, false, 15, 16600);
        source.volume = 0;
        source.Play();
    }

    public void Stop(){
        StartCoroutine(FadeIn());
        isPlaying = false;
        Microphone.End(null);
        source.Stop();
    }

    public void Play(){
        if (isPlaying) return;
        StartCoroutine(FadeOut());
        source.volume = 1;
        Invoke("Reset", 15f);
        source.Play();
    }

    public void Reset()
    {
        StartCoroutine(FadeIn());

    }
}
