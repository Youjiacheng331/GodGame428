using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameter : MonoBehaviour
{
    //�v���C���[��Parameter��ݒ肷�邽�߂̃t�@�C��


    [Header("�X�^�~�i")]
    public float Stamina = 100.0f;

   
    [Header("�����c��")]
    public int Water = 5;

    [Header("�ړ����x")]
    public float moveSpeed = 10.0f;

    [Header("�W�����v��")]
    public float jumpForce = 10.0f;

    [Header("����p")]
    public float FoV = 100.0f;

    [Header("�J�����ʒu")]
    [SerializeField]
    Vector3 CameraPosition;


    // �J�����I�u�W�F�N�g
    GameObject MainCamera;

    [Header("�X�^�~�i�o�[")]
    [SerializeField]
    Slider StaminaBar;


    // Start is called before the first frame update
    void Start()
    {

        // �J�������Z�b�g
        MainCamera = GameObject.Find("Camera");

        MainCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        MainCamera.GetComponent<CameraWork>().SetCameraPosition(CameraPosition);
    }


    void Update()
    {
        //�X�^�~�i�o�[�̕ϓ�����




    }
}
