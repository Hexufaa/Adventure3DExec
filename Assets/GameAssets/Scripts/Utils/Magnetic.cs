using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public float dist = 1f;
    public float coinSpeed = 3f;
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerControllerTurning.Instance.transform.position) > dist)
        {
            coinSpeed++;
            transform.position = Vector3.MoveTowards(transform.position, PlayerControllerTurning.Instance.transform.position, Time.deltaTime * coinSpeed);

        }
    }
}
