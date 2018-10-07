using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverToStart : MonoBehaviour {
    public Animator animator;
    bool active = false;
    // Start는 Update 메서드가 처음으로 호출되기 바로 전에 호출됩니다.
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void OnMouseOver()
    {
        if (active) return;
        animator.SetTrigger("Start");
        active = true;
    }

}
