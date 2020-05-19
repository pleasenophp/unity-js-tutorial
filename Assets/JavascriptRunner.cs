using UnityEngine;
using Jint;
using System;

public class JavascriptRunner : MonoBehaviour
{
    private Engine engine;

    private class WorldModel {
      public string PlayerName {get; set; } = "Alice";
      public int NumberOfDonuts { get; set; } = 2;

      public void Msg() {
        Debug.Log("This is a function");
      }
    }

    // Start is called before the first frame update
    void Start()
    {
      engine = new Engine();
      engine.SetValue("log", new Action<object>(msg => Debug.Log(msg)));

      var world = new WorldModel();
      engine.SetValue("world", world);
      Debug.Log($"{world.PlayerName} has {world.NumberOfDonuts} donuts");

      engine.Execute(@"
        log('Javascript can see that '+world.PlayerName+' has '+world.NumberOfDonuts+' donuts');
        world.Msg();
        world.NumberOfDonuts += 3;
      ");

      Debug.Log($"{world.PlayerName} has now {world.NumberOfDonuts} donuts. Thanks, JavaScript, for giving us some");
    }
}
