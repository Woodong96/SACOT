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
        GameManager.Instance.Customer = new GameObject[5]; // 배열 초기화
    }

    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > 2)
        {
            Vector3 _position = CustomerPoints.transform.position;
            GameObject customer = Instantiate(Customer, _position, Quaternion.identity); // customer 객체 생성
            
            currTime = 0;

            if (GameManager.Instance.Customer[0] == null)
            {
                GameManager.Instance.Customer[0] = customer; // 프리팹으로 생성된 객체 할당
               
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
            else if (GameManager.Instance.Customer[4] == null)
            {
                GameManager.Instance.Customer[4] = customer;
            }
        }
    }
}
