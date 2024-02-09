using Colyseus;
using UnityEngine;

namespace Zen
{
    public class MultiplayerNetwork : MonoBehaviour
    {
        async void Start()
        {
            ColyseusRoom<Colyseus.MyRoomState> room = await NetworkManager.ColyseusClient.JoinOrCreate<Colyseus.MyRoomState>("MainRoom");
            room.OnJoin += () => Debug.Log("Joined MainRoom");
            room.OnMessage<Colyseus.Player>("boxUpdate", message => Debug.Log("boxUpdate called"));
        }
    }
}
