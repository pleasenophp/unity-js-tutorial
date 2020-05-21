using UnityEngine;
using Jint;
using System;
using System.IO;
using Jint.Runtime;
using System.Linq;
using Jint.Native;
using System.Collections;

public class JavascriptRunner : MonoBehaviour
{
    private Engine engine;

    private string labelText;

    // Start is called before the first frame update
    void Start()
    {
      engine = new Engine();
      engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));
      engine.SetValue("setText", new Action<string>(text => this.labelText = text));

      engine.SetValue("setTimeout", new Action<Delegate, int>((callback, interval) => {
        StartCoroutine(TimeoutCoroutine(callback, interval));
      }));

      engine.Execute("var window = this");
      Execute("Game/dist/app.js");
    }

    private IEnumerator TimeoutCoroutine(Delegate callback, int intervalMilliseconds) {
      yield return new WaitForSeconds(intervalMilliseconds / 1000.0f);
      callback.DynamicInvoke(JsValue.Undefined, new[] { JsValue.Undefined });
    }

    private void OnGUI() {
      GUILayout.Label(labelText);

      if (GUILayout.Button("Save game")) {
        string jsGameState = engine.Execute("getGameState()").GetCompletionValue().AsString();
        File.WriteAllText("savegame.json", jsGameState);
        Debug.Log("Game saved");
      }

      if (GUILayout.Button("Load game")) {
        string stateString = File.ReadAllText("savegame.json");
        engine.Invoke("setGameState", stateString);
      }
    }

    private void Execute(string fileName) {
        var body = "";
        try {
          body = File.ReadAllText(fileName);
          engine.Execute(body);
        }
        catch(JavaScriptException ex) {
          var location = engine.GetLastSyntaxNode().Location.Start;
          var error = $"Jint runtime error {ex.Error} {fileName} (Line {location.Line}, Column {location.Column})\n{PrintBody(body)}";
          UnityEngine.Debug.LogError(error); 
        }
        catch (Exception ex) {
          throw new ApplicationException($"Error: {ex.Message} in {fileName}\n{PrintBody(body)}");
        }
    }

    private static string PrintBody(string body)
    {
      if (string.IsNullOrEmpty(body)) return "";
      string[] lines = body.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
      return string.Join("\n", Enumerable.Range(0, lines.Length).Select(i => $"{i+1:D3} {lines[i]}"));
    }
}
