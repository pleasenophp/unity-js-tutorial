using UnityEngine;
using Jint;
using System;
using System.IO;
using Jint.Runtime;
using System.Linq;

public class JavascriptRunner : MonoBehaviour
{
    private Engine engine;

    // Start is called before the first frame update
    void Start()
    {
      engine = new Engine();
      engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));
      engine.Execute("var window = this");
      Execute("Game/dist/app.js");

      engine.Execute("hello()");
      Debug.Log("C# got result from function: "+engine.GetCompletionValue());
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
