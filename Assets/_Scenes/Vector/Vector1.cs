using UnityEngine;
using CustomInspector;

public class Vector1 : MonoBehaviour
{

    // 힘 , 방향
   public float force = 10f;  

    // float : Scalar 힘
    // 벡터(Vector) : 힘 + 방향

    public Vector3 vA;
    public Vector3 vB;

    // 보여주기용 읽기전용 
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AaddB;
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AminusB;
    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 AmultiForce;

    [ReadOnly(disableStyle = DisableStyle.OnlyText)] public Vector3 Amultiforcenomal;

    // 예약함수 : 에디터 모드에서 기즈모를 그려라
    void OnDrawGizmos()
    {
        //DrawVectorElement();
        DrawVectorOperation();
    }




    [Button("VectorElement", label = "벡터 기본 속성"), HideField] public bool _b0;
    void VectorElement()
    {
        Debug.Log($"벡터 zero : {Vector3.zero}");
        Debug.Log($"벡터 one : {Vector3.one}");

        //유니티 좌표계 : 왼손 좌표계 
        //검지 = Forward vector =Z+
        //엄지 = Up vector =Y+
        //중지 = Right vector = X+

        Debug.Log($"벡터 up : {Vector3.up}");   // 0,1,0
        Debug.Log($"벡터 down : {Vector3.down}");   // 0,-1,0
        Debug.Log($"벡터 foward : {Vector3.forward}");   // 0,0,1
        Debug.Log($"벡터 back : {Vector3.back}");   // 0,0,-1
        Debug.Log($"벡터 right : {Vector3.right}");   // 1,0,0
        Debug.Log($"벡터 left : {Vector3.left}");   // -1,0,0
    }

    void DrawVectorElement()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Vector3.zero, Vector3.up);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero, Vector3.right);
    }

    void DrawVectorOperation()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Vector3.zero, vA);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector3.zero, vB);

        //벡터간 덧셈 : 가능
        AaddB = vA + vB;

        Gizmos.color = new Color(1f, 1f, 0f);
        Gizmos.DrawRay(Vector3.zero, AaddB);
        
        //벡터간 뺄셈 : 가능
        // 의미 : 둘 사이의 기준벡터 거리(방향)
        AminusB = vA - vB;
        Gizmos.color = new Color(0f, 1f, 0f);
        Gizmos.DrawRay(Vector3.zero, AminusB);

        //벡터간 곱셈 : 불가능

        //AmultiB = vA* vB;
        
        //벡터와 float (스칼라) 곱셈:
        AmultiForce= vA* force; 

        Gizmos.color = new Color(0f, 1f, 0f);
        Gizmos.DrawRay(Vector3.zero, AmultiForce);

        //벡터간 나눗셈: 불가능
        //벡터의 정규화(Nomalize) -1~1 사이 값으로 만들어준다 => 방향 (Direction)
        Amultiforcenomal = AmultiForce.normalized;

        Gizmos.color = new Color(0f, 0f, 0f);
        Gizmos.DrawRay(Vector3.zero, Amultiforcenomal);

    }


}