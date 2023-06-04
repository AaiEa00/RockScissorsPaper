using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    // アクセス用
    [SerializeField] GameObject obj;
    ExeJanken exe;

    void Start()
    {
        exe = obj.GetComponent<ExeJanken>();
    }

    public void OnClick()
    {
        // じゃんけんの手の種類
        int jankenNum = 3;

        // 出す手
        int resultHand = Random.Range(0, jankenNum);

        // 乱数から画像を表示
        exe.PrintImage(resultHand, gameObject);
    }
}
