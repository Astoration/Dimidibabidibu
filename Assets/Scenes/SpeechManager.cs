using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;

public class SpeechManager : MonoBehaviour {
    GCSpeechRecognition speechRecognition;
    public GameObject guide, result;
    public Text resultText;
	// Use this for initialization
	void Start () {
        speechRecognition = GCSpeechRecognition.Instance;
        speechRecognition.RecognitionSuccessEvent += OnSuccess;
	}

    public void OnSuccess(RecognitionResponse response, long index){
        Debug.Log("3");
        if (response != null && response.results.Length > 0)
        {
            var text = response.results[0].alternatives[0].transcript;
            resultText.text = "<color=\"#F8E71C\">" + text + "</color>가 맞나요?";
            result.SetActive(true);
            guide.SetActive(false);
        }
    }

    public void Retry(){
        result.SetActive(false);
        guide.SetActive(true);
        OnStart();
    }
	
    public void OnStart(){
        Debug.Log("1");
        speechRecognition.StartRecord(false);
        Invoke("OnStop", 3f);
    }

    public void OnStop(){
        Debug.Log("2");
        speechRecognition.StopRecord();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
