using UnityEngine;

public class SettingsController : MonoBehaviour
{
  public AudioController audioController;
  public UISlider volumeSlider;
  float volume;
  public UIVisualElement settingsContainer;
  public UILabel SaveConfirmation;

  public void Show()
  {
    SaveConfirmation.SetOpacity(0);
    volume = audioController.getVolume() * 100;
    volumeSlider.slider.SetValueWithoutNotify(volume);
    settingsContainer.ShowElement(true);
  }

  public void setVolume(float volume)
  {
    this.volume = volume / 100f;
  }

  public void WriteSettings()
  {
    audioController.setVolume(volume);
  }
}
