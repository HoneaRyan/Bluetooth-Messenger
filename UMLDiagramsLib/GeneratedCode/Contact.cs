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

public class Contact
{
	private string _name
	{
		get;
		set;
	}

	private Stream _picture
	{
		get;
		set;
	}

	private List<PhoneNum> _numbers
	{
		get;
		set;
	}

	public virtual IEnumerable<PhoneNumber> PhoneNumber
	{
		get;
		set;
	}

}

