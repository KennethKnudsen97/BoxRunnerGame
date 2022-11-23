// See https://aka.ms/new-console-template for more information

using System.Net.Http;
using System.Text;
using UnityEngine;


public class ServerCom
{
    public static async void WriteScore(HighScoreEntry entry)
    {
        string json = JsonUtility.ToJson(entry);
        Debug.Log(json);
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        HttpClient client = new HttpClient();


        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {

            //Post new highscore
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await client.PostAsync("http://192.168.131.49:5555/newhighscore/", content);

            //Get scoreboard
            //using HttpResponseMessage response = await client.GetAsync("http://127.0.0.1:5555/scoreboard/");


            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);
            Debug.Log(responseBody);
            if(responseBody.Contains("Yes"))
            {
                Debug.Log("Score was a NEW HIGHSCORE!!!!");
            }
            else
            {
                Debug.Log("Score was not a new highscore, too bad!");
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log("\nFailed to contact server");
        }
    }

    public static async System.Threading.Tasks.Task<string> LoadColorList(Ref<string> colorList)
    {
        string json = "{}";
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        HttpClient client = new HttpClient();


        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {

            //Post new highscore
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await client.PostAsync("http://192.168.131.49:5555/colorlist/", content);
            
        
            response.EnsureSuccessStatusCode();
            colorList.Value  = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);
           
        }
        catch (HttpRequestException e)
        {
            Debug.Log("\nFailed to contact server");
        }
        return "";
    }
}


public class Ref<T>
{
    public Ref() { }
    public Ref(T value) { Value = value; }
    public T Value { get; set; }
}