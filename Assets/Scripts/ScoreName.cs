using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ScoreName : MonoBehaviour
{
    public static ScoreName Instance;
    public MainManager Manager;

    public Text ScoreText;





    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    
   

   

   
    [System.Serializable]
    class SaveData
    {
        public Text ScoreText;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.ScoreText = ScoreText;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

           ScoreText = data.ScoreText;
        }
    }
}

