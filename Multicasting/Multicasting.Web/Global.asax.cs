﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Multicasting.Web
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			GlobalModule module = GlobalModule.Instance;
			MulticastReceiver.MessageReceived += module.MulticastReceiver_MessageReceived;
			
			ThreadPool.QueueUserWorkItem(t => MulticastReceiver.Start());
		}
	}
}
