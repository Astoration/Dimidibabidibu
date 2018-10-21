using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRotator : MonoBehaviour {

    string first = "<color=\"#{0}\">디미디바비디부</color>에 오신걸 환영합니다.";

    string[] list = {
        "전시자들이 모두 <color=\"#{0}\">마법 방명록</color> 때문에\n마법에 걸려 사물로 변해있어요!",
        "마법봉을 변한 사물에 가져가 대면,\n각 전시자에게 남겨진 마법 방명록을 들을 수 있어요!",
        "어떻게 변했나 한번 살펴볼까요?\n 화면 <color=\"#{0}\">좌우의 버튼</color>을 이용해보세요!",
        "전시자들은 가나다 순으로\n 줄지어 있답니다!",
        "찾고있는 특정 전시자가 있나요?\n화면 오른쪽 아래의 <color=\"#{0}\">음성 검색</color>을 이용해보세요!",
        "찾고있는 특정 전시자가 없다면,\n<color=\"#{0}\">디미디</color>를 찾아보세요!",
        "<color=\"#{0}\">디미디 모두</color>에게 남긴 \n방명록을 들어볼 수 있어요"
    };
    int index = -1;

    Color highlightColor = new Color(248f/255f, 231f/255f, 28/255f);
    Color currentColor;
    //<color=\"{0}\">
    Text text;
    private float cooldown;

    private void OnEnable()
    {
        text = GetComponent<Text>();
        currentColor = highlightColor;
        text.text = string.Format(first, currentColor);
        index = -1;
        cooldown = 3f;
    }

    // Update is called once per frame
    void Update () {
        cooldown -= Time.deltaTime;
        var color = text.color;
        if (0f > cooldown){
            currentColor.a -= Time.deltaTime;
            color.a -= Time.deltaTime;
        }
        text.color = color;
        if(index<0){
            text.text = string.Format(first, ColorUtility.ToHtmlStringRGBA(currentColor));
        }else{
            text.text = string.Format(list[index], ColorUtility.ToHtmlStringRGBA(currentColor));
        }
        if(System.Math.Abs(currentColor.a - Color.clear.a) < 0.1f)
        {
            index += 1;
            currentColor = highlightColor;
            text.color = Color.white;
            cooldown = 3f;
            if(list.Length<=index){
                index = 0;
            }
        }
    }
}
