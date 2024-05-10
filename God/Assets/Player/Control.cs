using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    CharacterController con;

    float normalSpeed; // 通常時の移動速度

    float sprintSpeed; // ダッシュ時の移動速度

    float jump;        // ジャンプ力

    [SerializeField]
    GameObject MainCamera;        // カメラ

    float gravity = 10f;    // 重力

    Vector3 moveDirection = Vector3.zero; //　移動方向

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        // Playerパラメータから数値を取り出す

        normalSpeed = GetComponent<PlayerParameter>().moveSpeed;


        sprintSpeed = normalSpeed * 3;

        jump = GetComponent<PlayerParameter>().jumpForce;

        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        startPos = transform.position;

        // プレイヤー生成時、自分のカメラを設定

        MainCamera = GameObject.Find("Camera");
        MainCamera.GetComponent<CameraWork>().SetPlayer(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        // 移動速度
        float speed;

        speed = normalSpeed;


        // カメラの向きを基準にした正面方向のベクトル
        Vector3 cameraForward = Vector3.Scale(MainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 移動のためのベクトルを計算
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //　前後（カメラ基準）　 
        Vector3 moveX = MainCamera.transform.right * Input.GetAxis("Horizontal") * speed; // 左右（カメラ基準）

        // isGrounded は地面にいるかどうかを判定します
        // 地面にいるときはジャンプを可能に
        if (con.isGrounded)
        {
            moveDirection = moveZ + moveX;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jump;
            }
        }
        else
        {
            // 重力
            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }



        // 向きに変更　
        transform.LookAt(transform.position + moveZ + moveX);

        // 指定したベクトルだけ移動
        con.Move(moveDirection * Time.deltaTime);
    }
}
