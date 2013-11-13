using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour 
{
	public string playerName = "Name";
	public string ip = "127.0.0.1";
	public int port = 1337;
	
	void OnGUI()
	{
		this.playerName = GUI.TextField(new Rect(10, 10, 100, 25), this.playerName);
		this.ip = GUI.TextField(new Rect(10, 40, 100, 25), this.ip);
		this.port = int.Parse(GUI.TextField(new Rect(10, 70, 100, 25), this.port.ToString()));
		
		if(GUI.Button(new Rect(10, 100, 100, 25), "Start Server"))
		{
			Connector.startServer(this.playerName, this.port, "");	
		}
		
		if(GUI.Button(new Rect(10, 130, 100, 25), "Connect"))
		{
			Connector.connect(this.name, this.ip, this.port);	
		}
	}
}
