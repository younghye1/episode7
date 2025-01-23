using System.Collections.Generic;
using CustomInspector;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{

    [Space(15), HorizontalLine("프리팹", color: FixedColor.CherryRed), HideField] public bool _l0;

    // 프랍들을 모아놓을 그룹 Root (부모)
    [SerializeField] Transform propRoot;

    //프리팹(prefab) ->인스턴스화(Instantiate)->리스트에 여러 프리팹->랜덤스폰
    [SerializeField, Preview(Size.small)] List <GameObject> prefabs;
    [Space(15), HorizontalLine("배치속성", color: FixedColor.CherryRed), HideField] public bool _l1;
    [SerializeField] LayerMask layermask;
    [SerializeField] Color gizmoColor = Color.white;


    [SerializeField] float radius; //지름

    //int : -21억~21억 , uint : 0~ 42억
    [SerializeField,AsRange(1,1000)] Vector2 maxNumByRange;
    // [SerializeField] float yOffset; // Y높이조절
    [Space(15), HorizontalLine("회전속성", color: FixedColor.CherryRed), HideField] public bool _l2;

    [SerializeField, AsRange(-90f, 90f)] Vector2 rotateXaxis; //x축 회전 범위
    [SerializeField, AsRange(-180f, 180f)] Vector2 rotateYaxis; //Y축 회전 범위
    [SerializeField, AsRange(-90f, 90f)] Vector2 rotateZaxis; //z축 회전 범위

    [Space(15), HorizontalLine("크기속성", color: FixedColor.CherryRed), HideField] public bool _l3;


    [SerializeField, AsRange(0.75f, 1.5f)] Vector2 scaleRange; //크기 범위 설정
    [Space(15), HorizontalLine("버튼", color: FixedColor.CherryRed), HideField] public bool _l4;


    [Button("Spawn"), HideField] public bool _b0;
    public void Spawn()
    {
        Vector3 rndpos = Random.insideUnitSphere * radius + transform.position; //랜덤 위치 계산



        //CheckHeight를 활용해서 스폰 가능한지? 아닌지? 판단하고 생성
        Vector3 hitpoint;
        //거짓: 빈 공간 -> 함수 탈출 
        if(CheckHeight(rndpos,out hitpoint) == false)
            return;
        //참: 기존 계획대로 함수 실행



        //prefab; // GmaeObject
        //prefabs; //List<GameObject>

        //리스트 안의 데이터 수 : prefabs.Count;
        //리스트의 인덱스를 통한 값 가져오기

        //prefabs[0] : 리스트의 첫번째 값
        //prefabs[prefabs.count-1] : 리스트의 마지막 값
        int rndcnt = Random.Range(0, prefabs.Count - 1);
    
        //Instantiate 생성
        //Instantiate(prefab, new Vector3 (0,0,0), Quaternion.indentity);
        //GameObject clone = Instantiate(prefab); //오브젝트 복제
        GameObject clone = Instantiate(prefabs[rndcnt]);





        //float   (x)
        //Vector2 (x,y)
        //Vector3 (x,y,z)
        //Vector4 (x,y,z,w)
        //Color   (r,g,b,a)

        //insideUnitSphere는 크기가 -도 포함.

        //float rndscl = Random.value; //제한 없이 크기 랜덤
        float rndscl = Random.Range(0.5f, 0.8f); //범위 내 크기 랜덤

        //크기를 랜덤하게 조절한다
        clone.transform.localScale = new Vector3(rndscl, rndscl, rndscl);

        //transform: 변형
        //1.위치(posision), 회전(rotation) , 크기(scale)
        //2. 계층구조(Hierarchy) ,부모-자식 (parent-Child)

        //Gameobject > Transform
        //1. 생성 ( Instantiate )
        //2. 삭제 ( Destroy(플레이모드), DestroyImmediate(에디터모드))

        //각도 랜덤
        //clone.transform.rotation = Quaternion을 배운 후에 다룬다
        float rndrotX = Random.Range(rotateXaxis.x, rotateXaxis.y); //최소값
        float rndrotY = Random.Range(rotateXaxis.x, rotateXaxis.y); //최대값
        float rndrotZ = Random.Range(rotateXaxis.x, rotateXaxis.y);


        clone.transform.Rotate(new Vector3(rndrotX, rndrotZ, rndrotY));



        //위치를 랜덤하게 한다
        clone.transform.position = new Vector3(hitpoint.x, hitpoint.y, hitpoint.z); //y는 고정값. x,z는 랜덤
        clone.transform.SetParent(propRoot); //생성되는 오브젝트가 엄마폴더 안으로
        //clone.transform.position = rndpos; //무작위 위치 생성



        //(0.0f~1.0f)=> x 10 (0f~10.0f)
        //Random.value
        //3개(-1f~1f,-1f~1f,-1f~1f)
        // Random.insideUnitSphere * 10f

        //변수 Range만큼, 증폭하여 위치 이동

        
    }

    void OnDrawGizmos() //에디터에서 기즈모를 그릴 수 있는 공간
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireCube(transform.position, Vector3.one * radius);
        //Gizmos.DrawIcon(transform.position,"arrow");
    }


    //한 번 클릭에 설정한 수 만큼 나무 생성
    [Button("spawnLoop"), HideField] public bool _b2;
    void spawnLoop()
    {
        int rnd = (int)Random.Range(maxNumByRange.x,maxNumByRange.y);
        for (int i = 0; i <= rnd; i++)
        {
            Spawn();
        }
    }


    [Button("Despawn"), HideField] public bool _b1;
    void Despawn()
    {
        //Destroy 플레이모드에서 삭제할때
        //DestroyImmediate 에디터모드 삭제할때
        // propRoot.childCount //자식 수를 가져온다
        // propRoot // 리스트 자료구조 형
        // 변수 (variables)
        // foreach (Transform t in propRoot) //리스트에 뭐가있든 한번씩 값을 가져오는것
        // {
        //     if(CheckInside(t.position,transform.position))
        //     DestroyImmediate(t.gameObject); //에디터모드 삭제(트렌스폼.게임오브젝트)
        // }

        for (int i = propRoot.childCount-1; i >=0 ;i--)
        {
            Transform t=propRoot.GetChild(i);
            if (CheckInside(t.position, transform.position))
                DestroyImmediate(t.gameObject);
        }
    }



    //원 안에 들어왔는지 검사하는 함수
    [Space(30), HideField] public bool _s1;
    bool CheckInside(Vector3 A, Vector3 B)
    {
        //두 점 사이의 거리
        float dist = Vector3.Distance(A, B);
        return dist <= radius;

        // //충돌 안함
        // if (dist ` radius)
        // {
        //     return true;
        // }

        // //충돌했음
        // else
        // {


        //     return false;
        // }
    }


    //생성할 오브젝트와 지형이 만나는 지점을 찾는다
    bool CheckHeight(Vector3 clonpoint, out Vector3 hitpoint)
    {
        // 기준점 : Gizmo -> spawner의 위치를 기준 일정 높이 위에서 Ray 를 Cast 한다.

        RaycastHit hit;

        if (Physics.Raycast(clonpoint + Vector3.up * 30f, -Vector3.up, out hit, 100.0f,layermask))
        {
            //참? 충돌했다 =>추돌한 위치가 어디냐? => 그 위치에 나무를 심는다
            //충돌지점
            hitpoint = hit.point;
            return true;
        }
        //거짓? 충돌안했다=> 패스

        hitpoint = Vector3.zero;
        return false;
    }


}
