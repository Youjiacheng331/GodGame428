using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour
{
    [SerializeField]
    GameObject waterboom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyWater()
    {
        //聖水破裂(一定範囲)
        GameObject boom= Instantiate(waterboom, transform.position, Quaternion.identity);

        Destroy(boom, 3.0f);

        //聖水(の瓶)消滅
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //幽霊に当たったら




        //その他に当たったら



        DestroyWater();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }
}
