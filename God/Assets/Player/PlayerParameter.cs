using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameter : MonoBehaviour
{
    //プレイヤーのParameterを設定するためのファイル


    [Header("スタミナ")]
    public float Stamina = 100.0f;

   
    [Header("聖水残量")]
    public int Water = 5;

    [Header("移動速度")]
    public float moveSpeed = 10.0f;

    [Header("ジャンプ力")]
    public float jumpForce = 10.0f;

    [Header("視野角")]
    public float FoV = 100.0f;

    [Header("カメラ位置")]
    [SerializeField]
    Vector3 CameraPosition;


    // カメラオブジェクト
    GameObject MainCamera;

    [Header("スタミナバー")]
    [SerializeField]
    Slider StaminaBar;


    // Start is called before the first frame update
    void Start()
    {

        // カメラをセット
        MainCamera = GameObject.Find("Camera");

        MainCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        MainCamera.GetComponent<CameraWork>().SetCameraPosition(CameraPosition);
    }


    void Update()
    {
        //スタミナバーの変動処理




    }
}
