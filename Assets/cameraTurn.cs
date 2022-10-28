using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;


public class cameraTurn : MonoBehaviour
{
    Vector3 r = new Vector3(0, 1, 0);
    Vector3 l = new Vector3(0, -1, 0);
    int width = 720;
    int height = 512;
    Vector3 currPosition;
    UdpClient client;


    //RenderTexture texture;
    Texture2D tex;

    // Start is called before the first frame update
    void Start()
    {
        currPosition = transform.position;
        Debug.Log(width);
        Debug.Log(height);
        tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        client = new UdpClient(5600);
        try
        {
            client.Connect("127.0.0.1", 5500);
            Debug.Log("client connected");
        }
        catch (Exception e)
        {
            print(e);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j"))
        {
            transform.Rotate(r);
        }
        if (Input.GetKey("k"))
        {
            transform.Rotate(l);
        }
    }

	private void OnPostRender()
	{
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToJPG();
        client.Send(bytes, bytes.Length);
        Debug.Log("frame sent");
    }
}
