using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSelected : MonoBehaviour {
    public Text storyIntroduce;
    private void OnEnable()
    {
        GetComponent<SpriteAnimation>().size = 900;
        GetComponent<SpriteAnimation>().Thing = ThingsManager.list[SelectManager.instance.current].image;
        RecordManager.instance.stringSource = ThingsManager.list[SelectManager.instance.current].caption;
        RecordManager.instance.progress.fillAmount = 0;
        storyIntroduce.text = ThingsManager.list[SelectManager.instance.current].description.Replace(@"{0}",ThingsManager.instance.selectedMember.name);
    }
}
