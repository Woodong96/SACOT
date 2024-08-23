using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioSource bgmSource; // BGM ����� ���� AudioSource
    public AudioSource sfxSource; // ���� ȿ�� ����� ���� AudioSource

    public AudioClip[] bgmClips; // �پ��� ��Ȳ���� ����� BGM ����� Ŭ����
    public AudioClip[] sfxClips; // ���� ȿ�� ����� Ŭ����

    private int currentBGMIndex = -1; // ���� ��� ���� BGM�� �ε����� ����
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
        // �ʱ� BGM ���
        PlayBGM(0); // �⺻������ ù ��° BGM�� ����ϵ��� ����
    }

    // Ư�� ��Ȳ�� �´� BGM ��� �Լ�
    public void PlayBGM(int bgmIndex)
    {
        if (bgmSource != null && bgmClips.Length > bgmIndex && bgmClips[bgmIndex] != null)
        {
            if (currentBGMIndex == bgmIndex) return; // �̹� ���� BGM�� ��� ���̸� ����

            bgmSource.clip = bgmClips[bgmIndex];
            bgmSource.loop = true; // ���� ��� ����
            bgmSource.Play();

            currentBGMIndex = bgmIndex; // ���� ��� ���� BGM �ε����� ������Ʈ
        }
    }

    // Ư�� ��Ȳ���� ���� ȿ�� ��� �Լ�
    public void PlaySFX(int sfxIndex)
    {
        if (sfxSource != null && sfxClips.Length > sfxIndex && sfxClips[sfxIndex] != null)
        {
            sfxSource.PlayOneShot(sfxClips[sfxIndex]);
        }
    }

    // BGM ���� �Լ� (�ʿ� �� ���)
    public void StopBGM()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
            currentBGMIndex = -1; // BGM �ε��� �ʱ�ȭ
        }
    }
}
