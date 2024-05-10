using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    // プレイヤーオブジェクト
    [SerializeField]
    GameObject Player;

    // メインカメラ
    [SerializeField]
    GameObject MainCamera;

    [SerializeField]
    float RotateSpeed;  //回転速度

    private float ANGLE_LIMIT_UP = 30f;       //カメラ上回転制限
    private float ANGLE_LIMIT_DOWN = -30f;    //カメラ下回転制限

    public void SetPlayer(GameObject player)
    {
        Player = player;
    }

    public void SetCameraPosition(Vector3 pos)
    {
        MainCamera.transform.localPosition = pos;
    }


    // Update is called once per frame
    void Update()
    {
        // プレイヤーを追随
        if (Player != null)
        {
            transform.position = Player.transform.position;
        }

        // カメラ回転
        RotateCamera();


        // カメラ上下回転制限
        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );


        // Z軸を固定
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    private void RotateCamera()
    {
        // マウスの移動でカメラの回転角度を加算
        Vector3 angle = new Vector3(
        Input.GetAxis("Mouse X") * RotateSpeed,
        Input.GetAxis("Mouse Y") * RotateSpeed,
        0);

        transform.eulerAngles += new Vector3(-angle.y, angle.x);
    }
}
