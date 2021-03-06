﻿namespace Windows.Devices.Radios.nRF24L01P.Registers
{
    /// <summary>
    ///   Setup of Automatic Retransmission
    /// </summary>
    public class SetupRetransmissionRegister : RegisterBase
    {
        public SetupRetransmissionRegister(Radio radio) : base(radio, 1, Addresses.SETUP_RETR)
        {

        }

        public byte ARD
        {
            get { return GetByteValue(7, Properties.ARD); }
            set { SetByteValue(value, 7, Properties.ARD); }
        }

        public byte ARC
        {
            get { return GetByteValue(3, Properties.ARC); }
            set { SetByteValue(value, 3, Properties.ARC); }
        }
    }
}
