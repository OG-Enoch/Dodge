using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public int explosionForce = 50;
    public float explosionRadius = 4f;
    public float explosionUpwards = 0.4f;
    float cubePivotDistance;
    private Color ballColor;
    private Color randomColor;
    private float colorPanel1, colorPanel2, colorPanel3;

    Vector3 cubePivot;
    // Start is called before the first frame update
    void Start()
    {
        cubePivotDistance = cubeSize * cubesInRow / 2;
        cubePivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);
        ballColor = gameObject.GetComponent<Renderer>().material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Explode();
        }
    }
    public void Explode()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);

        for(int x = 0; x < cubesInRow; x++)
        {
            for(int y = 0; y < cubesInRow; y++)
            {
                for(int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpwards);
            }
        }
    }

    void CreatePiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Set piece position and Scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubePivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        piece.AddComponent<Renderer>();
        piece.GetComponent<Renderer>().material.color = RandomColor();
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
    }
    private Color RandomColor()
	{
		/*if (beatColors == null || beatColors.Length == 0) return Color.white;
		m_randomIndx = Random.Range(0, beatColors.Length);
		return beatColors[m_randomIndx];*/
        colorPanel1 = Random.Range(0f, 1f);
        colorPanel2 = Random.Range(0f, 1f);
        colorPanel3 = Random.Range(0f, 1f);
        
        return randomColor = new Color(colorPanel1, colorPanel2, colorPanel3, 1f);
	}
}
