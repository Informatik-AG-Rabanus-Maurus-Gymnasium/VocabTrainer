using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Button))]
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    Button loadScenebtn;
    [SerializeField]
    int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        loadScenebtn = GetComponent<Button>();

        loadScenebtn.onClick.AddListener(() => SceneManager.LoadScene(sceneIndex));
    }
}
