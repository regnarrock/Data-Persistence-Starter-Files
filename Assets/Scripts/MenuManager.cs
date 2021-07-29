using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Text textName;
    public MainManager Manager;
   

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("MainManager").GetComponent<MainManager>();
        Manager.LoadName();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        Manager.LoadName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
