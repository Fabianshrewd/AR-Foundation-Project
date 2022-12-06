using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private GameObject object1;
    private Button btn1;
    private Button btn2;

    // Start is called before the first frame update
    private void OnEnable()
    {
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        btn1 = rootVisualElement.Q<Button>("BUTTON-START");
        btn1.RegisterCallback<ClickEvent>(ev => Destroying());
        btn2 = rootVisualElement.Q<Button>("BUTTON-STOP");
        btn2.RegisterCallback<ClickEvent>(ev => Quitting());
    }

    private void Destroying()
    {
        object1 = GameObject.Find("UIDocument");
        Destroy(object1);
    }

    private void Quitting()
    {
        Application.Quit();
    }
}
