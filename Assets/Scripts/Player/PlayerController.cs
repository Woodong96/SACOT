using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{

    public GameObject[] PlayerPosition;
    private GameObject Player;
    public int PlayerIndex;
    public PlayerInput playerinput;
    public bool CanMake;
    // Start is called before the first frame update
    private void Start()
    {
        Player = this.gameObject;
        PlayerIndex = 0;
    }

    private void Update()
    {
        if (PlayerIndex == 1)
        {
            CanMake = true;
        }
        else
        {
            CanMake = false;
        }
    }
    void OnNextBehavior()
    {
        if (PlayerIndex <= 1 && PlayerIndex >=0)
        {
            PlayerIndex++;
            transform.position = PlayerPosition[PlayerIndex].GetComponent<Transform>().position;
        }
        else if (PlayerIndex == 2)
             {
                 PlayerIndex = 0;
                 transform.position = PlayerPosition[PlayerIndex].GetComponent<Transform>().position;

             }


    }

    void OnBeforeBehavior()
    {
        if (PlayerIndex <= 2 && PlayerIndex >= 1)
        {
            PlayerIndex--;
            transform.position = PlayerPosition[PlayerIndex].GetComponent<Transform>().position;
        }

        else if (PlayerIndex == 0)
             {
                 PlayerIndex = 2;
                 transform.position = PlayerPosition[PlayerIndex].GetComponent<Transform>().position;

             }



    }
}
