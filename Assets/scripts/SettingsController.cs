using UnityEngine;
using UnityEngine.UIElements;

public class SettingsController : MonoBehaviour
{
  public AudioController audioController;
  public UISlider volumeSlider, sensSlider;
  float volume, sense;
  public UIVisualElement settingsContainer;
  public UILabel SaveConfirmation;
  public InputManager inputManager;
  public Toggle invertToggle;

  public void Show()
  {
    var uiDocument = GetComponent<UIDocument>() ?? GetComponentInParent<UIDocument>();
    invertToggle = uiDocument.rootVisualElement.Q("InvertY") as Toggle;

    SaveConfirmation.SetOpacity(0);

    bool invertY;
    if (inputManager)
    {
      sense = InputManager.mouseSensitivity.x;
      invertY = InputManager.invertY;
    }
    else
    {
      sense = PlayerPrefs.GetFloat("mouseSens", 1f);
      invertY = PlayerPrefs.GetInt("invertY", 0) == 1;
    }

    sensSlider.slider.SetValueWithoutNotify(sense * 20f);
    invertToggle.SetValueWithoutNotify(invertY);

    volume = audioController.getVolume();
    volumeSlider.slider.SetValueWithoutNotify(volume * 100);
    settingsContainer.ShowElement(true);
  }

  public void setVolume(float volume)
  {
    this.volume = volume / 100f;
  }

  public void setSense(float sense)
  {
    this.sense = sense / 20f;
  }

  public void WriteSettings()
  {
    audioController.setVolume(volume);

    bool invertY = invertToggle.value;

    PlayerPrefs.SetInt("invertY", invertY ? 1 : 0);
    PlayerPrefs.SetFloat("mouseSens", sense);
    if (inputManager)
    {
      inputManager.ChangeMouseSettings(new Vector2(sense, sense), invertY);
    }
  }
}
