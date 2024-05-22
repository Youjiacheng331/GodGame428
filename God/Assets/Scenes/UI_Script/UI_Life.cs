using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UI_Life : MonoBehaviour
{
    public Text ghostCountText; // お化けの数を表示するテキスト
    public string tagToCount;//カウントするタグ
    public Text waveNolma;//ウェーブのノルマを表示するテキスト
    public static int killghost;//ウェーブ内で倒されたゴーストの総数
    public Text LifeText;//ゲージ内の数字テキスト
    public Image gaugeImage_Now; // ゲージのイメージ（現在値）
    //public Image agugeImage_Max;//ゲージイメージ（最大）
    private int[] waveQuotas = new int[5] { 10, 15, 20, 25, 30 }; // 各ウェーブのノルマ
    private int currentWave; // 現在のウェーブ番号
    private int lastWabe = 1;//前回のウェーブ番号を追跡する為にの変数
    private int currentGhostCount; // 現在のお化けの数
    private float gaugeMax = 100; // ゲージの最大値
    private float gaugeCurrent = 0; // 現在のゲージの値


    // Start is called before the first frame update
    void Start()
    {
        currentWave = Timer.waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = Timer.waveNumber;

        //特定のタグの数をカウントする
        int ghost_count = GameObject.FindGameObjectsWithTag(tagToCount).Length;
        currentGhostCount = ghost_count;
        //表示更新
        ghostCountText.text = "x" + ghost_count.ToString();//現在のゴースト数
        LifeText.text = gaugeCurrent.ToString() + "/" + gaugeMax.ToString();//現在のライフ
        waveNolma.text = killghost.ToString("D2") + "/" + waveQuotas[Timer.waveNumber-1];//現在のノルマ
        gaugeImage_Now.fillAmount = gaugeCurrent / gaugeMax;//ゲージのUI更新

        //もし現在のウェーブ数と最後のウェーブ数が違うのならば
        if (currentWave != lastWabe)
        {
            //ウェーブが完了したとみなし、OnWaveCompletedを呼び出す
            OnWaveCompleted();

            //lastWaveを更新
            lastWabe = currentWave;
        }



        //もしゲージの最大値以上になったら
        if(gaugeCurrent>=gaugeMax)
        {
            //ゲームオーバー処理へ移行する
            GameOver();
        }



    }

    public void OnWaveCompleted()
    {
        //現在のウェーブのノルマを取得
        int waveQuota = waveQuotas[Timer.waveNumber];

        //ウェーブのノルマを達成したか
        if(killghost < waveQuota)
        {
            //ノルマ未達成の場合、ゲージ倍増
            gaugeCurrent += currentGhostCount * 2;
        }
        else
        {
            //ノルマ達成の場合、残ったおばけの数だけゲージを増加
            gaugeCurrent += currentGhostCount;
        }

        ////ゲージのUI更新
        //gaugeImage_Now.fillAmount = gaugeCurrent / gaugeMax;
        ////おばけの数のテキスト更新
        //ghostCountText.text = "x" + currentGhostCount.ToString();
        //LifeText.text = gaugeCurrent.ToString() + "/" + gaugeMax.ToString();

    }

    private void GameOver()
    {
        //ゲームオーバー時の処理（暫定）
        Debug.Log("GAME OVER");
        //ゲームオーバー時のUI表示など

    }


}
