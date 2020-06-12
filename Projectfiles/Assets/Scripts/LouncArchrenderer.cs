using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouncArchrenderer : MonoBehaviour {


    LineRenderer lr;

    public float velocity = 40;
    public float angle;
    public int resolution = 10;

    float kulma;
    float kulmaRad;
    float g;
    float radianAngle;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }

    private void OnValidate()
    {
        if (lr != null && Application.isPlaying) {
            RenderArc();
        }

    }

    // Use this for initialization
    void Start () {
        RenderArc();
        GameObject thePlayer = GameObject.Find("Player");
        Touch2 touch2 = thePlayer.GetComponent<Touch2>();


        //kulmaRad = touch2.kulmaRad;
        //kulma = touch2.kulma;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RenderArc()
    {
        lr.positionCount = resolution;
        lr.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        kulmaRad = Mathf.Deg2Rad * kulma;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * kulmaRad)) / g;


        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance) {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(kulmaRad) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(kulmaRad) * Mathf.Cos(kulmaRad)));

        return new Vector3 (x, y);
    }

}

