using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text waveText;
    private TimeSpan timeLeft;
    private bool timerRunning = false;//���̃t���O�̓V�[���J�ړ��ɂ��g����������
    private int waveNumber = 1;//�����̃E�F�[�u�ԍ�
    private int waveNumbermax = 5;//�E�F�[�u�ő吔

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[�������������ʓ��̐����Őݒ肷��
        timeLeft = TimeSpan.FromMinutes(5);
        //�^�C�}�[�̃e�L�X�g�\���̌`���̐ݒ�iX���FXX�b�j
        timerText.text = timeLeft.ToString(@"m\:ss");
        //�E�F�[�u�̃e�L�X�g�\���̌`���̐ݒ�iX/�ő吔WAVE�j
        waveText.text = waveNumber.ToString() + "/"+waveNumbermax.ToString()+"WAVE";
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

            //�����c�莞�Ԃ����傤�ǂP����������
            if(timeLeft.TotalMinutes%1<=double.Epsilon&&waveNumber<waveNumbermax)
            {
                //�E�F�[�u�ԍ��𑝂₷
                waveNumber++;
                //�e�L�X�g�ɔ��f
                waveText.text = waveNumber.ToString() + "/" + waveNumbermax.ToString() + "WAVE";
            }


        }
        //�c��b����0�̎�
        else if(timeLeft.TotalSeconds <= 0)
        {
            //�e�L�X�g�̌Œ�
            timerText.text = "0:00";
            //�^�C�}�[�������Ă�t���O��Off�ɂ���
            timerRunning = false;
        }

    }
}
