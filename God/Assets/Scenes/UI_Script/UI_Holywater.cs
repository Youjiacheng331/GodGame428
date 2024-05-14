using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Holywater : MonoBehaviour
{
    public Text holyWoter;

    //聖水の初期値
    private int woter = 10;
    private int maxWoter;
    private int wave;//一時的にウェーブを使用

    private void Start()
    {
        UpdateMaxWoter(1);
    }


    // Update is called once per frame
    void Update()
    {
        //もし聖水を投擲する操作がされたら（仮としてspaceキーを入れてます）
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //もし聖水の数が１以上なら
            if (woter >0)
            {
                //残りの聖水数を１減らす
                woter--;
            }
            
            
        }
        //UI更新（X残りの聖水の数）
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
        //最大値に設定
        woter = maxWoter;
        //現在の数値が最大を超えないように
        woter = Mathf.Min(woter, maxWoter);
        //UI更新（X残りの聖水の数）
        holyWoter.text = "x" + woter.ToString();

    }

}
