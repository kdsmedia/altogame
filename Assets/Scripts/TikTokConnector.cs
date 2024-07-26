using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TikTokConnector : MonoBehaviour
{
    private const string API_URL = "https://api.tiktok.com/live";
    private const string ACCESS_TOKEN = "your_access_token_here";

    public IEnumerator ConnectToTikTok(string username)
    {
        string url = $"{API_URL}/connect?username={username}";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", "Bearer " + ACCESS_TOKEN);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Successfully connected to TikTok Live: " + request.downloadHandler.text);
                ProcessTikTokData(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error connecting to TikTok Live: " + request.error);
            }
        }
    }

    private void ProcessTikTokData(string data)
    {
        // Process the data received from TikTok API
        // Example: Parse JSON and handle comments, gifts, etc.
        Debug.Log("Processing TikTok data: " + data);
    }

    public IEnumerator GetLiveData()
    {
        string url = $"{API_URL}/data";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Authorization", "Bearer " + ACCESS_TOKEN);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Successfully retrieved live data: " + request.downloadHandler.text);
                ProcessTikTokData(request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error retrieving live data: " + request.error);
            }
        }
    }
}
