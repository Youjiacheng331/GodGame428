using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    CharacterController con;

    float normalSpeed; // �ʏ펞�̈ړ����x

    float sprintSpeed; // �_�b�V�����̈ړ����x

    float jump;        // �W�����v��

    [SerializeField]
    GameObject MainCamera;        // �J����

    float gravity = 10f;    // �d��

    Vector3 moveDirection = Vector3.zero; //�@�ړ�����

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        // Player�p�����[�^���琔�l�����o��

        normalSpeed = GetComponent<PlayerParameter>().moveSpeed;


        sprintSpeed = normalSpeed * 3;

        jump = GetComponent<PlayerParameter>().jumpForce;

        // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        startPos = transform.position;

        // �v���C���[�������A�����̃J������ݒ�

        MainCamera = GameObject.Find("Camera");
        MainCamera.GetComponent<CameraWork>().SetPlayer(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        // �ړ����x
        float speed;

        speed = normalSpeed;


        // �J�����̌�������ɂ������ʕ����̃x�N�g��
        Vector3 cameraForward = Vector3.Scale(MainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;

        // �ړ��̂��߂̃x�N�g�����v�Z
        Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //�@�O��i�J������j�@ 
        Vector3 moveX = MainCamera.transform.right * Input.GetAxis("Horizontal") * speed; // ���E�i�J������j

        // isGrounded �͒n�ʂɂ��邩�ǂ����𔻒肵�܂�
        // �n�ʂɂ���Ƃ��̓W�����v���\��
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
            // �d��
            moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
            moveDirection.y -= gravity * Time.deltaTime;
        }



        // �����ɕύX�@
        transform.LookAt(transform.position + moveZ + moveX);

        // �w�肵���x�N�g�������ړ�
        con.Move(moveDirection * Time.deltaTime);
    }
}
