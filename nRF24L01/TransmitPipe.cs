﻿using System;
using Windows.Devices.Radios.nRF24L01.Enums;

namespace Windows.Devices.Radios.nRF24L01
{
    public class TransmitPipe
    {
        private readonly Registers.RegisterCollection _registers;
        private readonly Radio _radio;
        public TransmitPipe(Radio radio)
        {
            _radio = radio;
            _registers = _radio.Configuration.Registers;
        }

        public byte[] Address
        {
            get
            {
                return _registers.TransmitAddressRegister.TX_ADDR;
            }
            set
            {
                int addressWidth = _radio.Configuration.AddressWidth;
                if (value.Length < addressWidth)
                    throw new InvalidOperationException("Address length should equal or greater than device.Config.AddressWidth");
                else if(value.Length > addressWidth)
                    Array.Resize(ref value, addressWidth);
                _registers.TransmitAddressRegister.TX_ADDR = value;
                _registers.TransmitAddressRegister.Save();
            }
        }

        public void FlushBuffer()
        {
            _radio.Transfer(Constants.FLUSH_TX);
        }

        public FifoStatus FifoStatus
        {
            get
            {
                _registers.FifoStatusRegister.Load();
                if (_registers.FifoStatusRegister.TX_FULL)
                    return FifoStatus.Full;
                if (_registers.FifoStatusRegister.TX_EMPTY)
                    return FifoStatus.Empty;
                return FifoStatus.InUse;
            }
        }

        public void Write(byte[] data, bool disableACK = false)
        {
            if (data.Length > Constants.MaxPayloadSize)
                throw new ArgumentOutOfRangeException(nameof(data), string.Format("data should be 0-{0} bytes", Constants.MaxPayloadSize));
            byte[] buffer = new byte[data.Length + 1];
            Array.Copy(data, 0, buffer, 1, buffer.Length);
            buffer[0] = (byte)(disableACK ? (Constants.W_TX_PAYLOAD_NOACK | Constants.EMPTY_ADDRESS) : (Constants.W_TX_PAYLOAD | Constants.EMPTY_ADDRESS));
            _radio.Transfer(buffer);
        }
    }
}