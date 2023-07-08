using UnityEngine;
using UnityEngine.UIElements;

public class UILabel : MonoBehaviour
{
  public Label label;
  public string labelId;
  public string prefix;

  public void OnEnable()
  {
    var uiDocument = GetComponent<UIDocument>() ?? GetComponentInParent<UIDocument>();

    label = uiDocument.rootVisualElement.Q(labelId) as Label;
  }

  public void UpdateLabel(string newValue)
  {
    label.text = prefix + newValue;
  }
  public void UpdateLabel(int newValue)
  {
    label.text = prefix + $"{newValue:n0}";
  }
  public void SetOpacity(float opacity)
  {
    label.style.opacity = opacity;
  }
}
