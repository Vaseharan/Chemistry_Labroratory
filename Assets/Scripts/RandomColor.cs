using UnityEngine;

public class RandomColor : MonoBehaviour
{
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        if (rend != null)
        {
            Color brightColor = Random.ColorHSV(
                0f, 1f,     // Hue (all colors)
                0.4f, 0.8f, // Saturation (avoid too dull / too intense)
                0.8f, 1f    // Value (THIS makes it bright 🔥)
            );

            rend.material.color = brightColor;
        }
    }
}