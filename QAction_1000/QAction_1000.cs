using System;

using Skyline.DataMiner.Scripting;

/// <summary>
/// DataMiner QAction Class: QActionName.
/// </summary>
public class QAction
{
	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public static void Run(SLProtocolExt protocol)
	{
		protocol.SetParameter(Parameter.responsestatus_3000, "Received at " + DateTime.Now);
		String myKey = Convert.ToString(protocol.GetParameter(Parameter.indexdatapacket_1000));

		string receivedData = Convert.ToString(protocol.Datapacket_1001);
		MytableQActionRow row = new MytableQActionRow
		{
			Myindex_2001 = myKey,
			Mydata_2002 = receivedData,
		};

		protocol.Log("QA" + protocol.QActionID + "|Setting Row|"+myKey, LogType.Error, LogLevel.NoLogging);
		protocol.mytable.SetRow(row,true);
	}
}