using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWater : MonoBehaviour
{
    [SerializeField]
    GameObject waterobj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetComponent<PlayerParameter>().Water > 0)
            {
                //ê∂ê¨èàóù



                //

                GetComponent<PlayerParameter>().Water--;
            }
        }
    }
}
