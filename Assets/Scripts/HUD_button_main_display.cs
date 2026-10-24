using UnityEngine;
using UnityEngine.UIElements;
public class HUD_button_main_display : MonoBehaviour
{
    public Hide_floors floorHider;
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var button = new Button(() => floorHider.ShowAllFloors());
        button.text = "Кнопка";
        button.name = "my-hud-button";

        // Размер и позиция
        button.style.fontSize = 32; // значение в пикселях
        button.style.width = 200;
        button.style.height = 100;
        button.style.position = Position.Absolute;
        button.style.left = 50;
        button.style.top = 100;
        button.style.backgroundColor = Color.clear;
        button.style.borderTopWidth = 0;
        button.style.borderBottomWidth = 0;
        button.style.borderLeftWidth = 0;
        button.style.borderRightWidth = 0;

        // Фоновое изображение (загружается из папки Resources)
        var bg = Resources.Load<Texture2D>("ButtonsStyle1_01");
        if (bg != null)
            button.style.backgroundImage = new StyleBackground(bg);

        root.Add(button);
    }
}
