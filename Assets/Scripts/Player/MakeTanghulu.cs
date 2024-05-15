using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTanghulu : MonoBehaviour
{
    public GameObject[] Fruits;
    public GameObject[] Points;
    public int FruitsIndex;
    public PlayerController controller;
    public GameObject[] FruitswithStick;
    void OnMakeQ()
    {
        MakeFruit(0);
    }

    void OnMakeW()
    {
        MakeFruit(1);
    }

    void OnMakeE()
    {
        MakeFruit(2);
    }

    void OnMakeR()
    {
        MakeFruit(3);
    }

    void OnMakeT()
    {
        MakeFruit(4);
    }

    void MakeFruit(int fruitType)
    {
        if (controller.CanMake && FruitsIndex <= 4)
        {
            SpawnFruits(fruitType, FruitsIndex);
            FruitsIndex++;
        }
    }

    void OnBeforeBehavior()
    {
        for (int i = 0; i < FruitsIndex; i++)
        {
            Destroy(FruitswithStick[i]);
        }
        FruitsIndex = 0;

    }

    public void SpawnFruits(int _Fruits, int _positionNum)
    {

        Vector3 _position = Points[_positionNum].transform.position;
        FruitswithStick[FruitsIndex] = Instantiate(Fruits[_Fruits], _position, Quaternion.identity);

    }
    
}
