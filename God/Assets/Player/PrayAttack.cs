using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PrayAttack : MonoBehaviour
{
    [SerializeField]
    GameObject attackobj;

    [Header("�X�^�~�i�����")]
    [SerializeField]
    float cost;

    GameObject pray;

    [SerializeField]
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        cost = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<PlayerParameter>().Stamina >= cost)
            {
                //GetComponent<PlayerParameter>().Stamina -= cost;

                //�I�u�W�F�N�g����
                pray = Instantiate(attackobj, transform.position, Quaternion.identity);

                //// Cylinder�̐���
                //pray = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                //pray.transform.position = transform.position;
                //pray.transform.localScale = new Vector3(8, 1.5f, 8);

                //// Collider�I�u�W�F�N�g�̕`��͕s�v�Ȃ̂�Renderer������
                ////Destroy(pray.GetComponent<MeshRenderer>());
                //pray.GetComponent<MeshRenderer>().material = mat;

                //// ���X���݂���Collider���폜
                //Collider[] colliders = pray.GetComponents<Collider>();
                //for (int i = 0; i < colliders.Length; i++)
                //{
                //    Destroy(colliders[i]);
                //}

                //// ���b�V���̖ʂ��t�ɂ��Ă���MeshCollider��ݒ�
                ////var mesh = pray.GetComponent<MeshFilter>().mesh;
                ////mesh.triangles = mesh.triangles.Reverse().ToArray();
                //pray.AddComponent<MeshCollider>();

                //pray.GetComponent<MeshCollider>().convex = true;

                //pray.tag = "Pray";

                //

            }
        }

        if (Input.GetMouseButton(0))
        {
            if(GetComponent<PlayerParameter>().Stamina >= cost && pray != null)
            {
                GetComponent<PlayerParameter>().Stamina -= cost;
                pray.transform.position = transform.position;
            }

            if(GetComponent<PlayerParameter>().Stamina < cost && pray != null)
            {
                Destroy(pray);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (pray != null)
            {
               Destroy(pray);
            }
        }



    }
}
