using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private float baseSpeed = 0f;

    private void Start() 
    {
        baseSpeed = speed;
    }

    private void Update() 
    {
        speed = baseSpeed * TimeManagerScript.TimeScale;
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
