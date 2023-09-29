using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public RectTransform LoadingBar;
    public RectTransform Mask;
    public RectTransform Progress;

    private float maxWight;
    private float maxHeight;

    void Start()
    {
        maxWight = Mask.rect.width;
        maxHeight = Mask.rect.height;
    }

    
    public void SetProgressValue(float progress)
    {
        float currentWight= Mathf.Clamp01(progress) * maxWight ;
        Mask.sizeDelta = new Vector2(currentWight, maxHeight);
    }
}
