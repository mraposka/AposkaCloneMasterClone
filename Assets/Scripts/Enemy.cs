using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject clonePrefab;
    [Range(0f, 1f)] public float distanceClone, radius;
    void Start()
    {
        int random = Random.Range(0, 100);
        Debug.Log(random.ToString());
        for (int i = 0; i < random; i++)
            Instantiate(clonePrefab, new Vector3(transform.position.x + 0.1f, 0f, transform.position.z + 0.5f), Quaternion.identity, transform);
        CloneArrange();
    }
    void CloneArrange()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var xPos = distanceClone * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var zPos = distanceClone * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            var newPos = new Vector3(xPos, 0f, zPos);
            if (transform.GetChild(i).name != "Counter") transform.GetChild(i).DOLocalMove(newPos, 0f).SetEase(Ease.OutBack);
        }
    }
}
