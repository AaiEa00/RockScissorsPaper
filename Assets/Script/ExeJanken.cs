using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExeJanken : MonoBehaviour
{
    // ��̉摜���X�g
    [SerializeField] GameObject[] handsImages = new GameObject[3];

    // ����
    const int win = 1;
    const int even = 2;
    const int lose = 3;

    // �V�[���J�ڑO�ҋ@����
    [SerializeField] float waitTime = 1.0f;

    public int winScore = 0;
    public int loseScore = 0;
    public int evenScore = 0;

    private void Start()
    {
        // ���ׂẲ摜���\��
        for (int i = 0; i < handsImages.Length; i++)
        {
            handsImages[i].SetActive(false);
        }
    }

    /// <summary>
    /// �o����̉摜��\��
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
        SceneManager.LoadScene(win);
        winScore += 1;
        PlayerPrefs.SetInt("����", winScore);
    }

    void LoadSceneEven()
    {
        SceneManager.LoadScene(even);
        evenScore += 1;
        PlayerPrefs.SetInt("������", evenScore);
    }

    void LoadSceneLose()
    {
        SceneManager.LoadScene(lose);
        loseScore += 1;
        PlayerPrefs.SetInt("�܂�", loseScore);
    }
}
