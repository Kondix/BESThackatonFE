﻿// This is the client DLL class code to use for the sockServer
// include this DLL in your Plugins folder under Assets
// using it is very simple
// Look at LinkSyncSCR.cs


using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector
{
    const int READ_BUFFER_SIZE = 1024;
    const int PORT_NUM = 1235;
    private TcpClient client;
    private byte[] readBuffer = new byte[READ_BUFFER_SIZE];
    public ArrayList lstUsers = new ArrayList();
    public string strMessage = string.Empty;
    public string res = String.Empty;
    private string pUserName;

    public string tempString ="{\"ID\":\"ADD\",\"ROOMS\":[{\"rID\":5,\"hLVL\":3,\"title\":\"Eskalopki\",\"hID\":2,\"descr\":\"mieso w ciescie\"}]}";
  


    public Connector() { }

    public string fnConnectResult(string sNetIP, int iPORT_NUM)
    {
        try
        {
            // The TcpClient is a subclass of Socket, providing higher level 
            // functionality like streaming.
            // Start an asynchronous read invoking DoRead to avoid lagging the user
            // interface.
          
            // Make sure the window is showing before popping up connection dialog.
            if (client == null || !client.Connected)
            {
                client = new TcpClient(sNetIP, PORT_NUM);
            }
            client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
            SendAvlRequest();
            return "Connection Succeeded";
        }
        catch (Exception ex)
        {
            return "Server is not active.  Please start server and try again.      " + ex.ToString();
        }
    }


    public void SendAvlRequest()
    {
        SendData("{\"ID\":\"AVL\"}");
    }
    public void AddToDataBase()
    {
        SendData("{\"ID\":\"ADD\",\"ROOMS\":[{\"rID\":3,\"hLVL\":2,\"title\":\"trynkiewicz\",\"hID\":7,\"descr\":\"lubi dzieciaki\"}]}");
    }
    public void SendSpecAvlRequest()
    {
        SendData("{\"ID\":\"SPEC_AVL\",\"descr\":\"upa\"}");
    }
    
    //public void AddToDataBase()
    //{

    //}
    private void ParseResponse(string response)
    {
        
    }
    private void DoRead(IAsyncResult ar)
    {
        int BytesRead;
        try
        {
            // Finish asynchronous read into readBuffer and return number of bytes read.
            BytesRead = client.GetStream().EndRead(ar);
            if (BytesRead < 1)
            {
                // if no bytes were read server has close.  
                res = "Disconnected";
                return;
            }
            // Convert the byte array the message was saved into, minus two for the
            // Chr(13) and Chr(10)
            strMessage = Encoding.ASCII.GetString(readBuffer, 0, BytesRead);
            Debug.Log(strMessage);
            ProcessCommands(strMessage);
            // Start a new asynchronous read into readBuffer.
            client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);

        }
        catch
        {
            res = "Disconnected";
            Debug.Log(res);
        }
    }

    // Process the command received from the server, and take appropriate action.
    public void ProcessCommands(string strMessage)
    {
        Debug.Log(strMessage);
        if (strMessage.StartsWith("["))
        {
            strMessage = strMessage.Insert(0, "\"jsonDatas\":");
            JsonDataWrapper jsonDataWrapper = JsonUtility.FromJson<JsonDataWrapper>("{" + strMessage + "}");

            Debug.Log("DZIALAM KURWA   " + jsonDataWrapper.jsonDatas[0].ID);
        }
        else
        {
            JsonData jsonData = JsonUtility.FromJson<JsonData>(strMessage);

            Debug.Log("DZIALAM KURWA   " + jsonData.ID);
        }
        //if (strMessage.StartsWith("{"))
        //{
        //    strMessage = strMessage.Remove(0, 1);
        //}
        
        //strMessage[0];

        string[] dataArray;

        // Message parts are divided by "|"  Break the string into an array accordingly.
        dataArray = strMessage.Split((char)124);
        // dataArray(0) is the command.
      
    }

    public void fnDisconnect()
    {
        SendData("DISCONNECT");
    }
 
    // Use a StreamWriter to send a message to server.
    public void SendData(string data)
    {
        StreamWriter writer = new StreamWriter(client.GetStream());
        writer.Write(data + (char)13);
        writer.Flush();
    }

    private void ListUsers(string[] users)
    {
        int I;
        lstUsers.Clear();
        for (I = 1; I <= (users.Length - 1); I++)
        {
            lstUsers.Add(users[I]);
        }
    }
}


public class JsonDataWrapper
{
    public List<JsonData> jsonDatas;
}

[Serializable]
public struct JsonData
{
    public List<Room> ROOMS;
    public string ID;

    [Serializable]
    public struct Room
    {
        public string hlvl;
        public string title;
        public string hID;

    }
}

