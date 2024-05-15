using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTanghulu : MonoBehaviour
{
    public GameObject[] Fruits;
    public GameObject[] Points;
    public int FuritsIndex;
    public PlayerController controller;

    void OnMakeQ()
    {
        if (controller.CanMake == true)
        {
            if (FuritsIndex <= 4)
            {
                SpawnFruits(0, FuritsIndex);
                FuritsIndex++;
            }
            
        }
        

    }

    void OnMakeW()
    {
        if (controller.CanMake == true)
        {
            if (FuritsIndex <= 4)
            {
                SpawnFruits(1, FuritsIndex);
                FuritsIndex++;
            }
                
        }
            
    }
    void OnMakeE()
    {
        if (controller.CanMake == true)
        {
            if (FuritsIndex <= 4)
            {
                SpawnFruits(2, FuritsIndex);
                FuritsIndex++;
            }
                
        }

    }

    void OnMakeR()
    {
        if (controller.CanMake == true)
        {
            if (FuritsIndex <= 4)
            {
                SpawnFruits(3, FuritsIndex);
                FuritsIndex++;
            }
               

        }
    }


    void OnMakeT()
    {
        if (controller.CanMake == true)
        {
            if (FuritsIndex <= 4)
            {
                SpawnFruits(4, FuritsIndex);
                FuritsIndex++;
            }
                
        }
    }

    public void SpawnFruits(int _Fruits, int _positionNum)
    {

        Vector3 _position = Points[_positionNum].transform.position;
        Instantiate(Fruits[_Fruits], _position, Quaternion.identity);

    }
    
}
