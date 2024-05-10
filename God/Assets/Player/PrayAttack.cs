using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayAttack : MonoBehaviour
{
    [SerializeField]
    GameObject attackobj;

    [Header("スタミナ消費量")]
    [SerializeField]
    float cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<PlayerParameter>().Stamina >= cost)
            {
                GetComponent<PlayerParameter>().Stamina -= cost;

                //オブジェクト生成

                //

            }
        }
    }
}
