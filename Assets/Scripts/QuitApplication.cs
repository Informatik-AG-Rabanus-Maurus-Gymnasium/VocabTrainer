using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class QuitApplication : MonoBehaviour
{
    [SerializeField]
    Button quitButton;
    void Start()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}
