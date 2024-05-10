using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameter : MonoBehaviour
{
    //�v���C���[��Parameter��ݒ肷�邽�߂̃t�@�C��


    [Header("�F��P�[�W")]
    public float Skill = 100.0f;

    [Header("�F�蔼�a")]
    public float offenseArea = 5.0f;

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


    // Start is called before the first frame update
    void Start()
    {

        // �J�������Z�b�g
        MainCamera = GameObject.Find("Camera");

        MainCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        MainCamera.GetComponent<CameraWork>().SetCameraPosition(CameraPosition);
    }
}
