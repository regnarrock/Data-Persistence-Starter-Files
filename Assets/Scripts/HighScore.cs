using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScore : MonoBehaviour
{
    public static HighScore Instance;

    public Text scoreText1;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [System.Serializable]
    class SaveData
    {
        public Text scoreText1;

    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.scoreText1 = scoreText1;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public Text LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            scoreText1 = data.scoreText1;
            
        }
        return scoreText1;
    }
}
