using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class Builder
{
    const string OUTPUT_PATH = "../../dist/apps/zen-unity";
    static void BuildWebGL(BuildPlayerOptions buildPlayerOptions)
    {
        FileUtil.DeleteFileOrDirectory("ServerData/WebGL");
        FileUtil.DeleteFileOrDirectory(OUTPUT_PATH);

        buildPlayerOptions.locationPathName = OUTPUT_PATH;
        buildPlayerOptions.scenes = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
        buildPlayerOptions.target = BuildTarget.WebGL;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        else if (summary.result == BuildResult.Failed)
            Debug.Log("Build player failed");
    }

    [MenuItem("Build/Build WebGL Development")]
    public static void BuildWebGLDevelopment()
    {
        var playerSettings = new BuildPlayerOptions();
        playerSettings.options = BuildOptions.Development;
        BuildWebGL(playerSettings);
    }

    [MenuItem("Build/Build WebGL Production")]
    public static void BuildWebGLProduction()
    {
        var playerSettings = new BuildPlayerOptions();
        playerSettings.options = BuildOptions.None;
        BuildWebGL(playerSettings);
    }
}
