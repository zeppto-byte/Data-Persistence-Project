using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    private TextMeshProUGUI m_HighScoreText;
    private TMP_InputField m_PlayerName;

    private void Awake()
    {
        m_HighScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        m_PlayerName = GameObject.Find("PlayerNameText").GetComponent<TMP_InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
        string user;
        int score = DataManager.Instance.HighScorePoints;

        if (DataManager.Instance.HighScoreUser.TrimEnd() != null)
        {
            user = DataManager.Instance.HighScoreUser;
            m_HighScoreText.text = "High Score \n" + user + ": " + score;
        }
        else
        {
            m_HighScoreText.text = "High Score \n";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // Make sure player name is saved, so it can be used in the game
        // If no player name has been entered, make it "Default"
        if (m_PlayerName.text == "Enter player name...")
        {
            DataManager.Instance.CurrentUser = "Default";
        }
        else
        {
            DataManager.Instance.CurrentUser = m_PlayerName.text;
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
