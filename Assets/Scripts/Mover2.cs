using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{
    Vector3 startA = new Vector3(42.0f, 0.5f, -5.0f);
    Vector3 endA = new Vector3(58.0f, 0.5f, -5.0f);

    void Update()
    {
        transform.position = Vector3.Lerp(startA, endA, Mathf.PingPong(Time.time, 1));
    }
}
