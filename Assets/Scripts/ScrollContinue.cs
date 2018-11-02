using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagneticScrollView;

public class ScrollContinue : MonoBehaviour
{
    public MagneticScrollRect scroll;
    public float time = 0f;
    public bool tickOn = false;
    public bool isLeft = true;
    public bool enable = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(enable){
            TickScroll();
        }
    }

    public void EnableTick(){
        enable = true;
    }

    public void TickScroll() 
    {
        time += Time.deltaTime;
        if(tickOn&&0.3f<time){
            time = 0f;
            Scroll();
        }
        if(2f<time&&!tickOn){
            Scroll();
            tickOn = true;
            time = 0f;
        }
    }

    public void Scroll(){
        if (isLeft)
        {
            scroll.ScrollBack();
        }
        else
        {
            scroll.ScrollForward();
        }
    }

    public void ResetTime(){
        time = 0f;
        enable = false;
        tickOn = false;
    }
}
