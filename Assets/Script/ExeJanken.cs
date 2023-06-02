using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExeJanken : MonoBehaviour
{
    // 手の画像リスト
    [SerializeField] GameObject[] handsImages = new GameObject[3];

    // 結果
    const int win = 1;
    const int even = 2;
    const int lose = 3;

    // シーン遷移前待機時間
    [SerializeField] float waitTime = 1.0f;

    private void Start()
    {
        // すべての画像を非表示
        for (int i = 0; i < handsImages.Length; i++)
        {
            handsImages[i].SetActive(false);
        }
    }

    /// <summary>
    /// 出す手の画像を表示
    /// </summary>
    /// <param name="num"></param>
    /// <param name="clicked"></param>
    public void PrintImage(int num, GameObject clicked)
    {
        if (2 < num) return;
        handsImages[num].SetActive(true);
        JudgeResult(num, clicked);
    }

    public void JudgeResult(int ai, GameObject clicked)
    {
        if (ai == 0)
        {
            if (clicked.name == "Rock")
                Invoke("LoadSceneEven", waitTime);
            else if (clicked.name == "Scissors")
                Invoke("LoadSceneLose", waitTime);
            else
                Invoke("LoadSceneWin", waitTime);
        }
        else if (ai == 1)
        {
            if (clicked.name == "Rock")
                Invoke("LoadSceneWin", waitTime);
            else if (clicked.name == "Scissors")
                Invoke("LoadSceneEven", waitTime);
            else
                Invoke("LoadSceneLose", waitTime);
        }
        else
        {
            if (clicked.name == "Rock")
                Invoke("LoadSceneLose", waitTime);
            else if (clicked.name == "Scissors")
                Invoke("LoadSceneWin", waitTime);
            else
                Invoke("LoadSceneEven", waitTime);
        }
    }

    void LoadSceneWin()
    {
        int score = PlayerPrefs.GetInt("かち");
        score += 1;
        PlayerPrefs.SetInt("かち", score);

        SceneManager.LoadScene(win);
    }

    void LoadSceneEven()
    {
        int score = PlayerPrefs.GetInt("あいこ");
        score += 1;
        PlayerPrefs.SetInt("あいこ", score);

        SceneManager.LoadScene(even);
    }

    void LoadSceneLose()
    {
        int score = PlayerPrefs.GetInt("まけ");
        score += 1;
        PlayerPrefs.SetInt("まけ", score);

        SceneManager.LoadScene(lose);
    }
}
