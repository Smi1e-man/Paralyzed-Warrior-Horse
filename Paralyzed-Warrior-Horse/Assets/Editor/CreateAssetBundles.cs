using UnityEditor;

public class CreateAssetBundles
{
    [MenuItem("Assets/BuildAssetBundles/Android")]
    static void BuildAllAssetBundlesAndroid()
    {
        BuildPipeline.BuildAssetBundles("Assets/Resources/AssetBundlesAndroid", BuildAssetBundleOptions.None,
            BuildTarget.Android);
    }
}
