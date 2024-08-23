using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    public CustomerController customercontroller;
    public CustomerManager customermanager;
    public string[] _FruitsName;
    public string _Fruit;

    public void Start()
    {
        _FruitsName = new string[5];
        
    }
    void OnMakeQ()
    {
        _Fruit = "Q";
        MakeFruit(0);
    }

    void OnMakeW()
    {
        _Fruit = "W";
        MakeFruit(1);
    }

    void OnMakeE()
    {
        _Fruit = "E";
        MakeFruit(2);
    }

    void OnMakeR()
    {
        _Fruit = "R";
        MakeFruit(3);
    }

    void OnMakeT()
    {
        _Fruit = "T";
        MakeFruit(4);
    }

    void MakeFruit(int fruitType)
    {
        if (controller.CanMake && FruitsIndex <= 4)
        {
            SpawnFruits(fruitType, FruitsIndex);

            _FruitsName[FruitsIndex] = _Fruit;

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
        // 두 배열의 내용을 비교합니다.

        if (GameManager.Instance.FirstCustomer.GetComponent<CustomerController>().FruitsName.SequenceEqual(_FruitsName))
        {
            for (int i = 0; i < FruitsIndex; i++)
            {
                Destroy(FruitswithStick[i]);
                Destroy(Tanghulu[i]);
            }

            _FruitsName = new string[5];  // 배열의 크기를 초기 크기로 재설정합니다.
            FruitsIndex = 0;
            GameManager.Instance.GameScore += 100;
            GameManager.Instance.ChangeFirstCustomer();
            if (GameManager.Instance.Customer[0] == null)
            {
                PlayerFaceManager.Instance.NiceFace(true);
                GameManager.Instance.GameScore += 20;
                GameManager.Instance.CurrentTime += 20f;
                Time.timeScale += 0.3f;
                AudioManager.Instance.PlaySFX(0);

            }
        }
        else
        {
            for (int i = 0; i < FruitsIndex; i++)
            {
                Destroy(FruitswithStick[i]);
                Destroy(Tanghulu[i]);
            }
            _FruitsName = new string[5];  // 배열의 크기를 초기 크기로 재설정합니다.
            FruitsIndex = 0;
            GameManager.Instance.GameScore -= 50;
            GameManager.Instance.CurrentTime -= 0.5f;
            GameManager.Instance.ChangeFirstCustomer();
            PlayerFaceManager.Instance.SadFace(true);
            Time.timeScale += 0.5f;
            AudioManager.Instance.PlaySFX(1);
        }
    }
   

    private void Update()
    {
        for (int i = 0; i < FruitsIndex; i++)
        {
            Tanghulu[i].GetComponent<Transform>().position = TanghuluPoints[i].GetComponent<Transform>().position;
        }
    }
}
