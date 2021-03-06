﻿using System;
using System.IO;

public class Message : IComparable<Message>
{
	private string _text = "";
	private ulong _timeStamp = 0;
	private Stream _multi = null;       // not implemented yet
	private PhoneNumber _phoneNumber;
	private bool _isMMS = false;
	private bool _isSent = false;
	private string _who = "";
	
	public string Who {
		get { return _who; }
		set { _who = value; }
	}

	public string Text {
		get { return _text; }
		set { _text = value; }
	}

	public bool isSent {
		get { return _isSent; }
		set { _isSent = value; }
	}

	// TODO add check to make sure phone number is valid
	public string PhoneNumber {
		get { return _phoneNumber.Number; }
		set { _phoneNumber = new PhoneNumber(value); }
	}

	public bool IsMms {
		get { return _isMMS; }
		set { _isMMS = value; }
	}

	public ulong Time {
		get { return _timeStamp; }
		set { _timeStamp = value; }
	}

	public Message() {
		// keep the default values
	}

	public Message(Message msg) {
		if (msg != null) {
			_isMMS = msg.IsMms;
			_isSent = msg.isSent;
			_text = msg.Text;
			_timeStamp = msg.Time;
			_phoneNumber = new PhoneNumber(msg.PhoneNumber);
			_who = msg.Who;
		}
	}

	public Message(string text) {
		_timeStamp = 0;
		_text = text;
		_multi = null;
		_phoneNumber = null;
		_isMMS = false;
		_isSent = false;
	}

	public Message(string text, string phoneNumber) {
		_timeStamp = 0;
		_text = text;
		_multi = null;
		_phoneNumber = new PhoneNumber(phoneNumber);
		_isMMS = false;
		_isSent = false;
	}

	public Message(string text, string phoneNumber, bool sent) {
		_timeStamp = 0;
		_text = text;
		_multi = null;
		_phoneNumber = new PhoneNumber(phoneNumber);
		_isMMS = false;
		_isSent = sent;
	}

	public Message(string text, string phoneNumber, bool sent, ulong time) {
		_timeStamp = time;
		_text = text;
		_multi = null;
		_phoneNumber = new PhoneNumber(phoneNumber);
		_isMMS = false;
		_isSent = sent;
	}

	public override string ToString() {
		if (this == null) {
			return "null";
		}
		else {
			if (_isSent) {
				return "Me: " + _text + "\n";
			}
			if (_who.CompareTo("") == 0)
				return _phoneNumber.Number + ": " + _text + "\n";
			else
				return _who + ": " + _text + "\n";
		}
	}

	public int CompareTo(Message other) {
		if (other == null)
			return 1;
		else
			return this.Time.CompareTo(other.Time);
	}
}

