using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;
using NotifyLib;
namespace SS_S
{
    public class MessageReceiveFilter : IReceiveFilter<MessageInfo>
    {
        public int LeftBufferSize
        {
            get
            {
                return 0;
            }
        }

        public IReceiveFilter<MessageInfo> NextReceiveFilter
        {
            get
            {
                return this;// new MessageReceiveFilter();
            }
        }

        public FilterState State
        {
            get
            {
               return FilterState.Normal;
              //  throw new NotImplementedException();
            }
        }

        public MessageInfo Filter(byte[] readBuffer, int offset, int length, bool toBeCopied, out int rest)
        {

            //readBuffer是缓冲区，不是数据源
            rest = 0;
            byte[] bodydata = new byte[length];
            Array.Copy(readBuffer, offset, bodydata, 0, length);
            return NotifyLib.ConvertHelper.DeserializeObject(bodydata) as MessageInfo;

        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
