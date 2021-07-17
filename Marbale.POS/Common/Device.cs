﻿using Marbale.POS.CardDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.POS.Common
{
    public static class Devices
    {
        public static List<DeviceClass> POSDevices = new List<DeviceClass>();
        public static List<DeviceClass> CardReaders = new List<DeviceClass>();
        public static DeviceClass PrimaryBarcodeScanner;
        public static DeviceClass PrimaryCardReader;

        public static void AddBarcodeScanner(DeviceClass device)
        {
            POSDevices.Add(device);
        }

        public static void AddCardReader(DeviceClass device)
        {
            CardReaders.Add(device);
            POSDevices.Add(device);
        }

        public static void RegisterCardReaders(EventHandler CardScanCompleteEventHandle)
        {
            foreach (DeviceClass device in CardReaders)
                device.Register(CardScanCompleteEventHandle);
        }

        public static void RegisterPrimaryCardReader(EventHandler CardScanCompleteEventHandle)
        {
            if (Common.Devices.PrimaryCardReader != null)
                Common.Devices.PrimaryCardReader.Register(CardScanCompleteEventHandle);
        }

        public static void UnregisterCardReaders()
        {
            foreach (DeviceClass device in CardReaders)
                device.UnRegister();
        }

        public static void UnregisterPrimaryCardReader()
        {
            if (Common.Devices.PrimaryCardReader != null)
                Common.Devices.PrimaryCardReader.UnRegister();
        }

        public static void ClearConnectedAllDevices()
        {
            foreach (DeviceClass device in POSDevices)
                device.Dispose();
            POSDevices.Clear();
            CardReaders.Clear();
            PrimaryCardReader = PrimaryBarcodeScanner = null;
        }
    }
}
