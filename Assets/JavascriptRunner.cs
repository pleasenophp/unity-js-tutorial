using UnityEngine;
using Jint;
using System;
using System.IO;

public class JavascriptRunner : MonoBehaviour
{
    private Engine engine;

    // Start is called before the first frame update
    void Start()
    {
      engine = new Engine();
      engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));
      engine.Execute(File.ReadAllText("Game/index.js"));
    }
}
