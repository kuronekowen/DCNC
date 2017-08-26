﻿using System.IO;
using Shared.Util;

namespace Shared.Network.AreaServer
{
    public class TimeSyncAnswerPacket : IOutPacket
    {
        public uint GlobalTime;
        public uint SystemTick = 0;

        public Packet CreatePacket()
        {
            var ack = new Packet(Packets.UdpTimeSyncAck);
            ack.Writer.Write(GetBytes());
            /*
            ack.Writer.Write(GlobalTime); // Relay?
            ack.Writer.Write(SystemTick); // System Tick.
            */
            return ack;
        }

        public byte[] GetBytes()
        {
            using (var ms = new MemoryStream())
            {
                using (var bs = new BinaryWriterExt(ms))
                {
                    bs.Write(GlobalTime);
                    bs.Write(SystemTick);
                }
                return ms.GetBuffer();
            }
        }
    }
}