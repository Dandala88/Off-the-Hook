using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
  public UIVisualElement bar;

  // Update is called once per frame
  void Update()
  {
    bar.element.style.width = (float)GameManager.Instance.calories / GameManager.Instance.calories;
  }
}
