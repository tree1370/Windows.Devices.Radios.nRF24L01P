﻿namespace Windows.Devices.Radios.nRF24L01P.Registers
{
    /// <summary>
    ///   RF Setup Register
    /// </summary>
    public class RfSetupRegister : RegisterBase
    {
        public RfSetupRegister(Radio radio) : base(radio, 1, Addresses.RF_SETUP)
        {

        }
        public bool CONT_WAVE
        {
            get { return GetBitValue(Properties.CONT_WAVE); }
            set { SetBitValue(Properties.CONT_WAVE, value); }
        }

        public bool RF_DR_LOW
        {
            get { return GetBitValue(Properties.RF_DR_LOW); }
            set { SetBitValue(Properties.RF_DR_LOW, value); }
        }

        public bool PLL_LOCK
        {
            get { return GetBitValue(Properties.PLL_LOCK); }
            set { SetBitValue(Properties.PLL_LOCK, value); }
        }

        public bool RF_DR_HIGH
        {
            get { return GetBitValue(Properties.RF_DR_HIGH); }
            set { SetBitValue(Properties.RF_DR_HIGH, value); }
        }

        public byte RF_PWR
        {
            get { return GetByteValue(2, Properties.RF_PWR); }
            set { SetByteValue(value, 2, Properties.RF_PWR); }
        }
    }
}
