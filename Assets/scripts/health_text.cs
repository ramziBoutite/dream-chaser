using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health_text : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    public Vector3 txt_speed = new Vector3(0,75,0);
    RectTransform rectTransform;
    public float time_to_fade;
    private float timer = 0f;
    private Color startcolor;
    private float alpha;

    private void Awake()
    {
        startcolor = Color.red;
        rectTransform   = GetComponent<RectTransform>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha = startcolor.a*(1- timer/time_to_fade);
        timer += Time.deltaTime;
        rectTransform.position += txt_speed * Time.deltaTime;
        if(timer < time_to_fade)
        {
            textMeshProUGUI.color = new Color(startcolor.r,startcolor.g,startcolor.b, alpha);
        }
        else if (timer > time_to_fade)
        {
            Destroy(gameObject);
        }
    }
}
