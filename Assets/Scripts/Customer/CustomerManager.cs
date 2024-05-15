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
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;


        if (currTime > 5)
        {
            Vector3 _position = CustomerPoints.transform.position;
            GameObject customer = Instantiate(Customer, _position, Quaternion.identity);
            currTime = 0;
        }
    }
}
