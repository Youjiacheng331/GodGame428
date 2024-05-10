using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private TimeSpan timeLeft;
    private bool timerRunning = false;//���̃t���O�̓V�[���J�ړ��ɂ��g����������


    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[�������������ʓ��̐����Őݒ肷��
        timeLeft = TimeSpan.FromMinutes(5);
        //�^�C�}�[�̃e�L�X�g�\���̌`���̐ݒ�iX���FXX�b�j
        timerText.text = timeLeft.ToString(@"m\:ss");
        //�^�C�}�[�������Ă�t���O��On�ɂ���
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�����c��b����0���傫���Ȃ��
        if(timeLeft.TotalSeconds>0)
        {
            //���Ԃ����炷
            timeLeft -= TimeSpan.FromSeconds(Time.deltaTime);
            //UI���X�V
            timerText.text = timeLeft.ToString(@"m\:ss");
        }
        //�c��b����0�̎�
        else
        {
            //�e�L�X�g�̌Œ�
            timerText.text = "0:00";
            //�^�C�}�[�������Ă�t���O��Off�ɂ���
            timerRunning = false;
        }

    }
}
