using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSelected : MonoBehaviour {

    private void OnEnable()
    {
        GetComponent<SpriteAnimation>().size = 900;
        GetComponent<SpriteAnimation>().thing = ThingsManager.list[SelectManager.instance.current].image;
    }
}
