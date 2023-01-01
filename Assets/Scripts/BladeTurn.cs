using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTurn : MonoBehaviour
{ 
    void Update()
    {
        if (this.gameObject.name.Contains("Left"))
        {
            this.gameObject.transform.Rotate(0, 300 * Time.deltaTime,0);
        }
        else if (this.gameObject.name.Contains("Right"))
        {
            this.gameObject.transform.Rotate(0, -300 * Time.deltaTime, 0);
        }
    }
}
