using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ChatterManager : ChatterManagerBehavior
{

    public Transform chatContent;
    public GameObject chatMessage;
    public Slider slider;
    public Text sliderValue;
    public Text latestValue;

    private string username;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (networkObject.IsServer)
            username = "Server";
        else
            username = "Client";
    }

    public void WriteMessage(InputField sender)
    {
        if(!string.IsNullOrEmpty(sender.text) && sender.text.Trim().Length > 0)
        {
            sender.text = sender.text.Replace("\r", string.Empty).Replace("\n", string.Empty);
            networkObject.SendRpc(RPC_TRANSMIT_MESSAGE, Receivers.All, username, sender.text.Trim());
            sender.text = string.Empty;
            sender.ActivateInputField();
        }
    }

    public void SendSliderMessage()
    {
        String message = slider.value.ToString();
        sliderValue.text = message;

        if (!string.IsNullOrEmpty(message) && message.Trim().Length > 0)
        {
            message = message.Replace("\r", string.Empty).Replace("\n", string.Empty);
            networkObject.SendRpc(RPC_TRANSMIT_MESSAGE, Receivers.All, username, message.Trim());
        }
    }

    public override void TransmitMessage(RpcArgs args)
    {
        string username = args.GetNext<string>();
        string message = args.GetNext<string>();

        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(message))
        {
            //The message or username was empty so do not display this message to anyone
            return;
        }

        GameObject newMessage = Instantiate(chatMessage, chatContent);
        Text content = newMessage.GetComponent<Text>();

        content.text = string.Format(content.text, username, message);

        latestValue.text = message;

        Destroy(newMessage);
    }
}
