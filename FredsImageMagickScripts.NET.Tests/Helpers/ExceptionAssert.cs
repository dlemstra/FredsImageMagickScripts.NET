﻿//=================================================================================================
// Copyright 2015 Dirk Lemstra, Fred Weinhaus
// <https://github.com/dlemstra/FredsImageMagickScripts.NET>
//
// These scripts are available free of charge for non-commercial use, ONLY.
//
// For use of these scripts in commercial (for-profit) environments or non-free applications,
// please contact Fred Weinhaus (fmw at alink dot net) for licensing arrangements.
//
// If you: 1) redistribute, 2) incorporate any of these scripts into other free applications or
// 3) reprogram them in another scripting language, then you must contact Fred Weinhaus for
// permission, especially if the result might be used in a commercial or for-profit environment.
//
// Usage, whether stated or not in the script, is restricted to the above licensing arrangements.
// It is also subject, in a subordinate manner, to the ImageMagick license, which can be found at:
// http://www.imagemagick.org/script/license.php
//=================================================================================================

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FredsImageMagickScripts.NET.Tests
{
	//==============================================================================================
	public static class ExceptionAssert
	{
		//===========================================================================================
		private static void Fail(string message, params object[] arguments)
		{
			if (arguments != null && arguments.Length > 0)
				Assert.Fail(String.Format(CultureInfo.InvariantCulture, message, arguments));
			else
				Assert.Fail(message);
		}
		//===========================================================================================
		public static void Throws<TException>(Action action)
			 where TException : Exception
		{
			Throws<TException>(action, "Exception of type {0} was not thrown.", typeof(TException).Name);
		}
		//===========================================================================================
		public static void Throws<TException>(Action action, string message, params object[] arguments)
			 where TException : Exception
		{
			try
			{
				action();
				Fail(message, arguments);
			}
			catch (TException exception)
			{
				Type type = exception.GetType();
				if (type != typeof(TException))
					Fail("Exception of type {0} was not thrown an exception of type {1} was thrown.", typeof(TException).Name, type.Name);
			}
			catch (Exception)
			{
				throw;
			}
		}
		//===========================================================================================
	}
	//==============================================================================================
}