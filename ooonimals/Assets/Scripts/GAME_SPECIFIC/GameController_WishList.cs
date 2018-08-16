using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
public class GameController_WishList : BaseGameController {

    // pull the users wishlist from the user data/database
    // Display list 
    // Clicking on an item prompts user "Are you sure you want to remove this item?"

 
    private string url = "http://www.ooonimals.com/app/asset_bundles/newdoggs";
    private AssetBundle bundle;

    private void Start()
    {
       // myLoadedAssetBundle.Unload(false);
        StartCoroutine("GetAssetBundle");
    }
    IEnumerator GetAssetBundle()
    {
        WWW www = new WWW(url);
        while (!www.isDone)
        {
            Debug.Log("downloading....");
            yield return www;// note you may want to move this down out of the loop if you see problems
        }

        if (www.bytesDownloaded > 0)
        {
            // The bundle is downloaded now load it into memory.
            AssetBundleCreateRequest myRequest = AssetBundle.LoadFromMemoryAsync(www.bytes);
            while (!myRequest.isDone)
            {
                Debug.Log("loading....");
                yield return null;
            }

            if (myRequest.assetBundle != null)
            {
                bundle = myRequest.assetBundle;
                if (!bundle)
                {
                    // Bundle not found, this is usaually because the url is bad.
                    Debug.LogError("Error 001 - COULDN'T DOWNLOAD ASSET BUNDLE FROM URL: " + url);
                }
                else
                {
                   // Bundle loaded upack and instantiate.
                    //GameObject dog = bundle.LoadAsset("dog_prefab", typeof(GameObject)) as GameObject;
                    GameObject dog = bundle.LoadAsset<GameObject>("dog_prefab");


                    Instantiate(dog);
                }
            }
        }else{
            // Bundle not found, this is usaually because the url is bad.
            Debug.LogError("Error 002 - COULDN'T DOWNLOAD ASSET BUNDLE FROM URL: " + url);
        }       
    }


    //IEnumerator GetAssetBundle()
    //{
    //    UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("http://www.ooonimals.com/app/asset_bundles/newdoggs");
    //    yield return www.SendWebRequest();

    //    if (www.isNetworkError || www.isHttpError)
    //    {
    //        Debug.Log(www.error);
    //    }
    //    else
    //    {
    //        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
    //        Debug.Log("Yay Yay");
    //    }
    //}

    //IEnumerator DoGetBundle()
    //{
    //    string uri = url;

    //    WWW bundleRequest = new WWW(uri);
    //    while (!bundleRequest.isDone)
    //    {
    //        Debug.Log("downloading....");
    //       // onDLProgress?.Invoke(modelName, bundleRequest.progress);
    //        yield return null;
    //    }

    //    AssetBundle bundle = null;
    //    if (bundleRequest.bytesDownloaded > 0)
    //    {
    //        AssetBundleCreateRequest myRequest = AssetBundle.LoadFromMemoryAsync(bundleRequest.bytes);
    //        while (!myRequest.isDone)
    //        {
    //            Debug.Log("loading....");
    //            yield return null;
    //        }
    //        if (myRequest.assetBundle != null)
    //        {
    //            bundle = myRequest.assetBundle;
    //            GameObject model = null;
    //            if (bundle != null)
    //            {
    //                Debug.Log("I think we have a bundle!");
    //                //AssetBundleRequest newRequest = bundle.LoadAssetAsync<GameObject>(modelName);
    //                //while (!newRequest.isDone)
    //                //{
    //                //    Debug.Log("loading ASSET....");
    //                //    yield return null;
    //                //}
    //               // model = (GameObject)newRequest.asset;
    //               // modelFound(model);

    //               // bundle.Unload(false);
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogError("COULDN'T DOWNLOAD ASSET BUNDLE FROM URL: " + uri);
    //           // modelFound(null);
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("COULDN'T DOWNLOAD ASSET BUNDLE FROM URL: " + uri);
    //       // modelFound(null);
    //    }
    //}

}
