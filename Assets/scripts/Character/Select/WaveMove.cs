using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveMove : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI amountDisplay;
    [SerializeField]
    float cycle;
    [SerializeField]
    float speed;
    [SerializeField]
    float fullY;
    [SerializeField]
    float zeroY;
    [SerializeField]
    float amount;

    private RectTransform rectTransform;
    private float startX;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        startX = rectTransform.anchoredPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        amount = Mathf.Clamp01(amount);
        var pos = rectTransform.anchoredPosition;

        pos.x += Time.deltaTime * speed;
        if(rectTransform.anchoredPosition.x > startX + cycle) {
            pos.x = startX;
            rectTransform.anchoredPosition = pos;
        }

        pos.y = zeroY + (fullY - zeroY) * amount;
        rectTransform.anchoredPosition = pos;

        amountDisplay.text = string.Format("{0}%", (int)(amount * 100));
    }

    public void SetAmount(float amount) {
        this.amount = Mathf.Clamp01(amount);
    }
}
