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
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine); // ���� �ڷ�ƾ�� ������ ����
        }

        _NiceFace.SetActive(Face);
        _Normalface.SetActive(!Face);

        _currentCoroutine = StartCoroutine(ResetFacesAfterDelay(_NiceFace, _Normalface, Face));
    }

    public void SadFace(bool Face)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine); // ���� �ڷ�ƾ�� ������ ����
        }

        _SadFace.SetActive(Face);
        _Normalface.SetActive(!Face);

        _currentCoroutine = StartCoroutine(ResetFacesAfterDelay(_SadFace, _Normalface, Face));
    }

    private IEnumerator ResetFacesAfterDelay(GameObject face, GameObject normalFace, bool initialState)
    {
        yield return new WaitForSeconds(2f);

        face.SetActive(!initialState);
        normalFace.SetActive(initialState);

        _currentCoroutine = null; // �ڷ�ƾ�� ������ null�� �ʱ�ȭ
    }

}
