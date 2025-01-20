using System;
using System.Collections.Generic;
using CustomInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Array1 : MonoBehaviour
{
    // 배열 (Array)
    // int, float, string, bool
    // 배열 or 리스트 화 할 수 있다

    public List<GameObject> objList;

    public int num = 3; //초기화
    public int[] numArray; //초기선언
    // public int [] numArray2 = {1,3,5,7}; //초기 숫자를 넣어줄 수 있다

    public string[] nameArray;
    public string nameFind;

    [HorizontalLine("버튼영역"), HideField] public bool _l0;


    [Range(0, 2.0f)] public List<float> numList;

    [Space(30), Button("ArrayGetValue", size = Size.medium), HideField] public bool _b0;
    void ArrayGetValue()
    {
        //numArra.GetLength(0)대신 numArray.Lengthg
        //배열의 전체 길이
        Debug.Log($"개수:GetLength= {numArray.Length}");

        //배열의 특정 위치의 값을 가져온다
        //index (시작:0~끝:4) 0,1,2,3,4
        // 시작 : numArray[0] : ,  끝 numArray[4] => numArray[numArray.Length -1]
        Debug.Log($"index{2}의 값: {numArray.GetValue(2)}");
        Debug.Log($"값[ ]방식 - Index{2} : {numArray[2]}");

        //GetValue(index) 와 [ index ] 방식 서로 같다
        //numArray.GetValue(3);
        //numArray[3];

        //Random.Range(0f,1f);
        //Random.value * 10f;
    }

    [Space(1), Button("ArrayLoop1", size = Size.medium), HideField] public bool _b1;

    void ArrayLoop1()
    {
        //시작; 끝; 전체길이;
        //유한 루프로 전체 값 출력
        for (int a = 0; a < numArray.Length; a++)
        {
            Debug.Log($"Index{a} : {numArray[a]}");
        }
    }


    [Space(1), Button("ArrayLoop2", size = Size.medium), HideField] public bool _b2;
    void ArrayLoop2()
    {
        //배열 자체를 넣어주면, foreach 알아서 전체루프 1바퀴 돌린다. 
        //자동(Auto) :
        //foreach((알아서)시작값 전달 in 배열 덩어리)
        int index = 0;
        foreach (int a in numArray)
        {
            Debug.Log($"index{index}:{a}");
            index++;
        }
    }

    [Button("ArrayFind", size = Size.medium), HideField] public bool _b3;
    void ArrayFind()
    {
        //배열 안에 특정 값을 찾기
        //어떻게 배열 검색을 해서 찾을것인가?
        //nameFind로 nameArray에서 값을 찾기
        //결과: 찾은 경우=> index:? 출력 => 루프 탈출
        //     못찾은 경우 => 해당값이 없음
        //for:인덱스
        //foreach:값
        for ( int i = 0 ; i < nameArray.Length ; i++ )
        {
            if(nameFind == nameArray[i])
            {
                Debug.Log($"찾았다.index={i}");

                //break; =>for루프만 탈출
                //continue; // for루프에서 현재 루프만 생략하고 다음 루프로
                return; //=>함수 전체 탈출               
            
            }
        }
        Debug.Log($"해당 값이 없음");
    }




//return 안쓰는 방법
    [Button("ArrayFind2", size = Size.medium), HideField] public bool _b4;
    void ArrayFind2()
    {
        int found = -1;
        //return 없이 처리하는 경우
        for (int i = 0; i < nameArray.Length; i++)
        {
            if (nameFind == nameArray[i])
            {
                found = i;
                Debug.Log($"찾았다 index: {found}");
                //찾았다
                break;
            }
        }
        // found가 -1이란 의미는, 초기값 그대로 내려왔기 때문에=> 못찾은거다
        if( found == -1)
            Debug.Log("못찾았다!");
    }
}
