using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour {

    public float scrollSpeed;
    public float tilesizeZ;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tilesizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
