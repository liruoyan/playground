Time and Count Buffered BufferingAppenderSkeleton: DoubleBufferingAppenderSkeleton
===================
[![efaruk MyGet Build Status](https://www.myget.org/BuildSource/Badge/efaruk?identifier=80412953-5b8c-4baf-bc52-a5331755bdef)](https://www.myget.org/)

Example Config:

	<appender name="DoubleBufferingAppender" type="log4net.Appender.Ark.DoubleBufferingAppenderSkeleton">
	    <MaxBufferSize value="10" />
	    <TimeThreshold value="60" />
	    <layout type="log4net.Layout.PatternLayout">
	    <conversionPattern value="%message %exception %aspnet-request" />
	    </layout>
	    <parameter>
	    <parameterName value="StackTrace" />
	    <layout type="log4net.Layout.PatternLayout">
	        <conversionPattern value="%stacktrace" />
	    </layout>
	    </parameter>
	    <parameter>
	    <parameterName value="Exception" />
	    <layout type="log4net.Layout.PatternLayout">
	        <conversionPattern value="%exception" />
	    </layout>
	    </parameter>
	    <filter type="log4net.Filter.LevelRangeFilter">
	    <levelMin value="ALL" />
	    <levelMax value="EMERGENCY" />
	    </filter>
	</appender>


Example Code to Extend:

	public class CustomDoubleBufferingAppender: DoubleBufferingAppenderSkeleton
    {
        protected override void BulkSend(IEnumerable<ExtendedLoggingEvent> customLoggingEvents)
        {
            //send bulk events to some where...
        }
    }

If you need custom parameters, override ConvertLoggingEvent:

	
	protected override ExtendedLoggingEvent ConvertLoggingEvent(LoggingEvent loggingEvent, IEnumerable<LayoutParameter> parameters)
    {
        var extendedLoggingEvent = base.ConvertLoggingEvent(loggingEvent, parameters);
        extendedLoggingEvent.CustomParameters.Add(new ExtendedLoggingEventParameter("CustomParameter1", "CustomValue"));
        return extendedLoggingEvent;
    }

Happy logging...