﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Connection
{
	private bool _isActive
	{
		get;
		set;
	}

	private string _deviceID
	{
		get;
		set;
	}

	public virtual Command Command
	{
		get;
		set;
	}

	public virtual bool Ping()
	{
		throw new System.NotImplementedException();
	}

}

