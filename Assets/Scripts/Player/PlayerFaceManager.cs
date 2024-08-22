using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceManager : MonoBehaviour
{
    public static PlayerFaceManager Instance { get; private set; }
    public GameObject _Normalface;
    public GameObject _SadFace;
    public GameObject _NiceFace;
    private Coroutine _currentCoroutine; // 현재 실행 중인 코루틴을 추적하기 위한 변수
    private string _currentFaceState = "Normal"; // 현재 활성화된 얼굴 상태를 추적
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
        // 새로운 상태가 이전 상태와 다르면 기존 코루틴 중지
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
        // 새로운 상태가 이전 상태와 다르면 기존 코루틴 중지
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

        _currentFaceState = "Normal"; // 상태를 Normal로 리셋
        _currentCoroutine = null; // 코루틴 초기화
    }

}
