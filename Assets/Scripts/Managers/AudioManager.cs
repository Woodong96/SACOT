using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource bgmSource; // BGM 재생을 위한 AudioSource
    public AudioSource sfxSource; // 사운드 효과 재생을 위한 AudioSource

    public AudioClip[] bgmClips; // 다양한 상황에서 사용할 BGM 오디오 클립들
    public AudioClip[] sfxClips; // 사운드 효과 오디오 클립들

    private int currentBGMIndex = -1; // 현재 재생 중인 BGM의 인덱스를 추적
    void Awake()
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
    void Start()
    {
        // 초기 BGM 재생
        PlayBGM(0); // 기본적으로 첫 번째 BGM을 재생하도록 설정
    }

    // 특정 상황에 맞는 BGM 재생 함수
    public void PlayBGM(int bgmIndex)
    {
        if (bgmSource != null && bgmClips.Length > bgmIndex && bgmClips[bgmIndex] != null)
        {
            if (currentBGMIndex == bgmIndex) return; // 이미 같은 BGM이 재생 중이면 종료

            bgmSource.clip = bgmClips[bgmIndex];
            bgmSource.loop = true; // 루프 재생 설정
            bgmSource.Play();

            currentBGMIndex = bgmIndex; // 현재 재생 중인 BGM 인덱스를 업데이트
        }
    }

    // 특정 상황에서 사운드 효과 재생 함수
    public void PlaySFX(int sfxIndex)
    {
        if (sfxSource != null && sfxClips.Length > sfxIndex && sfxClips[sfxIndex] != null)
        {
            sfxSource.PlayOneShot(sfxClips[sfxIndex]);
        }
    }

    // BGM 정지 함수 (필요 시 사용)
    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
            currentBGMIndex = -1; // BGM 인덱스 초기화
        }
    }
}
