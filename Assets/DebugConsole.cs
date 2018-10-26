using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "";
        Application.logMessageReceived += (condition, stackTrace, type) => {
            if (type == LogType.Log || type == LogType.Warning) return;
            GetComponent<Text>().text = condition+"\n"+stackTrace;

        };

    }
	
	// Update is called once per frame
	void Update () {

	}
}
