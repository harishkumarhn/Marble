using Marbale.BusinessObject;
using Marbale.POS.Common;
using Marble.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marbale.POS.CardDevice
{
    public class CardDeviceService
    {
        #region CardDeviceRegion

        class Device
        {
            internal string DeviceName;
            internal string DeviceType;
            internal string DeviceSubType;
            internal string VID, PID, OptString;
        }

        void registerAdditionalCardReaders()
        {

            Devices.ClearConnectedAllDevices();
            string USBReaderVID = "";
            string USBReaderPID = "";
            string USBReaderOptionalString = "0000";

            Marble.Business.SiteSetupBL siteSetupBussiness = new SiteSetupBL();
            List<AppSetting> ListAppSettings = siteSetupBussiness.GetAppSettings("POS");

            if (ListAppSettings != null && ListAppSettings.Count > 0)
            {
                AppSetting ReaderVID = ListAppSettings.Find(x => x.Name == "USB_READER_VID");
                if (ReaderVID != null)
                    USBReaderVID = ReaderVID.Value;

                AppSetting ReaderPID = ListAppSettings.Find(x => x.Name == "USB_READER_PID");
                if (ReaderPID != null)
                    USBReaderPID = ReaderPID.Value;

                AppSetting UsbReaderString = ListAppSettings.Find(x => x.Name == "USB_READER_OPT_STRING");
                if (UsbReaderString != null)
                    USBReaderOptionalString = UsbReaderString.Value;
            }

            List<Device> deviceList = new List<Device>();

            if (Devices.PrimaryCardReader == null)
            {
                if (USBReaderVID.Trim() != string.Empty)
                {
                    Device device = new Device();
                    device.DeviceName = "Default";
                    device.DeviceType = "CardReader";
                    device.DeviceSubType = "KeyboardWedge";
                    device.VID = USBReaderVID;
                    device.PID = USBReaderPID;
                    device.OptString = USBReaderOptionalString;

                    deviceList.Add(device);
                }
            }

            EventHandler currEventHandler = new EventHandler(CardScanCompleteEventHandle);
            foreach (Device device in deviceList)
            {
                if (device.DeviceSubType == "KeyboardWedge")
                {
                    USBDevice listener;
                    if (IntPtr.Size == 4) //32 bit
                        listener = new KeyboardWedge32();
                    else
                        listener = new KeyboardWedge64();


                    foreach (string optString in device.OptString.Split('|'))
                    {
                        if (string.IsNullOrEmpty(optString.Trim()))
                            continue;
                        bool flag = listener.InitializeUSBReader(this, device.VID, device.PID, optString.Trim());
                        if (listener.isOpen)
                        {
                            listener.Register(currEventHandler);
                            Devices.AddCardReader(listener);
                            if (Devices.PrimaryCardReader == null)
                            {
                                Devices.PrimaryCardReader = listener;
                            }
                        }
                    }
                }
            }
        }

        private void CardScanCompleteEventHandle(object sender, EventArgs e)
        {
            if (e is DeviceScannedEventArgs)
            {
                DeviceScannedEventArgs checkScannedEvent = e as DeviceScannedEventArgs;

                string CardNumber = string.Empty;
                if (CardReader.CardSwiped == false)
                {
                    CardNumber = checkScannedEvent.Message; // LEFT_TRIM_CARD_NUMBER, RIGHT_TRIM_CARD_NUMBER
                    if (System.Text.RegularExpressions.Regex.Matches(CardNumber, "0").Count >= 8)
                    {
                        return;
                    }
                    CardReader.CardSwiped = true;
                    HandleCardRead(CardNumber, sender as DeviceClass);
                }
            }
        }

        private void HandleCardRead(string CardNumber, DeviceClass readerDevice)
        {
            if (CardReader.CardSwiped)
                CardReader.CardSwiped = false;

            ClearCard();

            CurrentCard = null;

            TransactionBL trxBL = new TransactionBL();
            CurrentCard = trxBL.GetCard(0, CardNumber);

            if (CurrentCard == null || CurrentCard.card_id == 0)
                CurrentCard = new Card();

            DisplayCardDetails();
        }

        #endregion


    }
}
