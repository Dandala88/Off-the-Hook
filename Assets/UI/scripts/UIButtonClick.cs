using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIButtonClick : MonoBehaviour
{
  private Button button;
  public string buttonId;
  public UnityEvent OnClick;
  private AudioSource audioSource;

  void Start()
  {
    if (OnClick == null)
      OnClick = new UnityEvent();

    audioSource = GetComponent<AudioSource>();
  }

  private void OnEnable()
  {
    // The UXML is already instantiated by the UIDocument component
    var uiDocument = GetComponent<UIDocument>() ?? GetComponentInParent<UIDocument>();

    button = uiDocument.rootVisualElement.Q(buttonId) as Button;

    button.RegisterCallback<ClickEvent>(OnButtonClick);
  }

  private void OnDisable()
  {
    button.UnregisterCallback<ClickEvent>(OnButtonClick);
  }

  private void OnButtonClick(ClickEvent evt)
  {
    if (audioSource != null)
      audioSource.PlayOneShot(audioSource.clip);
    OnClick.Invoke();
  }

  public void ChangeButtonColor(Color color)
  {
    Debug.Log(color);
    button.style.backgroundColor = new StyleColor(color);
  }
}