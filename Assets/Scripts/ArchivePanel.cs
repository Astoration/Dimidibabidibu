using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivePanel : MonoBehaviour {
    public static ArchivePanel _instance;
    public static ArchivePanel instance
    {
        get
        {
            if (!_instance) _instance = (ArchivePanel)FindObjectOfType(typeof(ArchivePanel));
            return _instance;
        }
    }
    public Text textBox;
    public Text productTitle;
    public Text title;
    public Text introduce, guide;
    public Image image;
    public GameObject firstCell, cell, addCell,viewport;
    public List<Thing> thingHistories;
    public List<string> audioHistories;
    public UnityEngine.Events.UnityEvent Record;

    public void OnRecord(){
        Record.Invoke();
    }

    public void Init(Member member)
    {
        image.sprite = member.Image;
        textBox.text = member.name;
        introduce.text = member.introduce;
        guide.text = member.name + "를 변신시킨 다양한 마법메시지들 재미있으셨나요? 자, 어때요 준비 되셨나요?";
        productTitle.text = member.title;
        title.text = string.Format("지금까지 {0}에게 남겨진\n"
                                   + "마법 메시지를 재생 해볼까요 ? ", member.name);
        var history = PlayerPrefs.GetString(member.name + "/thing", "");
        var histories = history.Split('#');
        Thing selectedThing = null;
        for (int i = 0; i < viewport.transform.childCount; i++) DestroyImmediate(viewport.transform.GetChild(0).gameObject);
        if (histories != null && 0 < histories.Length && histories[0] != "")
        {
            thingHistories.Clear();
            foreach (var item in histories)
            {

                selectedThing = ThingsManager.instance.SearchByName(item);
                thingHistories.Add(selectedThing);
            }
        }
        var soundHistory = PlayerPrefs.GetString(member.name + "/sound", "");
        var soundHistories = soundHistory.Split('#');
        if (soundHistories != null && 0 < soundHistories.Length && soundHistories[0] != "")
        {
            audioHistories.Clear();
            foreach (var item in soundHistories)
            {
                audioHistories.Add(item);
            }
        }
        int index = 0;
        foreach(Thing thing in thingHistories){
            if(index == 0){
                Instantiate(firstCell, viewport.transform).GetComponent<CellObject>().Init(member,thing,audioHistories[index]);
                index += 1;
            }else{
                Instantiate(cell, viewport.transform).GetComponent<CellObject>().Init(member,thing, audioHistories[index]);
                index += 1;
            }
        }
        viewport.GetComponent<MagneticScrollView.MagneticScrollRect>().ArrangeElements();
    }
}
