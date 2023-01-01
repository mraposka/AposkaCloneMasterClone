using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using System.Linq;
using DG.Tweening;

public class MovementController : MonoBehaviour
{
    [SerializeField] SwipeListener SL;
    public Camera cam;
    public GameObject clonePrefab;
    public float timeLeft = 0.5f;
    public float moveForwardSpeed;
    public float swipeSpeed;
    public bool cooldown = false;
    bool move;
    string swipeSide;
    Vector3 mouseStartPos, playerStartPos;
    [Range(0f, 1f)] public float distanceClone, radius;
    private void OnEnable()
    {
        SL.OnSwipe.AddListener(OnSwipe);
    }
    private void OnDisable()
    {
        SL.OnSwipe.RemoveListener(OnSwipe);
    }
    void OnSwipe(string swipe)
    {
        swipeSide = swipe;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveForwardSpeed); //Moving forward 
        if (swipeSide == "Left")
        {
            transform.Translate(Vector3.left * Time.deltaTime * swipeSpeed);
            swipeSide = "";
        }
        else if (swipeSide == "Right")
        {
            transform.Translate(Vector3.right * Time.deltaTime * swipeSpeed);
            swipeSide = "";
        }
    }
    void Update()
    {
        if (cooldown) timeLeft -= Time.deltaTime;
        if (cooldown && timeLeft < 0) { timeLeft = 0.5f; cooldown = false; }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gate" && !cooldown)
        {
            string text = other.gameObject.GetComponentInChildren<TextMesh>().text;
            float number = float.Parse(text.Substring(1, text.Length - 1));
            if (text[0] == '+')
            {
                for (int i = 0; i < number; i++)
                {
                    Instantiate(clonePrefab, new Vector3(transform.position.x + 0.1f, 0f, transform.position.z + 0.5f), Quaternion.identity, transform);
                    CloneArrange();
                }
            }
            else if (text[0] == '-')
            {
                if (number >= transform.childCount)
                {
                    Debug.Log("GameOver");
                    Destroy(this.gameObject);
                }
                else
                {
                    for (int i = 0; i <= number; i++)
                        if (transform.GetChild(i).name != "Counter") Destroy(transform.GetChild(i).gameObject);
                    CloneArrange();
                }
            }
            else if (text[0] == '*')
            {
                int multiplier = (transform.childCount * Convert.ToInt32(number)) - transform.childCount;
                for (int i = 0; i < multiplier; i++)
                    Instantiate(clonePrefab, new Vector3(transform.position.x + 0.1f, 0f, transform.position.z + 0.5f), Quaternion.identity, transform);
                CloneArrange();
            }
            cooldown = true;
        }
    }
    float map(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
