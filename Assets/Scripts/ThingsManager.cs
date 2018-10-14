using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using LitJson;

[System.Serializable]
public class Member{
    public static Dictionary<string, Sprite> memberDict = new Dictionary<string, Sprite>();
    public string name;
    public string subname;
    public string introduce;
    public string profile;
    public Sprite Image{
        get{
            if (memberDict.ContainsKey(profile))
            {
                return memberDict[profile];
            }
            else
            {
                var sprite = Resources.Load<Sprite>("members/" + profile);
                memberDict.Add(profile, sprite);
                return sprite;
            }
        }
    }
}

[System.Serializable]
public class Thing
{
    public static Dictionary<string, Sprite> thingDict = new Dictionary<string, Sprite>();
    public string name;
    public string category;
    public string description;
    public string image;
    public Sprite Thumb
    {
        get
        {
            var path = "things/200/" + image;
            if (thingDict.ContainsKey(path))
            {
                return thingDict[path];
            }
            else
            {
                var sprite = Resources.Load<Sprite>(path);
                thingDict.Add(path, sprite);
                return sprite;
            }
        }
    }
    public Sprite Image
    {
        get
        {
			var path = "things/900/" + image;
            if (thingDict.ContainsKey(path))
            {
                return thingDict[path];
            }
            else
            {
                var sprite = Resources.Load<Sprite>(path);
                thingDict.Add(path, sprite);
                return sprite;
            }
        }
    }
}

public class ThingsManager : MonoBehaviour {
    public static ThingsManager _instance;
    public static ThingsManager instance{
        get{
            if (!_instance) _instance = (ThingsManager)FindObjectOfType(typeof(ThingsManager));
            return _instance;
        }
    }
    public GameObject thing;
    List<GameObject> things = new List<GameObject>();
    public TextAsset thingData;
    public TextAsset memberData;
    public static List<Thing> list = new List<Thing>();
    public static List<Member> members = new List<Member>();
    public GameObject ArchivePage;
    public UnityEvent OnZoom;
    int index = 0;
    int amount = 0;

    public void Awake()
    {
        var result = JsonMapper.ToObject<List<Thing>>(thingData.text);
        var memberResult = JsonMapper.ToObject<List<Member>>(memberData.text);
        members.AddRange(memberResult);
        list.AddRange(result);
        amount = members.Count;
        InitList();
    }

    public void InitList(){
        index = 0;
        foreach (var i in things) DestroyImmediate(i);
        things.Clear();
        for (int i = 0; i < 3; i ++){
            int count = amount / 3;
            var type = i % 2 == 1;
            if (type) count += amount % 3;
            InitLine(i,count);
        }
    }

    public void OpenByName(string name){
        GameObject item = null;
        foreach(var i in things){
            if(i.GetComponent<ThingObject>().member.name==name){
                Debug.Log(name);
                item = i;
            }
        }
        if (item == null) return;
        StartCoroutine(ZoomItem(item));
    }

    public void LockByName(string name){
        GameObject item = null;
        foreach (var i in things)
        {
            if (i.GetComponent<ThingObject>().member.name == name)
            {
                Debug.Log(name);
                item = i;
            }
        }
        if (item == null) return;
        Camera.main.transform.position = item.transform.position;
        Camera.main.GetComponent<Camera>().orthographicSize = 1f;
        CameraMovable.enable = false;
    }

    public void ResetCamera(){
        Camera.main.GetComponent<Camera>().orthographicSize = 5f;
        CameraMovable.enable = true;
    }

    IEnumerator ZoomItem(GameObject item){
        CameraMovable.enable = false;
        while(Vector2.Distance(Camera.main.transform.position,item.transform.position)>0.01f){
            Camera.main.transform.position = Vector2.Lerp(Camera.main.transform.position, item.transform.position, 0.1f);
            yield return new WaitForEndOfFrame();
        }
        while(1<Camera.main.GetComponent<Camera>().orthographicSize){
            Camera.main.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Camera.main.GetComponent<Camera>().orthographicSize, 0.8f, 0.1f);
            yield return new WaitForEndOfFrame();
        }
        ArchivePage.SetActive(true);
        ArchivePage.GetComponent<ArchivePanel>().Init(item.GetComponent<ThingObject>().member);
        Camera.main.GetComponent<Camera>().orthographicSize = 5f;
        CameraMovable.enable = true;
        OnZoom.Invoke();
    }

    public void InitLine(int line, int count){
        float offset = line % 2 == 0 ? 0 : 0.5f;
        var start = (amount / 3f)/2f * -1;
        for (int i = 0; i < count;i++){
            Vector3 pos = new Vector3();
            index = i * 3 + line;
            Member member = members[index];
            pos.x = (start + i + offset)*3;
            pos.y = (line - 1)*2;
            var item = Instantiate(thing,transform);
            var history = PlayerPrefs.GetString(member.name + "/thing", "");
            var histories = history.Split('#');
            Thing selectedThing = null;
            if (histories != null && 0 < histories.Length && histories[0] != "")
            {
                selectedThing = SearchByName(histories[0]);
            }
            else
            {
                selectedThing = list[Random.Range(0, list.Count)];
            }
            item.GetComponent<ThingObject>().SetThing(selectedThing,member);
            item.transform.localPosition = pos;
            things.Add(item);
        }

    }

    public Thing SearchByName(string name){
        foreach(var thing in list){
            if (thing.name == name) return thing;
        }
        return null;
    }
}