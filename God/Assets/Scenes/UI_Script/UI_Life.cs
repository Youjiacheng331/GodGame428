using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI_Life : MonoBehaviour
{
    public Text ghostCountText; // �������̐���\������e�L�X�g
    public string tagToCount;//�J�E���g����^�O
    public Text waveNolma;//�E�F�[�u�̃m���}��\������e�L�X�g
    public static int killghost;//�E�F�[�u���œ|���ꂽ�S�[�X�g�̑���
    public Text LifeText;//�Q�[�W���̐����e�L�X�g
    public Image gaugeImage; // �Q�[�W�̃C���[�W
    private int[] waveQuotas = new int[5] { 10, 15, 20, 25, 30 }; // �e�E�F�[�u�̃m���}
    private int currentWave; // ���݂̃E�F�[�u�ԍ�
    private int lastWabe = 1;//�O��̃E�F�[�u�ԍ���ǐՂ���ׂɂ̕ϐ�
    private int currentGhostCount; // ���݂̂������̐�
    private int gaugeMax = 100; // �Q�[�W�̍ő�l
    private int gaugeCurrent = 0; // ���݂̃Q�[�W�̒l


    // Start is called before the first frame update
    void Start()
    {
        currentWave = Timer.waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = Timer.waveNumber;

        //����̃^�O�̐����J�E���g����
        int ghost_count = GameObject.FindGameObjectsWithTag(tagToCount).Length;
        currentGhostCount = ghost_count;
        //�\���X�V
        ghostCountText.text = "x" + ghost_count.ToString();//���݂̃S�[�X�g��
        LifeText.text = gaugeCurrent.ToString() + "/" + gaugeMax.ToString();//���݂̃��C�t
        waveNolma.text = "00" + "/" + waveQuotas[Timer.waveNumber-1];//���݂̃m���}

        //�������݂̃E�F�[�u���ƍŌ�̃E�F�[�u�����Ⴄ�̂Ȃ��
        if (currentWave != lastWabe)
        {
            //�E�F�[�u�����������Ƃ݂Ȃ��AOnWaveCompleted���Ăяo��
            OnWaveCompleted(currentGhostCount);

            //lastWave���X�V
            lastWabe = currentWave;
        }



        //�����Q�[�W�̍ő�l�ȏ�ɂȂ�����
        if(gaugeCurrent>=gaugeMax)
        {
            //�Q�[���I�[�o�[�����ֈڍs����
            GameOver();
        }



    }

    public void OnWaveCompleted(int killGhosts)
    {
        //���݂̃E�F�[�u�̃m���}���擾
        int waveQuota = waveQuotas[Timer.waveNumber];

        //�E�F�[�u�̃m���}��B��������
        if(killGhosts>waveQuota)
        {
            //�m���}���B���̏ꍇ�A�Q�[�W�{��
            gaugeCurrent += currentGhostCount * 2;
        }
        else
        {
            //�m���}�B���̏ꍇ�A�c�������΂��̐������Q�[�W�𑝉�
            gaugeCurrent += currentGhostCount;
        }

        //�Q�[�W��UI�X�V
        gaugeImage.fillAmount = gaugeCurrent / gaugeMax;

        //���΂��̐��̃e�L�X�g�X�V
        ghostCountText.text = "x" + currentGhostCount.ToString();

        //�Q�[�WUI�ƃ��C�tText���X�V
        gaugeImage.fillAmount = gaugeCurrent / gaugeMax;
        LifeText.text = gaugeCurrent.ToString() + "/" + gaugeMax.ToString();

    }

    private void GameOver()
    {
        //�Q�[���I�[�o�[���̏����i�b��j
        Debug.Log("GAME OVER");
        //�Q�[���I�[�o�[����UI�\���Ȃ�

    }


}
