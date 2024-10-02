using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particooolss : MonoBehaviour
{
    public static Transform TargetPosition;
    public static Transform NextTarget;
    public float speed;
    public float MinDis;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, TargetPosition.position, Time.deltaTime * speed);
        if(Vector2.Distance(transform.position, TargetPosition.position) < MinDis) //checks if the distance is less than 0.5
        {
            TargetPosition = NextTarget;
            transform.position = TargetPosition.position + offset;
            gameObject.SetActive(false);
        }
    }
}
