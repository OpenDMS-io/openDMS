﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OpenDentBusiness.AutoComm;
using OpenDentBusiness.WebTypes.AutoComm;

namespace OpenDentBusiness {
	///<summary>Web Sched recall reminders that may have been sent via EConnector to HQ.</summary>
	[CrudTable(HasBatchWriteMethods=true)]
	public class WebSchedRecall:AutoCommGuid {
		///<summary>PK. Generated by HQ.</summary>
		[CrudColumn(IsPriKey=true)]
		public long WebSchedRecallNum;
		///<summary>FK to recall.RecallNum. Generated by OD.</summary>
		public long RecallNum;
		///<summary>The date that the recall is due.</summary>
		[XmlIgnore]
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		public DateTime DateDue;
		///<summary>The number of reminders that have been sent for this recall.</summary>
		[XmlIgnore]
		public int ReminderCount;
		/// <summary>Enum:ContactMethod </summary>
		///<summary>The most recent time that sending a reminder failed. Will be 01/01/0001 if a reminder has never been attempted.</summary>
		[CrudColumn(SpecialType=CrudSpecialColType.DateT)]
		[XmlIgnore]
		public DateTime DateTimeSendFailed;
		///<summary>Enum:WebSchedRecallSource Where this row came from.</summary>
		public WebSchedRecallSource Source;
		///<summary>FK to commlog associated to this WebSchedRecall.</summary>
		[XmlIgnore]
		public long CommlogNum;
		///<summary>Stores the information for the WebSchedRecalls that are grouped with this WebSchedRecall instance's message.  Only used to send to HQ
		///in a group.</summary>
		[CrudColumn(IsNotDbColumn=true)]
		public List<WebSchedAgg.WebSchedRecallFam> ListWebSchedRecallFams=new List<WebSchedAgg.WebSchedRecallFam>();
	}
	
	public enum AutoCommStatus {
		///<summary>0 - Should not be in the database but can be used in the program.</summary>
		Undefined,
		///<summary>1 - Do not send a reminder.</summary>
		DoNotSend,
		///<summary>2 - Has not been attempted to send yet.</summary>
		SendNotAttempted,
		///<summary>3 - Has been sent successfully.</summary>
		SendSuccessful,
		///<summary>4 - Attempted to send but not successful.</summary>
		SendFailed,
		///<summary>5 - Has been sent successfully, awaiting receipt.</summary>
		SentAwaitingReceipt,
	}

	public enum WebSchedRecallSource {
		///<summary>0 - Should not be in the database.</summary>
		Undefined,
		///<summary>1 - Originated from a user clicking the Web Sched button in the Recall List.</summary>
		FormRecallList,
		///<summary>2 - The eConnector created this row in the Auto Comm Web Sched thread.</summary>
		EConnectorAutoComm,
	}

}
