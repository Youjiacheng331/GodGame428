using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private TimeSpan timeLeft;
    private bool timerRunning = false;//このフラグはシーン遷移等にお使いください


    // Start is called before the first frame update
    void Start()
    {
        //タイマーが何分かを括弧内の数字で設定する
        timeLeft = TimeSpan.FromMinutes(5);
        //タイマーのテキスト表示の形式の設定（X分：XX秒）
        timerText.text = timeLeft.ToString(@"m\:ss");
        //タイマーが動いてるフラグをOnにする
        timerRunning = true;
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
        }
        //残り秒数が0の時
        else
        {
            //テキストの固定
            timerText.text = "0:00";
            //タイマーが動いてるフラグをOffにする
            timerRunning = false;
        }

    }
}
