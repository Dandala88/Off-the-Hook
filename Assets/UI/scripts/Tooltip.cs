using UnityEngine;
using UnityEngine.UIElements;

public class Tooltip : MonoBehaviour
{
    public string elementId, tooltipText;
    Label tooltipLabel;
    private VisualElement tooltipRoot, element;

    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        UIDocument uiDocument = GetComponent<UIDocument>();

        element = uiDocument.rootVisualElement.Q(elementId) as VisualElement;

        element.RegisterCallback<MouseEnterEvent>(ShowToolTip);
        element.RegisterCallback<MouseLeaveEvent>(HideToolTip);
        tooltipRoot = Resources.Load<VisualTreeAsset>("PlanetDesc").Instantiate();
        tooltipRoot.style.display = DisplayStyle.None;
        tooltipRoot.style.position = Position.Absolute;

        //TODO: Make darker
        tooltipRoot.style.backgroundColor = new StyleColor(new Color(57/255, 57/255, 57/255, .75f));

        tooltipLabel = tooltipRoot.Q("Bounty") as Label;
        tooltipLabel.style.fontSize = 18;
        tooltipLabel.text = tooltipText;
        
        uiDocument.rootVisualElement.Add(tooltipRoot);
    }

    void OnDisable() {
        element.UnregisterCallback<MouseEnterEvent>(ShowToolTip);
        element.UnregisterCallback<MouseLeaveEvent>(HideToolTip);
    }

    void ShowToolTip(MouseEnterEvent evt) {
        tooltipRoot.style.display = DisplayStyle.Flex;
    }

    void HideToolTip(MouseLeaveEvent evt) {
        tooltipRoot.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        tooltipRoot.style.top = Screen.height - Input.mousePosition.y + 1;
        tooltipRoot.style.left = Input.mousePosition.x + 1;
    }
}
