using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using NotifyLib;
using SuperSocket.SocketBase.Protocol;

namespace NotifyForm
{
    public class SSClient
    {

        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;

        Socket client_Socket;
        public string Ip { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public Action<MessageInfo> ProcessData { get; set; }

        public Thread ReadThread { get; set; }

        //delegate void ProcessData(MessageInfo info);

        public bool Connect()
        {
            try
            {
                EndPoint serverAddress = new IPEndPoint(IPAddress.Parse(Ip), Port);
                client_Socket = new Socket(serverAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client_Socket.Connect(serverAddress);

                ReadThread = new Thread(new ThreadStart(ReceiveMsg));
                ReadThread.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Close()
        {
            //if (ReadThread.IsAlive)
            //{
            //    ReadThread.Abort();
            //}
            if (client_Socket != null && client_Socket.Connected)
            {
                client_Socket.Close();
            }

        }
        private void ReceiveMsg()
        {
            MessageInfo domianBindInfo = new MessageInfo()
            {
                Id = Guid.NewGuid().ToString(),
                MessageType = MsgType.Login
                  ,
                Key = MsgType.Login.ToString(),
                Body = UserName
            };
            SendMessageToServer(domianBindInfo);

            while (client_Socket != null && client_Socket.Connected)
            {
                try
                {
                    byte[] buffer = new byte[2000];
                    int count = client_Socket.Receive(buffer);
                    if (count == 0)
                    {
                        continue;
                    }
                    MessageInfo info = buffer.ToMessageInfo();
                    ResponseToServer(info);
                    if (ProcessData != null)
                    {
                        ProcessData(info);
                    }
                }
                catch (Exception ex)
                {
                    client_Socket.Close();
                }
            }
        }

        //private void ProcessData(MessageInfo info)
        //{
        //    if (info.MessageType==MsgType.Info)
        //    {
        //        //if ()
        //        //{

        //        //} info.Body
        //    }
        //}

        private void ResponseToServer(MessageInfo info)
        {
            MessageInfo returnInfo = new MessageInfo()
            {
                Id = info.Id
            };

            switch (info.MessageType)
            {
                case MsgType.Simple:
                    returnInfo.MessageType = MsgType.ACK;
                    break;
                case MsgType.Info:
                    returnInfo.MessageType = MsgType.ACK;
                    break;
                case MsgType.XT:
                    returnInfo.MessageType = MsgType.XT;
                    break;
                default:
                    break;
            }

            returnInfo.Key = returnInfo.MessageType.ToString();
            returnInfo.Body = "";
            SendMessageToServer(returnInfo);

        }

        private void SendMessageToServer(MessageInfo returnInfo)
        {
            client_Socket.Send(returnInfo.ToBytes());
        }

        //等待接收数据

        //public void WaitForData()
        //{
        //    try
        //    {
        //        if (m_pfnCallBack == null)
        //        {
        //            m_pfnCallBack = new AsyncCallback(OnDataReceived);
        //        }
        //        SocketPacket theSocPkt = new SocketPacket();
        //        theSocPkt.thisSocket = m_clientSocket;
        //        // Start listening to the data asynchronously
        //        m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
        //                                                0, theSocPkt.dataBuffer.Length,
        //                                                SocketFlags.None,
        //                                                m_pfnCallBack,
        //                                                theSocPkt);
        //    }
        //    catch (SocketException se)
        //    {

        //    }

        //}

        //public void OnDataReceived(IAsyncResult asyn)
        //{
        //    try
        //    {
        //        SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
        //        int iRx = theSockId.thisSocket.EndReceive(asyn);
        //        char[] chars = new char[iRx + 1];
        //        System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
        //        int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
        //        System.String szData = new System.String(chars);
        //        richTextRxMessage.Text = richTextRxMessage.Text + szData;
        //        WaitForData();
        //    }
        //    catch (ObjectDisposedException)
        //    {
        //        System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
        //    }
        //    catch (SocketException se)
        //    {

        //    }
        //}
    }
}