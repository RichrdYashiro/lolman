using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    public Color myColor;
    void OnGUI()
    {
        myColor = RGBSlider(new Rect(10, 10, 200, 20), myColor);
    }
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");
        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");
        return rgb;
    }
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        GUI.Label(screenRect, labelText);
        screenRect.x += screenRect.width;
        sliderValue = GUI.HorizontalSlider(screenRect, sliderValue, 0.0f, sliderMaxValue);
        return sliderValue;
    }
}