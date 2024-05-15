using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public int speed;
    public int FruitsCount;
    public int[] FruitsType;
    public TextMeshPro Want;
    public string[] FruitsName;
    void Start()
    {
        FruitsCount = Random.Range(1, 6);
        for (int i = 0; i < FruitsCount; i++)
        {
            FruitsType[i] = Random.Range(0, 5);

        }
        for (int i = 0; i < FruitsCount; i++)
        {
            switch (FruitsType[i])
            {
                case 0:
                    FruitsName[i] = "Q";
                    break;
                case 1:
                    FruitsName[i] = "W";
                    break;
                case 2:
                    FruitsName[i] = "E";
                    break;
                case 3:
                    FruitsName[i] = "R";
                    break;
                case 4:
                    FruitsName[i] = "T";
                    break;
            }
        }
        UpdateWantText();
    }

       
        void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
      

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            speed = 0;

        }

    }

    private void UpdateWantText()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < FruitsCount; i++)
        {
            sb.Append(FruitsName[i]);
            if (i < FruitsCount - 1)
            {
                sb.Append(", ");
            }
        }
        Want.text = sb.ToString();
    }
}
