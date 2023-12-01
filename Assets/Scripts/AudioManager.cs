using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton 패턴을 사용하여 전역에서 접근 가능하도록 함

    public AudioSource audioSource; // 현재 재생 중인 AudioSource
    public AudioClip introAndMainMusic; // Intro Scene과 Main Scene에서 사용할 배경 음악
    public AudioClip gameClearMusic; // GameClear Scene에서 사용할 배경 음악
    public AudioClip gameOverMusic; // GameOver Scene에서 사용할 배경 음악
    float fadeDuration = 2.0f; // 페이드아웃에 걸리는 시간

    void Awake()
    {
        // Singleton 패턴 구현
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Intro Scene과 Main Scene에서 사용할 배경 음악 플레이
    public void PlayIntroAndMainMusic()
    {
        StartCoroutine(ToIntroMusic());
    }

    // GameClear Scene에서 사용할 배경 음악 플레이
    public void PlayGameClearMusic()
    {
        StartCoroutine(ToGameClearMusic());
    }

    // GameOver Scene에서 사용할 배경 음악 플레이
    public void PlayGameOverMusic()
    {
        StartCoroutine(ToGameOverMusic());
    }

    // 배경 음악 플레이
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

    // 현재 재생 중인 배경 음악 정지
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

    // 페이드아웃 코루틴
    IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume; // 초기 볼륨으로 설정
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