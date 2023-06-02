﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    // 出す手
    int resultHand = 0;

    // じゃんけんの手の種類
    int jankenNum = 3;

    // アクセス用
    [SerializeField] GameObject obj;
    ExeJanken exe;

    // Start is called before the first frame update
    void Start()
    {
        exe = obj.GetComponent<ExeJanken>();
    }

    public void OnClick()
    {
        // 乱数生成
        resultHand = Random.Range(0, jankenNum);

        // 乱数から画像を表示
        exe.PrintImage(resultHand, gameObject);
    }
}
