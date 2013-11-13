using UnityEngine;
using System.Collections;

public class Connector {

	public static void connect(string playerName, string ip, int port)
	{
		Connector.initNetworkObj();		
		Network.Connect(ip, port);
	}
	
	public static void startServer(string playerName, int port, string gameName)
	{
		Connector.initNetworkObj();
		Network.InitializeServer(10, port, !Network.HavePublicAddress());
	}
	
	private static void initNetworkObj()
	{
		GameObject netInfo = new GameObject("NETWORK_INFO");
		netInfo.AddComponent<GameInfo>();
		netInfo.AddComponent<LevelController>();
		netInfo.AddComponent<NetworkView>();
		netInfo.networkView.stateSynchronization = NetworkStateSynchronization.Off;
		GameObject.DontDestroyOnLoad(netInfo);
	}
}
