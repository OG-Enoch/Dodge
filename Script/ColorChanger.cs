using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public Text obj;
    private Color objectColor;
    private float colorPanel1, colorPanel2, colorPanel3; 
    // Start is called before the first frame update
    void Start()
    {
        obj = obj.GetComponent<Text>();
        //gameObject.GetComponent<Button>().onClick.AddListener(ColorChange);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("ChangeColor");
    }
    private Color ColorChange()
    {
        colorPanel1 = Random.Range(0f, 1f);
        colorPanel2 = Random.Range(0f, 1f);
        colorPanel3 = Random.Range(0f, 1f);
        
        /*var intensity = objRenderer.material.GetColor("_Color") / 3f;
        var factor = intensity;*/
        objectColor = new Color(colorPanel1, colorPanel2, colorPanel3, 1f);

        return obj.color = objectColor;

        //objRenderer.material.SetColor("_Color", objectColor);
    }
    private IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(10f);
        ColorChange();
    }
}
