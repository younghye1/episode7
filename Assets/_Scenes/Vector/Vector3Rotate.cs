using CustomInspector;
using UnityEngine;

public class Vector3Rotate : MonoBehaviour
{

    public float pitch;  // x 축 회전 : Pitch , Vertical ( w키, s키)

    public float yaw; // y 축 회전 : Yaw , Horizontal (a키 ,b키 )

    public float roll; // z 축 회전 : Roll
    public float ratatespeed = 20f;

    void Update()
    {
        yaw = Input.GetAxis("Horizontal") * ratatespeed * Time.deltaTime;
        pitch = Input.GetAxis("Vertical") * ratatespeed * Time.deltaTime;


        transform.Rotate(new Vector3( pitch, yaw, roll));
    }

    [Button("Gimbalrock", label = "짐벌락"), HideField] public bool _b0;

    void Gimbalrock()
    {

    }

}
