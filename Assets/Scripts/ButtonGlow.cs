using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonGlow : MonoBehaviour {
    public bool runIdemmiate = false;

    bool buttonActive = false;

    public UnityEvent action;

    public Image sprite;

    public void Update()
    {
        Color color = sprite.color;
        Color newColor;
        if(buttonActive){
            newColor = Color.Lerp(color, Color.white, Time.deltaTime);
        }else{
            newColor = Color.Lerp(color, Color.clear, Time.deltaTime);
        }
        if (0.9<newColor.a&&buttonActive&&!runIdemmiate)
        {
            action.Invoke();
            buttonActive = false;
            newColor = Color.clear;
        }
        sprite.color = newColor;
    }

    public void OnTouchEnter(){
        buttonActive = true;
    }

    public void OnTouchExit(){
        buttonActive = false;
    }
}
