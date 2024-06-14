using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public Text waveText;
    private TimeSpan timeLeft;
    public static int waveNumber = 1;//初期のウェーブ番号
    private int waveNumbermax = 5;//ウェーブ最大数

    private string gameClearSceneName = "GameClear";

    // Start is called before the first frame update
    void Start()
    {
        //タイマーが何分かを括弧内の数字で設定する
        timeLeft = TimeSpan.FromMinutes(5);
        //タイマーのテキスト表示の形式の設定（X分：XX秒）
        timerText.text = timeLeft.ToString(@"m\:ss");
        //ウェーブのテキスト表示の形式の設定（X/最大数WAVE）
        waveText.text = waveNumber.ToString() + "/"+waveNumbermax.ToString()+"WAVE";
    }

    // Update is called once per frame
    void Update()
    {
        //もし残り秒数が0より大きいならば
        if(timeLeft.TotalSeconds>0)
        {
            //時間を減らす
            timeLeft -= TimeSpan.FromSeconds(Time.deltaTime);
            //UIを更新
            timerText.text = timeLeft.ToString(@"m\:ss");

            //もし残り時間がちょうど１分減ったら
            if(timeLeft.TotalMinutes%1<=double.Epsilon&&waveNumber<waveNumbermax)
            {
                //ウェーブ番号を増やす
                waveNumber++;
                //テキストに反映
                waveText.text = waveNumber.ToString() + "/" + waveNumbermax.ToString() + "WAVE";

                
            }


        }
        //残り秒数が0の時
        else if(timeLeft.TotalSeconds <= 0)
        {
            //テキストの固定
            timerText.text = "0:00";
            //ゲームクリア処理
            GameClear();
        }

    }

    private void GameClear()
    {
        //ゲームクリア時の処理（暫定）
        Debug.Log("GAME CLEAR");
        //ゲームクリアシーンへの移行
        SceneManager.LoadScene(gameClearSceneName);
    }

}
