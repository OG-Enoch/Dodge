using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncColorObj : AudioSyncer
{
    
	//public Color[] beatColors;
	public Color restColor;
    private Color objectColor;
    private float colorPanel1, colorPanel2, colorPanel3;

	private int m_randomIndx;
	public GameObject obstacleObject;
    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = obstacleObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
 	public override void OnUpdate()
	{
		base.OnUpdate();

		if (m_isBeat) return;

		objectRenderer.material.color = Color.Lerp(objectRenderer.material.color, restColor, restSmoothTime * Time.deltaTime);
	}

    private IEnumerator MoveToColor(Color _target)
    {
        Color _curr = objectRenderer.material.GetColor("_Color");
		Color _initial = _curr;
		float _timer = 0;
		
		while (_curr != _target)
		{
			_curr = Color.Lerp(_initial, _target, _timer / timeToBeat);
			_timer += Time.deltaTime;

			objectRenderer.material.SetColor("_Color", _curr);
            //_curr = RandomColor();

			yield return null;
		}

		m_isBeat = false;
    }
    public override void OnBeat()
	{
		base.OnBeat();

		Color _c = RandomColor();

		StopCoroutine("MoveToColor");
		StartCoroutine("MoveToColor", _c);
	}
    private Color RandomColor()
	{
		/*if (beatColors == null || beatColors.Length == 0) return Color.white;
		m_randomIndx = Random.Range(0, beatColors.Length);
		return beatColors[m_randomIndx];*/
        colorPanel1 = Random.Range(0f, 1f);
        colorPanel2 = Random.Range(0f, 1f);
        colorPanel3 = Random.Range(0f, 1f);
        
        var intensity = objectRenderer.material.GetColor("_Color") / 3f;
        var factor = intensity;
        return objectColor = new Color(colorPanel1, colorPanel2, colorPanel3, 1f);

        //objectRenderer.material.SetColor("_Color", objectColor);
	}
}
