using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MagneticScrollView;

public class SelectManager : MonoBehaviour {
    public GameObject viewport, indexList;
    public GameObject contentItem, indexItem;
    public GameObject indexDot;
    public List<GameObject> indexObjects = new List<GameObject>();
    public int current = 0;

    private void Awake()
    {
        Debug.Log(ThingsManager.list);

        foreach (var thing in ThingsManager.list){
            var content = Instantiate(contentItem, viewport.transform).GetComponent<DetailPage>();
            content.SetDetailPage(thing);
            var index = Instantiate(indexItem, indexList.transform);
            index.GetComponent<ThingObject>().SetThing(thing, true, true);
            indexObjects.Add(index);
        }
        var pos = indexDot.GetComponent<RectTransform>().anchoredPosition;
        pos.x = Camera.allCameras[1].WorldToScreenPoint(indexObjects[current].GetComponent<RectTransform>().position).x;
        indexDot.GetComponent<RectTransform>().anchoredPosition = pos;
    }

    public void SetCurrent(GameObject index){
        current = GetComponent<MagneticScrollRect>().CurrentSelectedIndex;
    }
	
	// Update is called once per frame
	void Update () {
        var pos = indexDot.GetComponent<RectTransform>().anchoredPosition;
        pos.x = Camera.allCameras[1].WorldToScreenPoint(indexObjects[current].GetComponent<RectTransform>().position).x;
        indexDot.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(indexDot.GetComponent<RectTransform>().anchoredPosition, pos, 0.1f);
	}
}
