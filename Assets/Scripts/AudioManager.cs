using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton ������ ����Ͽ� �������� ���� �����ϵ��� ��

    public AudioSource audioSource; // ���� ��� ���� AudioSource
    public AudioClip introAndMainMusic; // Intro Scene�� Main Scene���� ����� ��� ����
    public AudioClip gameClearMusic; // GameClear Scene���� ����� ��� ����
    public AudioClip gameOverMusic; // GameOver Scene���� ����� ��� ����
    float fadeDuration = 2.0f; // ���̵�ƿ�� �ɸ��� �ð�

    void Awake()
    {
        // Singleton ���� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Intro Scene�� Main Scene���� ����� ��� ���� �÷���
    public void PlayIntroAndMainMusic()
    {
        StartCoroutine(ToIntroMusic());
    }

    // GameClear Scene���� ����� ��� ���� �÷���
    public void PlayGameClearMusic()
    {
        StartCoroutine(ToGameClearMusic());
    }

    // GameOver Scene���� ����� ��� ���� �÷���
    public void PlayGameOverMusic()
    {
        StartCoroutine(ToGameOverMusic());
    }

    // ��� ���� �÷���
    void PlayMusic(AudioClip clip, bool loop)
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    // ���� ��� ���� ��� ���� ����
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void FadeOutMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            StartCoroutine(FadeOut(audioSource, fadeDuration));
        }
    }

    // ���̵�ƿ� �ڷ�ƾ
    IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume; // �ʱ� �������� ����
    }

    IEnumerator ToGameOverMusic()
    {
        FadeOutMusic();
        yield return new WaitForSeconds(2.0f);
        PlayMusic(gameOverMusic, true);
    }
    IEnumerator ToGameClearMusic()
    {
        FadeOutMusic();
        yield return new WaitForSeconds(2.0f);
        PlayMusic(gameClearMusic, true);
    }
    IEnumerator ToIntroMusic()
    {
        FadeOutMusic();
        yield return new WaitForSeconds(2.0f);
        PlayMusic(introAndMainMusic, true);
    }
}