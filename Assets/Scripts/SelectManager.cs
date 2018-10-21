using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagneticScrollView;

public class SelectManager : MonoBehaviour {
    public GameObject viewport, indexList;
    public GameObject contentItem, indexItem;
    public GameObject indexDot;
    public RectTransform currentObject, preObject;
    public List<GameObject> indexObjects = new List<GameObject>();
    public int current = 0;
    public UnityEngine.Events.UnityEvent events;
    public static SelectManager _instance;
    public static SelectManager instance
    {
        get
        {
            if (!_instance) _instance = (SelectManager)FindObjectOfType(typeof(SelectManager));
            return _instance;
        }
    }
    private void Awake()
    {
        Debug.Log(ThingsManager.list);
        int count = 0;
        foreach (var thing in ThingsManager.list){
            var content = Instantiate(contentItem, viewport.transform).GetComponent<DetailPage>();
            content.SetDetailPage(thing);
            var index = Instantiate(indexItem, indexList.transform);
            index.GetComponent<ThingObject>().SetThing(thing, true,true);
            index.GetComponent<IndexItem>().index = count++;
            index.GetComponent<IndexItem>().scroll = GetComponent<MagneticScrollRect>();
            indexObjects.Add(index);
        }
        var pos = indexDot.GetComponent<RectTransform>().anchoredPosition;
        pos.x = Camera.allCameras[1].WorldToScreenPoint(indexObjects[current].GetComponent<RectTransform>().position).x;
        indexDot.GetComponent<RectTransform>().anchoredPosition = pos;
        currentObject = indexObjects[current].GetComponent<ThingObject>().image.rectTransform;
    }

    public void OnNext()
    {
        events.Invoke();
    }

    public void SetCurrent(GameObject index){
        current = GetComponent<MagneticScrollRect>().CurrentSelectedIndex;
        preObject = currentObject;
        currentObject = indexObjects[current].GetComponent<ThingObject>().image.rectTransform;
    }

    // Update is called once per frame
    void Update () {
        var pos = indexDot.GetComponent<RectTransform>().anchoredPosition;
        pos.x = Camera.allCameras[1].WorldToScreenPoint(indexObjects[current].GetComponent<RectTransform>().position).x;
        indexDot.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(indexDot.GetComponent<RectTransform>().anchoredPosition, pos, 0.1f);
        currentObject.localScale = Vector3.Lerp(currentObject.localScale, Vector3.one * 0.7477477f * 1.5f, 0.1f);
        if (preObject)
            preObject.localScale = Vector3.Lerp(preObject.localScale, Vector3.one * 0.7477477f, 0.1f);

    }
}
