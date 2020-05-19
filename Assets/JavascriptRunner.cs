using UnityEngine;
using Jint;
using System;

public class JavascriptRunner : MonoBehaviour
{
    private Engine engine;
    
    // Start is called before the first frame update
    void Start()
    {
      engine = new Engine();
      engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));
      engine.SetValue("my-func", 
        new Func<int, string>(number => "C# can see that you passed: "+number));

      engine.Execute(@"
        var myVariable = 108;
        log('Hello from Javascript! myVariable = '+myVariable);

        
      ");
    }
}
