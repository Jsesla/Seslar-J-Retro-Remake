using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public static Transform TargetPosition;
    public float speed;
    public AudioSource chomp;

    public GameObject Particles;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        // gives particle emitter its next target position
        Particooolss.NextTarget = transform;
        Particles.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
        chomp.Play();
    }
}