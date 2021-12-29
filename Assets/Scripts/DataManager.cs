using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int HighScorePoints; // new variable declared
    public string HighScoreUser;
    public string CurrentUser;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string User;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScorePoints;
        data.User = HighScoreUser;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScorePoints = data.HighScore;
            HighScoreUser = data.User;
        }
        if (HighScoreUser == null)
        {
            HighScoreUser = " ";
        }
    }

}
