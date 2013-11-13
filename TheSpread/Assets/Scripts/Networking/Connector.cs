using UnityEngine;
using System.Collections;

public class Connector {

	public static void connect(string playerName, string ip, int port)
	{
		Network.Connect(ip, port);
		
		Connector.initNetworkObj();
	}
	
	public static void startServer(string playerName, int port, string gameName)
	{
		Network.InitializeServer(10, port, !Network.HavePublicAddress());
		
		Connector.initNetworkObj();
	}
	
	private static void initNetworkObj()
	{
		GameObject netInfo = new GameObject("NETWORK_INFO");
		netInfo.AddComponent<GameInfo>();
		netInfo.AddComponent<NetworkView>();
		netInfo.networkView.stateSynchronization = NetworkStateSynchronization.Off;
		GameObject.DontDestroyOnLoad(netInfo);
	}
}
