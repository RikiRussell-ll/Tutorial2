using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript3 : MonoBehaviour
{
     Vector3 GoDown = new Vector3(54, -1, 0);
     Vector3 GoUp = new Vector3(56, -1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                 transform.position = Vector3.Lerp(GoDown, GoUp, Mathf.PingPong(Time.time, 1));
    }
}
