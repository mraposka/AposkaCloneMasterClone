using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
       this.GetComponent<TextMesh>().text= player.transform.childCount.ToString();
    }
}
