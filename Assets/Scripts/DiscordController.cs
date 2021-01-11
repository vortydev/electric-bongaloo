using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
	public Discord.Discord discord;

	// Use this for initialization
	void Start()
	{
		discord = new Discord.Discord(798035364974428191, (System.UInt64)Discord.CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			State = "This is insane!",
			Details = "0 puzzles solved",
			Assets =
			{
				LargeImage = "wmubyg_bigmouth",
				LargeText = "Big Mouth Shadow",
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.LogError("Everything is fine!");
			}
		});
	}

    // Update is called once per frame
    void Update()
    {
		discord.RunCallbacks();
	}
}