using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PostBuild : IPostprocessBuildWithReport 
{
  public int callbackOrder => 0;

  public void OnPostprocessBuild(BuildReport report)
  {
    Debug.Log ("PATH: "+report.summary.outputPath);
  }
}
