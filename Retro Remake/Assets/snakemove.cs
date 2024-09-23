using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakemove : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;


    private void Start()
    {
        _segments = new()
        {
            this.transform
        };

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
        {
            _direction = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right) 
        {
            _direction = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up) 
        {
            _direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left) 
        {
            _direction = Vector2.right;
        }
            
    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
   
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            Grow();
        }
        if (collision.gameObject.tag == "wall")
        {
            _segments[0].transform.position = new Vector2(0, 0);
            
            for (int i = 1; i < _segments.Count; i++)
            {
                var segment = _segments[i];
 
           

                GameObject.Destroy(segment.gameObject);
            }

            _segments.Clear();
            _segments.Add(this.transform);
        }
    }
}
