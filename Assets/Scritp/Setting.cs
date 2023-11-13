using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public void Low()
    {
        QualitySettings.SetQualityLevel(1,true);
    }
    public void Meduim()
    {
        QualitySettings.SetQualityLevel(2, true);
    }
    public void High()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    public void VeryHigh()
    {
        QualitySettings.SetQualityLevel(4, true);
    }
    public void Ultra()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
}
