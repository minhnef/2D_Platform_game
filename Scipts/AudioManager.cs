using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgAudioSource;
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioClip bgClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playBGMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playBGMusic()
    {
        bgAudioSource.clip = bgClip;
        bgAudioSource.Play();
    }
    public void playCoinSound()
    {
        effectAudioSource.PlayOneShot(coinClip);
    }
    public void playJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpClip);
    }

}
