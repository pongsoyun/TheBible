using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileRead : MonoBehaviour
{
    List<string> scriptList = new List<string>();
    string examplePath;
    string debugFileName;
    public Text scriptText;
    // Start is called before the first frame update
    void Start()
    {
        debugFileName = "script.txt";
        #if UNITY_EDITOR
        examplePath = "Assets/Examples/FileScript";
        #else
        examplePath = Application.streamingAssetsPath;//This path read only
        #endif
        StreamReader streamReader = new StreamReader(File.OpenRead(Path.Combine(examplePath, debugFileName)));
        while(streamReader.Peek() >= 0)
        {
            scriptList.Add(streamReader.ReadLine());
        }
        streamReader.Close();
        StartCoroutine(ScriptReader());
    }

    IEnumerator ScriptReader()
    {
        for(int index = 0; index < scriptList.Count; index++)
        {
            scriptText.text = scriptList[index];
            yield return new WaitForSeconds(2.5f);
        }
    }
}
