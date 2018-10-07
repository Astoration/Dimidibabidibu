using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    [SerializeField]
    public enum SceneMode{
        Archive,
        Name,
        Record
    }
    public SceneMode mode = SceneMode.Archive;
    public GameObject archiveCell;
    public List<GameObject> cells = new List<GameObject>();
    public Transform origin;
    AudioClip audio;
	// Use this for initialization
	void Start () {
        InitArchive();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InitArchive(){
        //var path = PlayerPrefs.GetString("path", "");
        //RemoveArchive();
        //if(!path.Equals("")){
        //    var list = path.Split('#');
        //    var i = 0;
        //    foreach(var item in list){
        //        var cell = Instantiate(archiveCell,origin.position,Quaternion.identity);
        //        cells.Add(cell);
        //        cell.transform.Translate(Vector2.right * (i % 4) + Vector2.down * (1 / 4));
        //        cell.GetComponent<ClickAudioManager>().name = item;
        //        i += 1;
        //    }
        //}
    }

    public void RemoveArchive(){
        foreach (var cell in cells)
        {
            Destroy(cell);
        }
    }

    public void SetMode(string sceneMode)
    {
        mode = (SceneManager.SceneMode)Enum.Parse(typeof(SceneMode), sceneMode);
    }
    public void SetMode(SceneMode sceneMode){
        mode = sceneMode;
    }

    public void Record(){
        audio = Microphone.Start(null, true, 10, 44100);
    }

    public void StopRecord(){
        Microphone.End(null);
        var date = DateTime.Now.ToString();
        SavWav.Save(date, audio);
        var path = PlayerPrefs.GetString("path", "");
        if(!path.Equals("")){
            path += "#";
        }
        path += date+".wav";
        PlayerPrefs.SetString("path",path);
    }
}
