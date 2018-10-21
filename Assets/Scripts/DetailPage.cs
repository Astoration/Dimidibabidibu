using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DetailPage : MonoBehaviour {
    public Text description, title;
    public Image image;
	// Use this for initialization
    public void SetDetailPage(Thing thing){
        title.text = string.Format("{0}이(가) 되는 마법", thing.name);
        image.GetComponent<SpriteAnimation>().thing = thing.image;
        image.GetComponent<SpriteAnimation>().size = 900;
        description.text = thing.description;
    }

    static public GameObject GameObjectHardFind(string str)
    {
        GameObject result = null;
        foreach (GameObject root in GameObject.FindObjectsOfType(typeof(Transform)))
        {
            if (root.transform.parent == null)
            { // means it's a root GO
                result = GameObjectHardFind(root, str, 0);
                if (result != null) break;
            }
        }
        return result;
    }
    static public GameObject GameObjectHardFind(string str, string tag)
    {
        GameObject result = null;
        foreach (GameObject parent in GameObject.FindGameObjectsWithTag(tag))
        {
            result = GameObjectHardFind(parent, str, 0);
            if (result != null) break;
        }
        return result;
    }
    static private GameObject GameObjectHardFind(GameObject item, string str, int index)
    {
        if (index == 0 && item.name == str) return item;
        if (index < item.transform.childCount)
        {
            GameObject result = GameObjectHardFind(item.transform.GetChild(index).gameObject, str, 0);
            if (result == null)
            {
                return GameObjectHardFind(item, str, ++index);
            }
            else
            {
                return result;
            }
        }
        return null;
    }

    public void OnNext(){
        SelectManager.instance.OnNext();
    }
}
