using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceManager : MonoBehaviour
{
    public static PlayerFaceManager Instance { get; private set; }
    public GameObject _Normalface;
    public GameObject _SadFace;
    public GameObject _NiceFace;
    private Coroutine _currentCoroutine; // ���� ���� ���� �ڷ�ƾ�� �����ϱ� ���� ����
    private string _currentFaceState = "Normal"; // ���� Ȱ��ȭ�� �� ���¸� ����
    // Start is called before the first frame update
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }


    }





    public void NiceFace(bool Face)
    {
        // ���ο� ���°� ���� ���¿� �ٸ��� ���� �ڷ�ƾ ����
        if (_currentFaceState != "NiceFace" && _currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _NiceFace.SetActive(Face);
        _Normalface.SetActive(!Face);
        _SadFace.SetActive(false);

        _currentFaceState = "NiceFace";
        _currentCoroutine = StartCoroutine(ResetFacesAfterDelay());
    }

    public void SadFace(bool Face)
    {
        // ���ο� ���°� ���� ���¿� �ٸ��� ���� �ڷ�ƾ ����
        if (_currentFaceState != "SadFace" && _currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _SadFace.SetActive(Face);
        _Normalface.SetActive(!Face);
        _NiceFace.SetActive(false);

        _currentFaceState = "SadFace";
        _currentCoroutine = StartCoroutine(ResetFacesAfterDelay());
    }

    private IEnumerator ResetFacesAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        _NiceFace.SetActive(false);
        _SadFace.SetActive(false);
        _Normalface.SetActive(true);

        _currentFaceState = "Normal"; // ���¸� Normal�� ����
        _currentCoroutine = null; // �ڷ�ƾ �ʱ�ȭ
    }

}
