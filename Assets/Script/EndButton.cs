using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    // �o����
    int resultHand = 0;

    // ����񂯂�̎�̎��
    int jankenNum = 3;

    // �A�N�Z�X�p
    [SerializeField] GameObject obj;
    ExeJanken exe;

    // Start is called before the first frame update
    void Start()
    {
        exe = obj.GetComponent<ExeJanken>();
    }

    public void OnClick()
    {
        // ��������
        resultHand = Random.Range(0, jankenNum);

        // ��������摜��\��
        exe.PrintImage(resultHand, gameObject);
    }
}
