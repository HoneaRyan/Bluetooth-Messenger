using System.Collections.Generic;
using System.IO;
using System.Linq;

using Android.Bluetooth;

using Java.Util;

using BluetoothMessengerLib;

namespace AndroidMessenger {
	// TO DO: add server socket functionality
	class AndroidBluetooth : Bluetooth {
		private readonly UUID _uuid = UUID.FromString(UuidString);
		private BluetoothAdapter _adapter = null;
		private ICollection<BluetoothDevice> _pairedDevices = null;
		private BluetoothDevice _device = null;
		private BluetoothSocket _socket = null;

		public UUID Uuid {
			get { return _uuid; }
		}

		public BluetoothAdapter Adapter {
			get { return _adapter; }
		}

		public AndroidBluetooth() {
			_adapter = BluetoothAdapter.DefaultAdapter;
			_pairedDevices = GetPairedDevices();
		}

		// Gets a list of paired devices.
		// Returns null if bluetooth is disabled.
		public List<BluetoothDevice> GetPairedDevices() {
			if (_adapter.IsEnabled) {
				ICollection<BluetoothDevice> devices = new List<BluetoothDevice>();
				devices = _adapter.BondedDevices;
				return devices.ToList();
			}
			else {
				return null;
			}
		}

		// Gets a connection socket from a device address.
		// Returns true/false based on connection success.
		public bool Connect(string address) {
			foreach (BluetoothDevice i in _pairedDevices) {
				if (string.Equals(i.Address, address)) {
					BluetoothSocket sock = i.CreateRfcommSocketToServiceRecord(_uuid);
					try {
						sock.Connect();
						_device = i;
						_socket = sock;
						return true;
					}
					catch {
						return false;
					}
				}
			}
			return false;
		}

		// Closes socket connection. Returns true if it succeeds.
		// Returns false if cannot Close the connection.
		public bool Disconnect() {
			try {
				_socket.Close();
				return true;
			}
			catch {
				return false;
			}
		}

		// Sends an object. Serialized the object into a JSON string.
		// Then sends the object 
		public bool SendObject<T>(T data) {
			if (_socket.IsConnected) {
				Send<T>(_socket.OutputStream, data);
				return true;
			}
			return false;
		}
		
		// Receives an object from a designated socket and returns it.
		public T ReceiveObject<T>() {
			Stream inStream = _socket.InputStream;
			return Get<T>(inStream);
		}

		// This function is used for listening for an incomming connection
		public bool GetConnection() {
			try {
				BluetoothServerSocket serverSock = _adapter.ListenUsingRfcommWithServiceRecord("Android Bluetooth Messenger", _uuid);
				BluetoothSocket inSock = serverSock.Accept();
				serverSock.Close(); // don't need any more connections comming in
				return true;
			}
			catch {
				return false;
			}
		}
	}
}