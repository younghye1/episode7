using UnityEngine;

// 라디안 (Radian)
// Degree (일반 각도표현)  Radian (수학, 물리 각도표현 단위)
// 0 ~ 360도 , 1 pie(π) = 180도, 2π + 360도

// 1Radian      = 57.30도
// 2Radian      = 114.6도
// 3Radian      = 171.9도
// 3.14Radian   = 180도
// ...
// 6Radian      = 360도

// 이동 => Vector3 처리
// 회전 => Quaternion 처리
// 크기 => Vector3 처리
public class Quaterion1 : MonoBehaviour
{
    public float pitch; 
    public float yaw; 
    public float ratatespeed = 20f;
    
void Update()
    {
        //yaw = Input.GetAxis("Horizontal") * ratatespeed * Time.deltaTime;
        //pitch = Input.GetAxis("Vertical") * ratatespeed * Time.deltaTime;

        Quaternion rotation = Quaternion. Euler(pitch, yaw,0);

        transform.rotation = rotation;

    }

}
