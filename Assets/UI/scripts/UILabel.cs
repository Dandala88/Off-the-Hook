using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class UILabel : MonoBehaviour
{
    private Label label;
    public string labelId;
    public string prefix;

    public void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();

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
}
