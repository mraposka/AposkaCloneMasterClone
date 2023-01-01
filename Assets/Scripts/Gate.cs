using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    public GameObject leftText;
    public GameObject rightText;
    void Start()
    {
        //Left
        float operatorSelection = Random.Range(0.0f, 1f);
        if (operatorSelection < 0.5)
        {
            float number = Random.Range(0, 11);
            leftText.GetComponent<TextMesh>().text = "+" + (number * 1).ToString();
        }
        else if (operatorSelection >= 0.5f && operatorSelection <= 0.75f)
        {
            float number = Random.Range(0, 11);
            leftText.GetComponent<TextMesh>().text = "-" + (number * 1).ToString();
        }
        else if (operatorSelection > 0.75f && operatorSelection <= 1f)
        {
            float number = Random.Range(0, 11);
            leftText.GetComponent<TextMesh>().text = "*" + number.ToString();
        }

        //Right
        operatorSelection = Random.Range(0.0f, 1f);
        if (operatorSelection < 0.5)
        {
            float number = Random.Range(0, 11);
            rightText.GetComponent<TextMesh>().text = "+" + (number * 1).ToString();
        }
        else if (operatorSelection >= 0.5f && operatorSelection <= 0.75f)
        {
            float number = Random.Range(0, 11);
            rightText.GetComponent<TextMesh>().text = "-" + (number * 1).ToString();
        }
        else if (operatorSelection > 0.75f && operatorSelection <= 1f)
        {
            float number = Random.Range(0, 11);
            rightText.GetComponent<TextMesh>().text = "*" + number.ToString();
        }
    }
}
