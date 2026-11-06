using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour
{
    public Color glowColor = new Color(0.3f, 1f, 0.4f);
    public float intensity = 1.5f;
    public bool hideWhileHolding = false;   // tick this on the balls

    List<Material> mats = new List<Material>();
    List<Color> originalColors = new List<Color>();
    List<bool> originalKeyword = new List<bool>();
    bool on;

    void Awake()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            foreach (Material m in r.materials)
            {
                if (!m.HasProperty("_EmissionColor")) continue;
                mats.Add(m);
                originalColors.Add(m.GetColor("_EmissionColor"));
                originalKeyword.Add(m.IsKeywordEnabled("_EMISSION"));
            }
        }
    }

    public void SetHighlight(bool value)
    {
        if (value == on) return;
        on = value;

        for (int i = 0; i < mats.Count; i++)
        {
            if (on)
            {
                mats[i].EnableKeyword("_EMISSION");
                mats[i].SetColor("_EmissionColor", glowColor * intensity);
            }
            else
            {
                mats[i].SetColor("_EmissionColor", originalColors[i]);
                if (!originalKeyword[i]) mats[i].DisableKeyword("_EMISSION");
            }
        }
    }
    public string promptText = "";
}