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
      engine.SetValue("myFunc", 
        new Func<int, string>(number => "C# can see that you passed: "+number));

      engine.Execute(@"
        var responseFromCsharp = myFunc(108);
        log('Response from C#: '+responseFromCsharp);        
      ");
    }
}
