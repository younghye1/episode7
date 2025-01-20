using System.Collections.Generic;
using System.Linq.Expressions;
using CustomInspector;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class List1 : MonoBehaviour

{

    //   datas.Add() //추가
    //   datas.Clear() //전체 삭제
    //   datas.Remove() //1개 삭제
    //   datas.Find() //특정값을 찾는다
    //   datas.Sort() //정렬 (오름차순, 내림차순)
    //   datas.Count() // 총 개수
    //   datas.ForEach()//배열 순회 출력



    // public int[] 배열형태 
    public List<int> datas = new List<int>(); //많이 씀
    //public List<string> dataStrs = new List<string>();
    //public List<GameObject> dataObjs = new List<GameObject>();
    //public List<bool> dataBools;



    [Space(30), Button("AddData", true)] public int addNum;
    void AddData(int n)
    {
        datas.Add(n);

        //Debug.Log($입력한 숫자{n});
        //입력한 숫자를 data 리스트에 넣기
    }
    [Button("ClearData"),HideField] public bool _b1;
    void ClearData()
    {
        //datas 리스트 전체 삭제
        datas.Clear();


    }

    void removeData(int n)
    {
        //datas 리스트에서 1개 만 삭제
    }

    [Button("ClearRemove")] public int removeNum;
    [Space(20), Button("RemoveData", true)] public int removeIndex;
    void RemoveData(int i)
    {
        //data리스트에서 1개 만 삭제
        // datas.Remove(n)
        // datas. RemoveAt(i): 순번에 해당하는 것만 삭제
        datas.Remove(i);//
        //datas.RemoveAll(); //조건에 맞는것만 전체 삭제

        void RemoveAt(int i)
        {
            datas.RemoveAt(i); //순번(index)에 해당하는 것만 삭제
        }

    }
    void RemoveAtData(int i)
    {
        //i에 해당하는 데이터가 있는지?
        //참: 지워라, 거짓: 패스
        //datas.Contains(값)
        // if( !datas.Exists(a => a == i))
        //     return;

        //datas.Find()
            //참

       try
       {
        datas.RemoveAt(i); //순번(index)에 해당하는 것만 삭제        
       }
       catch(ArgumentAoutOfRangeExeption)
       {
        
       }
       finally
       {

       }
    }
    [Button("SortData"),HideField] public bool _b2;
    void SortData()
    {
        //기본 정렬 해보기
        datas.Sort();
    }
    
    void ShowAllData()
    {
        //리스트의 모든 데이터를 출력해보기
        //반복문
    
    }
}

