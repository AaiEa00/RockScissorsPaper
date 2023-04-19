using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintRecords : MonoBehaviour
{
    Text _text;

    private void Start()
    {
        TryGetComponent(out _text);

        _text.text = "‚©‚¿: " + PlayerPrefs.GetInt("‚©‚¿")
                        + "  ‚ ‚¢‚±: " + PlayerPrefs.GetInt("‚ ‚¢‚±")
                        + "  ‚Ü‚¯: " + PlayerPrefs.GetInt("‚Ü‚¯");
    }
}
