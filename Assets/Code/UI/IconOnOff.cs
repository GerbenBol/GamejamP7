using UnityEngine;
using UnityEngine.UI;

public class IconOnOff : MonoBehaviour
{
    [SerializeField] private Image uiSplitShot;
    [SerializeField] private Image uiHeal;
    [SerializeField] private Image uiBanzai;
    [SerializeField] private Image uiSpeed;
    [SerializeField] private Image uiPiercing;
    [SerializeField] private Image uiRapidfire;
    [SerializeField] private Image uiLifesteal;

    public void SplitShot(bool onOff)
    {
        Color c = uiSplitShot.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiSplitShot.color = c;
    }

    public void Heal(bool onOff)
    {
        Color c = uiHeal.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiHeal.color = c;
    }

    public void Banzai(bool onOff)
    {
        Color c = uiBanzai.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiBanzai.color = c;
    }

    public void Speed(bool onOff)
    {
        Color c = uiSpeed.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiSpeed.color = c;
    }

    public void Piercing(bool onOff)
    {
        Color c = uiPiercing.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiPiercing.color = c;
    }

    public void Rapidfire(bool onOff)
    {
        Color c = uiRapidfire.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiRapidfire.color = c;
    }

    public void Lifesteal(bool onOff)
    {
        Color c = uiLifesteal.color;

        if (onOff)
            c.a = 1;
        else
            c.a = .19607f;

        uiLifesteal.color = c;
    }
}
