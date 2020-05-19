using UnityEngine;
using Jint;
using System;
using Jint.Runtime.Interop;

public class JavascriptRunner : MonoBehaviour
{
    private Engine engine;

    private class GameApi {
      public void ApiMethod1() {
        Debug.Log("Called api method 1");
      }

      public int ApiMethod2() {
        Debug.Log("Called api method 2");
        return 2;
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      engine = new Engine();
      engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));

      engine.SetValue("GameApi", TypeReference.CreateTypeReference(engine, typeof(GameApi)));

      engine.Execute(@"
        var gameApi = new GameApi();
        gameApi.ApiMethod1();
        var result = gameApi.ApiMethod2();
        log(result);
      ");
    }
}
