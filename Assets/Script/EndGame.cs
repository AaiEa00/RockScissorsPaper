using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void OnClick()
    {
        PlayerPrefs.DeleteAll();

        // ÉQÅ[ÉÄÇèIóπ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
