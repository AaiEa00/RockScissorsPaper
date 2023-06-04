using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    public void OnClick()
    {
        int mainScene = 3;
        SceneManager.LoadScene(mainScene);
    }
}
