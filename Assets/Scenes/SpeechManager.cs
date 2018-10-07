using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FrostweepGames.Plugins.GoogleCloud.SpeechRecognition;
using System;

public class SpeechManager : MonoBehaviour {
    GCSpeechRecognition speechRecognition;
    public GameObject guide, result;
    public GameObject searchPanel;
    public Text resultText;
    public string selectedMember;
    bool isCommandMode = false;
    public GameObject finalPanel, FailedResult;
	// Use this for initialization
	void Start () {
        speechRecognition = GCSpeechRecognition.Instance;
        speechRecognition.RecognitionSuccessEvent += OnSuccess;
        speechRecognition.NetworkRequestFailedEvent += OnFailed;
        speechRecognition.RecordFailedEvent += OnFailed;
	}


    private void OnFailed(string s,long n){
        OnFailed();
    }


    private void OnFailed()
    {
        Debug.Log("4");
        if (isCommandMode){
            finalPanel.GetComponentInChildren<Text>().text = "마음을 가다듬고 <color=\"#f8e71c\">다시한번</color> 시도해주세요!";
            finalPanel.GetComponent<Animator>().Play("ReInitFinal");
            StartCommand();
        }
        else{
            guide.SetActive(false);
            FailedResult.SetActive(true);
        }
    }

    public void OnSuccess(RecognitionResponse response, long index){
        Debug.Log("3");
        if (response != null && response.results.Length > 0)
        {
            var text = response.results[0].alternatives[0].transcript;
            if(isCommandMode){
                if(text == "디미디바비디부"||text== "비비디바비디부")
                {
                    finalPanel.SetActive(false);
                    isCommandMode = false;
                    ThingsManager.instance.ResetCamera();
                }else{
                    finalPanel.GetComponentInChildren<Text>().text = "마음을 가다듬고 <color=\"#f8e71c\">다시한번</color> 시도해주세요!";
                    finalPanel.GetComponent<Animator>().Play("ReInitFinal");
                    StartCommand();
                }
                return;
            }
            var contain = false;
            foreach(var member in ThingsManager.members){
                if (member.name == text) contain = true;
            }
            if(!contain){
                OnFailed();
                return;
            }
            resultText.text = "<color=\"#F8E71C\">" + text + "</color>가 맞나요?";
            selectedMember = text;
            result.SetActive(true);
            guide.SetActive(false);
        }else{
            OnFailed();
        }
    }

    public void Retry(){
        result.SetActive(false);
        guide.SetActive(true);
        OnStart();
    }

    public void Confirm(){
        searchPanel.SetActive(false);
        ThingsManager.instance.OpenByName(selectedMember);
    }
    public void StartCommand(){
        isCommandMode = true;
        ThingsManager.instance.LockByName(selectedMember);
        OnStart();
    }
    public void OnStart(){
        Debug.Log("1");
        speechRecognition.StartRecord(false);
        Invoke("OnStop", 5f);
    }

    public void OnStop(){
        Debug.Log("2");
        speechRecognition.StopRecord();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
