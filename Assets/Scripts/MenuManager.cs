using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;   
    public Text text;
      public InputField inf;
    public string userName;
    public int points;
   
    // Start is called before the first frame update
    void Start()
    {
        LoadColor();
        text.text = $"HighScore: {StaticNameScore.usernamehighscore} {StaticNameScore.highscorepoint}";
        
        //// start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        if (StaticNameScore.username != inf.text)
        {
            StaticNameScore.username = inf.text;
        }
      
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    [System.Serializable]
    public class SaveData
    {
        public string userName;
        public int m_Points;
       
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.userName = StaticNameScore.username;
        data.m_Points = StaticNameScore.points;
        //Debug.Log("temp var: " + data);
        //Debug.Log("inf var: " + userName);
       
        


        string json = JsonUtility.ToJson(data);
        Debug.Log("json var: " + json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
       
        //Debug.Log("inload");
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            StaticNameScore.usernamehighscore = data.userName;
            StaticNameScore.highscorepoint = data.m_Points;
            //Debug.Log("json var: " + json);
            //Debug.Log("data var: " + data);

            
        }
        
    }
    
}
