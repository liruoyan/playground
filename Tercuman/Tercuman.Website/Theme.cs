﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tercuman.Website
{
	public class Theme
	{
		public string Name { get; set; }

		public string BasePath { get; set; }

		public string Path { get { return String.Format("~/{0}/{1}/", BasePath, Name); } }

		public bool RightToLeft { get; set; }

		public Theme(string basePath, string name, bool rightToLeft = false)
		{
			RightToLeft = rightToLeft;
			Name = name;
			BasePath = basePath;
		}
	}
}