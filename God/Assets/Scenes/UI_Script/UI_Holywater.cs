using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Holywater : MonoBehaviour
{
    public Text holyWoter;

    //�����̏����l
    private int woter = 10;
    private int maxWoter;
    private int wave;//�ꎞ�I�ɃE�F�[�u���g�p

    private void Start()
    {
        UpdateMaxWoter(1);
    }


    // Update is called once per frame
    void Update()
    {
        //���������𓊝����鑀�삪���ꂽ��i���Ƃ���space�L�[�����Ă܂��j
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //���������̐����P�ȏ�Ȃ�
            if (woter >0)
            {
                //�c��̐��������P���炷
                woter--;
            }
            
            
        }
        //UI�X�V�iX�c��̐����̐��j
        holyWoter.text = "x" + woter.ToString();
    }

    public void UpdateMaxWoter(int newWave)
    {
        wave = newWave;
        switch (wave)
        {
            case 1:
                maxWoter = 5;
                break;
            case 2:
                maxWoter = 8;
                break;
            case 3:
                maxWoter = 10;
                break;
            default:
                maxWoter = 10;
                break;

        }
        //�ő�l�ɐݒ�
        woter = maxWoter;
        //���݂̐��l���ő�𒴂��Ȃ��悤��
        woter = Mathf.Min(woter, maxWoter);
        //UI�X�V�iX�c��̐����̐��j
        holyWoter.text = "x" + woter.ToString();

    }

}
