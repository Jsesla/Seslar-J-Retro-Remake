using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode left = KeyCode.A, right = KeyCode.D, up = KeyCode.W, down = KeyCode.S;
    public float speed = 10;

    private Rigidbody2D _rb; 

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(left))    //PRESS A TO MOVE LEFT 
        {
            _rb.velocity = Vector2.left * speed;
        }
        if (Input.GetKey(right))    //PRESS D TO MOVE RIGHT
        {
            _rb.velocity = Vector2.right * speed;
        }
        if (Input.GetKey(up))    //PRESS W TO MOVE UP
        {
            _rb.velocity = Vector2.up * speed;
        }
        if (Input.GetKey(down))    //PRESS S TO MOVE DOWN
        {
            _rb.velocity = Vector2.down * speed;
        }
    }
}
//GetKeyDown detects tapping