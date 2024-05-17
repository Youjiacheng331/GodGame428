using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWater : MonoBehaviour
{
    [SerializeField]
    GameObject waterobj;

    GameObject Maincamera;

    // Start is called before the first frame update
    void Start()
    {
        Maincamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (GetComponent<PlayerParameter>().Water > 0)
            {
                //ê∂ê¨èàóù

                GameObject water = Instantiate(waterobj, transform.position, Quaternion.identity);

                Vector3 forward = Maincamera.transform.forward;

                water.GetComponent<Rigidbody>().AddForce(forward * 500.0f);

                //

                GetComponent<PlayerParameter>().Water--;
            }
        }
    }
}
