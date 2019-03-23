using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSky : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float rand_sky = Random.Range(0.0f, 1.0f);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(rand_sky, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
