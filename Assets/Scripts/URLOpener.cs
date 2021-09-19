using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class URLOpener : MonoBehaviour
{
    [SerializeField]
    Button openURLbtn;

    void Start()
    {
        openURLbtn = GetComponent<Button>();

        openURLbtn.onClick.AddListener(() => Application.OpenURL("https://github.com/PixelWelt"));
    }
}
