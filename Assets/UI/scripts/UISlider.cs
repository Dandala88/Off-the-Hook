using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UISlider : MonoBehaviour
{
  public Slider slider;
  public string sliderId;
  public UnityEvent<float> OnSlide;
  private AudioSource audioSource;

  public float initialValue;

  void Start()
  {
    if (OnSlide == null)
      OnSlide = new UnityEvent<float>();

    audioSource = GetComponent<AudioSource>();
  }

  private void OnEnable()
  {
    // The UXML is already instantiated by the UIDocument component
    var uiDocument = GetComponent<UIDocument>() ?? GetComponentInParent<UIDocument>();

    slider = uiDocument.rootVisualElement.Q(sliderId) as Slider;

    slider.SetValueWithoutNotify(initialValue);

    slider.RegisterCallback<ChangeEvent<float>>(OnSliderChange);
  }

  private void OnDisable()
  {
    slider.UnregisterCallback<ChangeEvent<float>>(OnSliderChange);
  }

  private void OnSliderChange(ChangeEvent<float> evt)
  {
    if (audioSource != null)
      audioSource.PlayOneShot(audioSource.clip);
    OnSlide.Invoke(evt.newValue);
  }
}
