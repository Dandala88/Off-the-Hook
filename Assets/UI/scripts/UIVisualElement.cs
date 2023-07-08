using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UIVisualElement : MonoBehaviour
{
  private VisualElement element;
  public string elementId;

  public void OnEnable()
  {
    var uiDocument = GetComponent<UIDocument>() ?? GetComponentInParent<UIDocument>();

    element = uiDocument.rootVisualElement.Q(elementId);
  }

  public void ShowElement(bool show)
  {
    if (show)
    {
      element.style.display = DisplayStyle.Flex;
    }
    else
    {
      element.style.display = DisplayStyle.None;
    }
  }
}
