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
    public GameObject[] TanghuluPoints;
    public GameObject[] Tanghulu;
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
        if (controller.CanMake)
        {
            for (int i = 0; i < FruitsIndex; i++)
            {
                Destroy(FruitswithStick[i]);
            }
            FruitsIndex = 0;
        }
       

    }

    public void SpawnFruits(int _Fruits, int _positionNum)
    {

        Vector3 _position = Points[_positionNum].transform.position;
        Vector3 _position2 = TanghuluPoints[_positionNum].transform.position;
        FruitswithStick[FruitsIndex] = Instantiate(Fruits[_Fruits], _position, Quaternion.identity);
        Tanghulu[FruitsIndex] = Instantiate(Fruits[_Fruits], _position2, Quaternion.identity);
        Tanghulu[FruitsIndex].SetActive(false);
    }

   

    public void SetStickWithTanghulu()
    {
        for (int i = 0; i < FruitsIndex; i++)
        {
            FruitswithStick[i].SetActive(false);
            Tanghulu[i].SetActive(true);
        }
    }
    public void GetPoint()
    {
        

            for (int i = 0; i < FruitsIndex; i++)
            {
                Destroy(FruitswithStick[i]);
                Destroy(Tanghulu[i]);
            }
            FruitsIndex = 0;
        

    }
    private void Update()
    {
        for (int i = 0; i < FruitsIndex; i++)
        {
            Tanghulu[i].GetComponent<Transform>().position = TanghuluPoints[i].GetComponent<Transform>().position;
        }
    }
}
