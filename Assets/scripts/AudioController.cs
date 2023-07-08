using UnityEngine;

public class AudioController : MonoBehaviour
{
  float volume = 1f;
  public float defaultVolume = 1f;
  // Start is called before the first frame update
  void OnEnable()
  {
    volume = PlayerPrefs.GetFloat("volume", defaultVolume);
  }

  public float getVolume()
  {
    return volume;
  }

  public void setVolume(float volume)
  {
    this.volume = volume;
    PlayerPrefs.SetFloat("volume", volume);
  }
}
