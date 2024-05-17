using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public int Wave;

    public bool GameOver;
    public bool GameClear;

    public bool WaveStart;

    public float CountDown;

    [SerializeField]
    GameObject GhostPrefab;

    int CreateTime;

    // Start is called before the first frame update
    void Start()
    {
        Wave = 0;

        CountDown = 0;
        WaveStart = false;

        GameOver = false;
        GameClear = false;

        CreateTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CountDown == 0 && WaveStart == false)
        {
            //wave�I�����̏���





            CountDown = 3;//wave�Ԃ̑ҋ@����

            WaveStart = true;

            Wave++;
        }


        if (CountDown == 0 && WaveStart == true)
        {
            switch (Wave)
            {
                case 1:
                    CountDown = 30;
                    break;
                case 2:
                    CountDown = 40;
                    break;
                case 3:
                    CountDown = 60;
                    break;
            }

            WaveStart = false;
        }

        //��������J�E���g�_�E���֐�
        TimeCount();

        //�H�쐶��
        GhostRespawn(Wave);

        //�Q�[���I�[�o�[����
        //if ()
        //{
        //    GameOver = true;
        //}

        //�Q�[���N���A
        //if (CountDown == 0 && Wave == 3)
        //{
        //    GameClear = true;
        //}


    }

    //���ԃJ�E���g�_�E���֐�
    void TimeCount()
    {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0)
        {
            CountDown = 0;
        }
    }

    //�H�색���_�������֐�
    void GhostRespawn(int wave)
    {
        Vector3 RespawnPos;

        RespawnPos.x = Random.Range(-7.0f, 7.0f);

        RespawnPos.z = Random.Range(-21.0f, 11.0f);

        RespawnPos.y = 0.0f;

        if (WaveStart == false && CreateTime != (int)CountDown) 
        {

            switch (wave)
            {
                case 1:
                    if ((int)CountDown % 6 == 0 && CountDown > 0)
                    {
                        CreateTime = (int)CountDown;
                        // �I�u�W�F�N�g�𐶐�
                        GameObject ghost = Instantiate(GhostPrefab, RespawnPos, Quaternion.identity);
                    }
                    break;
                case 2:
                    if ((int)CountDown % 5 == 0 && CountDown > 0)
                    {
                        CreateTime = (int)CountDown;
                        // �I�u�W�F�N�g�𐶐�
                        GameObject ghost = Instantiate(GhostPrefab, RespawnPos, Quaternion.identity);
                    }
                    break;
                case 3:
                    if ((int)CountDown % 3 == 0 && CountDown > 0)
                    {
                        CreateTime = (int)CountDown;
                        // �I�u�W�F�N�g�𐶐�
                        GameObject ghost = Instantiate(GhostPrefab, RespawnPos, Quaternion.identity);
                    }
                    break;
            }
        }
        
       
    }

}
