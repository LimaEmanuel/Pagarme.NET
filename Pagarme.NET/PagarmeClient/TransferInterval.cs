using System;using System.Runtime.Serialization;namespace PagarmeClient{	public enum TransferInterval	{		[Base.EnumValue("daily")]		Daily,		[Base.EnumValue("weekly")]		Weekly,		[Base.EnumValue("monthly")]		Monthly	}}

