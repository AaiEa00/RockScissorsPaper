using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExeJanken : MonoBehaviour
{
    static readonly string[] handsTypes = { "Rock", "Scissors", "Paper" };

    // 手の画像リスト
    [SerializeField] GameObject[] handsImages = new GameObject[handsTypes.Length];

    // 結果
    enum resultTypes: int
    {
        win,
        even,
        lose,
    }

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
    /// EndButtonから呼び出される
    /// </summary>
    /// <param name="num">生成した乱数</param>
    /// <param name="clicked"></param>
    public void PrintImage(int num, GameObject clicked)
    {
        Debug.Assert(num < handsTypes.Length);

        handsImages[num].SetActive(true);
        JudgeResult(num, clicked);
    }

    /// <summary>
    /// じゃんけんの結果
    /// </summary>
    /// <param name="ai">乱数で選ばれた手</param>
    /// <param name="clicked">クリックした手</param>
    void JudgeResult(int ai, GameObject clicked)
    {
        int clickedHand = 0;
        // クリックされた手の情報をclickedHandに格納
        for (int i = 0; i < handsTypes.Length; i++)
        {
            if (clicked.name == handsTypes[i])
            {
                clickedHand = i;
            }
        }

        // 勝ち
        if (clickedHand == ai)
        {
            Invoke("LoadSceneEven", waitTime);
        }
        // 0(グー)と2(パー)の組み合わせを先に処理
        else if (clickedHand == 2 && ai == 0)
        {
            Invoke("LoadSceneWin", waitTime);
        }
        else if (clickedHand == 0 && ai == 2)
        {
            Invoke("LoadSceneLose", waitTime);
        }
        // 勝ち
        else if (clickedHand < ai)
        {
            Invoke("LoadSceneWin", waitTime);
        }
        // 負け
        else if (clickedHand > ai)
        {
            Invoke("LoadSceneLose", waitTime);
        }
        else
        {
            Debug.Assert(false);
        }
    }

    void LoadSceneWin()
    {
        int score = PlayerPrefs.GetInt("かち");
        score += 1;
        PlayerPrefs.SetInt("かち", score);

        SceneManager.LoadScene((int)resultTypes.win);
    }

    void LoadSceneEven()
    {
        int score = PlayerPrefs.GetInt("あいこ");
        score += 1;
        PlayerPrefs.SetInt("あいこ", score);

        SceneManager.LoadScene((int)resultTypes.even);
    }

    void LoadSceneLose()
    {
        int score = PlayerPrefs.GetInt("まけ");
        score += 1;
        PlayerPrefs.SetInt("まけ", score);

        SceneManager.LoadScene((int)resultTypes.lose);
    }
}
