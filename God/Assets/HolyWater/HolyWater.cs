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
        //¹…”j—ô(ˆê’è”ÍˆÍ)
        GameObject boom= Instantiate(waterboom, transform.position, Quaternion.identity);

        Destroy(boom, 3.0f);

        //¹…(‚Ì•r)Á–Å
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //—H—ì‚É“–‚½‚Á‚½‚ç




        //‚»‚Ì‘¼‚É“–‚½‚Á‚½‚ç



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
