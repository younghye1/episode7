using UnityEngine;
using CustomInspector;
using System.Runtime.CompilerServices;

public class InspectorTutorial : MonoBehaviour
{
    [Title("인스펙터 꾸미기", fontSize = 25, alignment = TextAlignment.Center)]
    [HorizontalLine("세부 속성"), HideField] public bool _l0;
    public int TestNum1;
    [Range(0, 5)] public int TestNum2;
    [Range(0.0f, 10.0f)] public float testNum3;

    [RichText(true)]
    public string TestString = "한글입력";

    [Multiline(lines: 5)]
    public string TestString2 = "글자 줄 수 제한된 만큼만 입력창 커짐";

    [TextArea(minLines: 2, maxLines: 10)]
    public string TestString3 = "줄 많으면 스크롤바 생김";

    [Space(20), HorizontalLine(color: FixedColor.Yellow), HideField] public bool _l2;

    [Space(20), ReadOnly(DisableStyle.OnlyText)] public string testReadOnly = "리드온리 테스트";

    [Space(15), HorizontalLine(color: FixedColor.CherryRed), HideField] public bool _l4;
    [Preview(Size.big)] public Sprite sprite; //이미지 미리보기

    [Space(30), Button("Method", size = Size.big), HideField] public bool _b0;
    void Method()
    {
        Debug.Log("big 사이즈 버튼");
    }


    [Button("Method2", size = Size.medium), HideField] public bool _b3;
    void Method2()
    {
        Debug.Log("medium 사이즈 버튼");
    }

    [Button("Method2", size = Size.small), HideField] public bool _b5;
    [Space(20), HideField] public bool _b1;
    void Method3()
    {
        Debug.Log("small 사이즈 버튼");
    }
    [Button("Method2", size = Size.max), HideField] public bool _b6;
    void Method4()
    {
        Debug.Log("max 사이즈 버튼");
    }
    [Space(15), HorizontalLine(color: FixedColor.CherryRed), HideField] public bool _l3;
    [Button("Method4", true)] public int inbpuNum;
    void Method4(int n)
    {
        Debug.Log($"입력한 숫자 {n}");
    }



}
