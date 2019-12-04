using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEnable : MonoBehaviour
{
    Text InstText;
    public float speed = 1.0f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        InstText = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        InstText.color = GetAlphaColor(InstText.color);
    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;
    }

}
