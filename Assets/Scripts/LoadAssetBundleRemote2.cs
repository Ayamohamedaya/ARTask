using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class LoadAssetBundleRemote2 : MonoBehaviour
{
    public string assetName="";
    [SerializeField] GameObject marker;
    public string url = "";
   
    private void Start()
    {

        StartCoroutine(DownloadAsset());
    }
    IEnumerator DownloadAsset()
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))

        {
            yield return uwr.SendWebRequest();


            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);

            }
            else
            {

                // Get downloaded asset bundle
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                var mat = bundle.LoadAsset<Renderer>("Accessories_Color");
             //   Instantiate(mat);
                var character = bundle.LoadAsset<GameObject>(assetName);
                // var prefab = bundle.LoadAsset(assetName);
                Instantiate(character,marker.transform);
                //  character.transform.SetParent(marker.transform);
    
            }
        }
    }
}
