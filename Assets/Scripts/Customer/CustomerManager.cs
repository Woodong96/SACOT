using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    float currTime;
    public GameObject Customer;
    public GameObject CustomerPoints;

    void Start()
    {
        GameManager.Instance.Customer = new GameObject[4]; // �迭 �ʱ�ȭ
    }

    void Update()
    {
        currTime += Time.deltaTime;
        if (GameManager.Instance.Customer[3] == null)
        {
            if (GameManager.Instance.CurrentTime < 30)
            {
                SpawnCustomer(1);
            }
            else if(GameManager.Instance.CurrentTime < 60)
            {
                SpawnCustomer(2);
               
            }
            else if(GameManager.Instance.CurrentTime < 100)
            {
                
                SpawnCustomer(3);
                AudioManager.Instance.PlayBGM(1);
            }
            else if (GameManager.Instance.CurrentTime < 3000)
            {
                SpawnCustomer(4);
                
            }


        }


    }
    void SpawnCustomer(float _time)
    {
        if (currTime > _time)
        {
            Vector3 _position = CustomerPoints.transform.position;
            GameObject customer = Instantiate(Customer, _position, Quaternion.identity); // customer ��ü ����

            currTime = 0;

            if (GameManager.Instance.Customer[0] == null)
            {
                GameManager.Instance.Customer[0] = customer; // ���������� ������ ��ü �Ҵ�

            }
            else if (GameManager.Instance.Customer[1] == null)
            {
                GameManager.Instance.Customer[1] = customer;
            }
            else if (GameManager.Instance.Customer[2] == null)
            {
                GameManager.Instance.Customer[2] = customer;
            }
            else if (GameManager.Instance.Customer[3] == null)
            {
                GameManager.Instance.Customer[3] = customer;
            }

        }
    }
}
