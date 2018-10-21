using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSelected : MonoBehaviour {
    public Text storyIntroduce;
    private void OnEnable()
    {
        GetComponent<SpriteAnimation>().size = 900;
        GetComponent<SpriteAnimation>().thing = ThingsManager.list[SelectManager.instance.current].image;
        storyIntroduce.text = ThingsManager.list[SelectManager.instance.current].description.Replace(@"{0}",ThingsManager.instance.selectedMember.name);
    }
}
