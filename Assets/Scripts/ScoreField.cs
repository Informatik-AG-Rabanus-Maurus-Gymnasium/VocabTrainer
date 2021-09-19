using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TMP_Text))]
public class ScoreField : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreField;

    void Start()
    {
        scoreField = GetComponent<TMP_Text>();

        scoreField.text = "Score: " + PlayerPrefs.GetInt("score");
    }

}
