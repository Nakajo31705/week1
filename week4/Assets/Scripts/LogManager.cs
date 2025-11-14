using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    [SerializeField] private Text logText;          //UI上に表示するテキスト
    [SerializeField] private int maxLogLines = 10;  //最大ログ行数

    //ログを保存する
    private Queue<string> logs = new Queue<string>();

    /// <summary>
    /// ログを追加する
    /// 古いログは削除される
    /// </summary>
    public void AddLog(string log)
    {
        logs.Enqueue(log);

        if(logs.Count > maxLogLines)
        {
            string remove = logs.Dequeue();
        }

        UpdateLogDisplay();
    }

    /// <summary>
    /// ログをUIに表示する
    /// </summary>
    private void UpdateLogDisplay()
    {
        logText.text = string.Join("\n", logs.ToArray());
    }
}
