using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivePanel : MonoBehaviour {
    public Text textBox;
    public Text title;

    public void Init(Member member)
    {
        textBox.text = string.Format("안녕하세요, {0}입니다.",member.name);
        title.text = string.Format("지금까지 {0}에게 남겨진\n"
                                   + "마법 메시지를 재생 해볼까요 ? ", member.name);
    }
}
