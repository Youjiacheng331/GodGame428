using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject explode; // Reference to the explosion prefab


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Instantiate(explode, collision.contacts[0].point, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pray" || other.gameObject.tag == "Water")
        {
            Instantiate(explode, other.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("hit");
        }
    }
}
