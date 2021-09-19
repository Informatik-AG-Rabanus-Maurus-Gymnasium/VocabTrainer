using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class VersionTextSetter : MonoBehaviour
{
    [SerializeField]
    TMP_Text versionTxt;
    void Start()
    {
        versionTxt = GetComponent<TMP_Text>();
        versionTxt.text = Application.version;
    }
}
