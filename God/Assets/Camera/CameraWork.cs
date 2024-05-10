using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    // �v���C���[�I�u�W�F�N�g
    [SerializeField]
    GameObject Player;

    // ���C���J����
    [SerializeField]
    GameObject MainCamera;

    [SerializeField]
    float RotateSpeed;  //��]���x

    private float ANGLE_LIMIT_UP = 30f;       //�J�������]����
    private float ANGLE_LIMIT_DOWN = -30f;    //�J��������]����

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
        // �v���C���[��ǐ�
        if (Player != null)
        {
            transform.position = Player.transform.position;
        }

        // �J������]
        RotateCamera();


        // �J�����㉺��]����
        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );


        // Z�����Œ�
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    private void RotateCamera()
    {
        // �}�E�X�̈ړ��ŃJ�����̉�]�p�x�����Z
        Vector3 angle = new Vector3(
        Input.GetAxis("Mouse X") * RotateSpeed,
        Input.GetAxis("Mouse Y") * RotateSpeed,
        0);

        transform.eulerAngles += new Vector3(-angle.y, angle.x);
    }
}
