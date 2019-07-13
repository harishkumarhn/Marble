using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS.CardDevice
{
    public class DeviceClass : NativeWindow
    {
        public bool defaultKeyChanged
        {
            get;
            protected set;
        }

        public bool isRoamingCard
        {
            get;
            protected set;
        }

        protected SynchronizationContext synContext;
        protected event EventHandler deviceInputHandler;

        public EventHandler DeviceInputHandler
        {
            get { return deviceInputHandler; }
        }

        protected List<EventHandler> callBackList = new List<EventHandler>();
        public virtual void Register(EventHandler callBackEventHandler)
        {
            callBackList.Add(callBackEventHandler);
            deviceInputHandler = callBackEventHandler;
        }

        public DeviceClass()
        {
            defaultKeyChanged = true;
            isRoamingCard = true;
        }

        public virtual void UnRegister()
        {
            if (callBackList.Count > 0)
                callBackList.RemoveAt(callBackList.Count - 1);

            if (callBackList.Count > 0)
                deviceInputHandler = callBackList[callBackList.Count - 1];
            else
                deviceInputHandler = null;
        }

        public virtual void Dispose()
        {
            callBackList.Clear();
        }

        protected void FireDeviceReadCompleteEvent(string deviceScannedValue)
        {
            synContext.Post(new SendOrPostCallback(delegate (object state)
            {
                if (deviceInputHandler != null && deviceInputHandler.Target != null)
                {
                    if (deviceInputHandler.Target.GetType().BaseType.ToString().Contains("Form"))
                    {
                        System.Windows.Forms.Form f = deviceInputHandler.Target as System.Windows.Forms.Form;
                        if (f != null && (f.IsDisposed || f.Disposing || f.Visible == false))
                            UnRegister();
                    }
                }

                var handler = deviceInputHandler;

                if (handler != null)
                {
                    handler(this, new DeviceScannedEventArgs(deviceScannedValue));
                }
            }), null);
            synContext.OperationCompleted();
        }

        public virtual string readCardNumber()
        {
            return "";
        }

        public virtual bool read_data_basic_auth(int blockAddress, int numberOfBlocks, ref byte[] currentKey, ref byte[] paramReceivedData, ref string message)
        {
            return true;
        }

        public virtual bool read_data(int blockAddress, int numberOfBlocks, byte[] paramAuthKey, ref byte[] paramReceivedData, ref string message)
        {
            return true;
        }

        public virtual bool write_data(int blockAddress, int numberOfBlocks, byte[] authKey, byte[] writeData, ref string message)
        {
            return true;
        }

        public virtual bool change_authentication_key(int blockAddress, byte[] currentAuthKey, byte[] newAuthKey, ref string message)
        {
            return true;
        }

        public virtual void Authenticate(byte blockAddress, byte[] key)
        {
        }

        public virtual void beep(int duration, bool asynchronous)
        {
        }

        public virtual void beep(int duration = 1)
        {
        }

        public virtual string getSerialNumber()
        {
            return "";
        }

        public virtual string setSerialNumber(string serialNumber)
        {
            return "";
        }

        public virtual void DisplayMessage(params string[] Lines)
        {
        }

        public virtual void DisplayMessage(int LineNumber, string Message)
        {
        }

        public virtual void ClearDisplay()
        {
        }
    }

    public class DeviceScannedEventArgs : EventArgs
    {
        public string Message
        {
            get;
            private set;
        }

        public DeviceScannedEventArgs(string deviceScannedValue)
        {
            this.Message = deviceScannedValue;
        }
    }
}
