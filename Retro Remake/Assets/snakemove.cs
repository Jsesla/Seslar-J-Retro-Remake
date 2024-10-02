using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class snakemove : MonoBehaviour
{
    //queue stores like a line can strictly only access the next element
    private Queue<Vector2> _direction = new();
    private Vector2 _currentDirection;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int maxbuffer = 2;


    private void Start()
    {
        _segments = new()
        {
            this.transform
        };

        _direction.Enqueue(Vector2.right);
        //stores current direction to set up default direction
        _currentDirection = _direction.Peek();
    }

    private void Update()
    {
        Vector2 nextDirection = default;
        if (_direction.Count > 0)
            nextDirection = _direction.Peek();
        else
            nextDirection = _currentDirection;
        if (_direction.Count > maxbuffer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) && nextDirection != Vector2.down)
        {
            _direction.Enqueue(Vector2.up);
            
        }
        if (Input.GetKeyDown(KeyCode.A) && nextDirection != Vector2.right) 
        {
            _direction.Enqueue(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.S) && nextDirection != Vector2.up) 
        {
            _direction.Enqueue(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.D) && nextDirection != Vector2.left) 
        {
            _direction.Enqueue(Vector2.right);
        }

    }
    private void FixedUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        if (_direction.Count > 0)
            _currentDirection = _direction.Dequeue();

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _currentDirection.x,
            Mathf.Round(this.transform.position.y) + _currentDirection.y,
            0.0f
        );
    }
   
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        Particooolss.TargetPosition = segment;
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
