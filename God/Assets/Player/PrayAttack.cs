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
    GameObject pray2;

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

                // Cylinder�̐���
                pray2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                pray2.transform.position = transform.position;
                pray2.transform.localScale = new Vector3(7, 2, 7);

                // Collider�I�u�W�F�N�g�̕`��͕s�v�Ȃ̂�Renderer������
                //Destroy(pray.GetComponent<MeshRenderer>());
                pray2.GetComponent<MeshRenderer>().material = mat;

                // ���X���݂���Collider���폜
                Collider[] colliders = pray2.GetComponents<Collider>();
                for (int i = 0; i < colliders.Length; i++)
                {
                    colliders[i].isTrigger = true;
                }

                //���b�V���̖ʂ��t�ɂ��Ă���MeshCollider��ݒ�
                var mesh = pray2.GetComponent<MeshFilter>().mesh;
                mesh.triangles = mesh.triangles.Reverse().ToArray();






                //

            }
        }

        if (Input.GetMouseButton(0))
        {
            if(GetComponent<PlayerParameter>().Stamina >= cost && pray != null)
            {
                GetComponent<PlayerParameter>().Stamina -= cost;
                pray.transform.position = transform.position;
                if (pray2 != null)
                {
                    pray2.transform.position = transform.position;
                }
            }

            if(GetComponent<PlayerParameter>().Stamina < cost && pray != null)
            {
                Destroy(pray);
                if (pray2 != null)
                {
                    Destroy(pray2);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (pray != null)
            {
               Destroy(pray);
            }
            if (pray2 != null)
            {
                Destroy(pray2);
            }
        }



    }
}
