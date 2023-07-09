using UnityEngine;

public class AudioController : MonoBehaviour
{
  float volume = 1f;
  public float defaultVolume = 1f;
  public AudioSource audioSource;
  // Start is called before the first frame update
  void OnEnable()
  {
    audioSource.volume = PlayerPrefs.GetFloat("volume", defaultVolume);
  }

  public float getVolume()
  {
    return audioSource.volume;
  }

  public void setVolume(float volume)
  {
    audioSource.volume = volume;
    PlayerPrefs.SetFloat("volume", volume);
  }
}
