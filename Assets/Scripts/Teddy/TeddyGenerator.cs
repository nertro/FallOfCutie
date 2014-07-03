using UnityEngine;
using System.Collections;

public class TeddyGenerator : MonoBehaviour {

    private float scale;

    public float maxScale = 2;
    public float minScale = 1;

	void Start () {
        SetScale();
	}
	
	void Update () {
        if (scale != this.transform.localScale.x)
        {
            Grow();
        }
	}

    private void SetScale()
    {
        float f = Random.Range(minScale, maxScale) * 10;
        f = Mathf.Floor(f);
        scale = f / 10;
    }

    private void Grow()
    {
        if (scale < this.transform.localScale.x)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(scale, scale, scale), Time.deltaTime * 2);
        }
        else if (scale > this.transform.localScale.y)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(scale, scale, scale), Time.deltaTime * 2);
        }
    }
}
