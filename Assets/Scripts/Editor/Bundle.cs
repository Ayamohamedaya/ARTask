using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.IO;

public class Bundle : MonoBehaviour
{
    [MenuItem("Assets/Build Bundle")]
    static void BuildAssetBundle()
    {
        string assetBundleDirectory = "Assets/Build Bundle";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory,BuildAssetBundleOptions.None,BuildTarget.Android);
    }
}
