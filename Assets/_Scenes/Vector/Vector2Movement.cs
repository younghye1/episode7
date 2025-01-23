using UnityEngine;
using CustomInspector;

public class Vector2Movement : MonoBehaviour
{
    
    // Input
    // Legacy (오래된 버젼의 입력장치)
    // 키보드 , 마우스 , 모바일(터치) 입력을 처리한다.


    //[SerializeField, ReadOnly] Vector2 movement;

    // 이동속도
    [SerializeField] float movespeed = 1f;
    [SerializeField] float rotatespeed = 1f;

        
    void Update()
    {
        // 버튼 누르면 : 참 => 뭔가 실행
        // 버튼 안누르면 : 거짓 => 패스
        
        // GetButton 누른 상태인가 ? 뗀 상태인가 ?
        // if (Input.GetButton("Fire1"))
        //     Debug.Log("Fire1 눌렀음");

        // GetButtonDown 누를때 한번 호출
        // if (Input.GetButtonDown("Jump"))
        //     Debug.Log("점프 down");

        // if (Input.GetButtonUp("Jump"))
        //     Debug.Log("점프 up");

        float horz = Input.GetAxis("Horizontal");
        //Debug.Log($"Horz = {horz}");

        //movement 에 horz 와 vert 값을 적용해보기
        float vert = Input.GetAxis("Vertical");
        //Debug.Log($"Vert = {vert}");


        //1 마우스로 회전 => 키보드로 이동 (나중)
        //2 키보드로 회전, 이동 다 한다 (선택)

        // horz 회전 담당 , vert 이동 담당
        // horz a키 왼쪽회전 , d키 오른쪽회전
        // vert w키 앞으로, s키 뒤로간다

        // 이동 방향에 따라 회전은 따라간다

        // Timde.deltaTime 의 목적 : 결과값을 어느 사양에서든 동일하게 만들어 준다.
        transform.Rotate(0f, horz * rotatespeed * Time.deltaTime, 0f);

        //movement = new Vector2(horz, vert);
        transform.Translate(/*horz * Time.deltaTime * movespeed*/0f, 0f, vert * Time.deltaTime * movespeed);
    }
}