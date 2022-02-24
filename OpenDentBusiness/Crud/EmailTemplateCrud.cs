//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class EmailTemplateCrud {
		///<summary>Gets one EmailTemplate object from the database using the primary key.  Returns null if not found.</summary>
		public static EmailTemplate SelectOne(long emailTemplateNum) {
			string command="SELECT * FROM emailtemplate "
				+"WHERE EmailTemplateNum = "+POut.Long(emailTemplateNum);
			List<EmailTemplate> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one EmailTemplate object from the database using a query.</summary>
		public static EmailTemplate SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailTemplate> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of EmailTemplate objects from the database using a query.</summary>
		public static List<EmailTemplate> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<EmailTemplate> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<EmailTemplate> TableToList(DataTable table) {
			List<EmailTemplate> retVal=new List<EmailTemplate>();
			EmailTemplate emailTemplate;
			foreach(DataRow row in table.Rows) {
				emailTemplate=new EmailTemplate();
				emailTemplate.EmailTemplateNum= PIn.Long  (row["EmailTemplateNum"].ToString());
				emailTemplate.Subject         = PIn.String(row["Subject"].ToString());
				emailTemplate.BodyText        = PIn.String(row["BodyText"].ToString());
				emailTemplate.Description     = PIn.String(row["Description"].ToString());
				emailTemplate.TemplateType    = (OpenDentBusiness.EmailType)PIn.Int(row["TemplateType"].ToString());
				retVal.Add(emailTemplate);
			}
			return retVal;
		}

		///<summary>Converts a list of EmailTemplate into a DataTable.</summary>
		public static DataTable ListToTable(List<EmailTemplate> listEmailTemplates,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="EmailTemplate";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("EmailTemplateNum");
			table.Columns.Add("Subject");
			table.Columns.Add("BodyText");
			table.Columns.Add("Description");
			table.Columns.Add("TemplateType");
			foreach(EmailTemplate emailTemplate in listEmailTemplates) {
				table.Rows.Add(new object[] {
					POut.Long  (emailTemplate.EmailTemplateNum),
					            emailTemplate.Subject,
					            emailTemplate.BodyText,
					            emailTemplate.Description,
					POut.Int   ((int)emailTemplate.TemplateType),
				});
			}
			return table;
		}

		///<summary>Inserts one EmailTemplate into the database.  Returns the new priKey.</summary>
		public static long Insert(EmailTemplate emailTemplate) {
			return Insert(emailTemplate,false);
		}

		///<summary>Inserts one EmailTemplate into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(EmailTemplate emailTemplate,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				emailTemplate.EmailTemplateNum=ReplicationServers.GetKey("emailtemplate","EmailTemplateNum");
			}
			string command="INSERT INTO emailtemplate (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="EmailTemplateNum,";
			}
			command+="Subject,BodyText,Description,TemplateType) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(emailTemplate.EmailTemplateNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramSubject,"
				+    DbHelper.ParamChar+"paramBodyText,"
				+    DbHelper.ParamChar+"paramDescription,"
				+    POut.Int   ((int)emailTemplate.TemplateType)+")";
			if(emailTemplate.Subject==null) {
				emailTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailTemplate.Subject));
			if(emailTemplate.BodyText==null) {
				emailTemplate.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailTemplate.BodyText));
			if(emailTemplate.Description==null) {
				emailTemplate.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(emailTemplate.Description));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramSubject,paramBodyText,paramDescription);
			}
			else {
				emailTemplate.EmailTemplateNum=Db.NonQ(command,true,"EmailTemplateNum","emailTemplate",paramSubject,paramBodyText,paramDescription);
			}
			return emailTemplate.EmailTemplateNum;
		}

		///<summary>Inserts one EmailTemplate into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailTemplate emailTemplate) {
			return InsertNoCache(emailTemplate,false);
		}

		///<summary>Inserts one EmailTemplate into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(EmailTemplate emailTemplate,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO emailtemplate (";
			if(!useExistingPK && isRandomKeys) {
				emailTemplate.EmailTemplateNum=ReplicationServers.GetKeyNoCache("emailtemplate","EmailTemplateNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="EmailTemplateNum,";
			}
			command+="Subject,BodyText,Description,TemplateType) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(emailTemplate.EmailTemplateNum)+",";
			}
			command+=
				     DbHelper.ParamChar+"paramSubject,"
				+    DbHelper.ParamChar+"paramBodyText,"
				+    DbHelper.ParamChar+"paramDescription,"
				+    POut.Int   ((int)emailTemplate.TemplateType)+")";
			if(emailTemplate.Subject==null) {
				emailTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailTemplate.Subject));
			if(emailTemplate.BodyText==null) {
				emailTemplate.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailTemplate.BodyText));
			if(emailTemplate.Description==null) {
				emailTemplate.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(emailTemplate.Description));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramSubject,paramBodyText,paramDescription);
			}
			else {
				emailTemplate.EmailTemplateNum=Db.NonQ(command,true,"EmailTemplateNum","emailTemplate",paramSubject,paramBodyText,paramDescription);
			}
			return emailTemplate.EmailTemplateNum;
		}

		///<summary>Updates one EmailTemplate in the database.</summary>
		public static void Update(EmailTemplate emailTemplate) {
			string command="UPDATE emailtemplate SET "
				+"Subject         =  "+DbHelper.ParamChar+"paramSubject, "
				+"BodyText        =  "+DbHelper.ParamChar+"paramBodyText, "
				+"Description     =  "+DbHelper.ParamChar+"paramDescription, "
				+"TemplateType    =  "+POut.Int   ((int)emailTemplate.TemplateType)+" "
				+"WHERE EmailTemplateNum = "+POut.Long(emailTemplate.EmailTemplateNum);
			if(emailTemplate.Subject==null) {
				emailTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailTemplate.Subject));
			if(emailTemplate.BodyText==null) {
				emailTemplate.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailTemplate.BodyText));
			if(emailTemplate.Description==null) {
				emailTemplate.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(emailTemplate.Description));
			Db.NonQ(command,paramSubject,paramBodyText,paramDescription);
		}

		///<summary>Updates one EmailTemplate in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(EmailTemplate emailTemplate,EmailTemplate oldEmailTemplate) {
			string command="";
			if(emailTemplate.Subject != oldEmailTemplate.Subject) {
				if(command!="") { command+=",";}
				command+="Subject = "+DbHelper.ParamChar+"paramSubject";
			}
			if(emailTemplate.BodyText != oldEmailTemplate.BodyText) {
				if(command!="") { command+=",";}
				command+="BodyText = "+DbHelper.ParamChar+"paramBodyText";
			}
			if(emailTemplate.Description != oldEmailTemplate.Description) {
				if(command!="") { command+=",";}
				command+="Description = "+DbHelper.ParamChar+"paramDescription";
			}
			if(emailTemplate.TemplateType != oldEmailTemplate.TemplateType) {
				if(command!="") { command+=",";}
				command+="TemplateType = "+POut.Int   ((int)emailTemplate.TemplateType)+"";
			}
			if(command=="") {
				return false;
			}
			if(emailTemplate.Subject==null) {
				emailTemplate.Subject="";
			}
			OdSqlParameter paramSubject=new OdSqlParameter("paramSubject",OdDbType.Text,POut.StringParam(emailTemplate.Subject));
			if(emailTemplate.BodyText==null) {
				emailTemplate.BodyText="";
			}
			OdSqlParameter paramBodyText=new OdSqlParameter("paramBodyText",OdDbType.Text,POut.StringParam(emailTemplate.BodyText));
			if(emailTemplate.Description==null) {
				emailTemplate.Description="";
			}
			OdSqlParameter paramDescription=new OdSqlParameter("paramDescription",OdDbType.Text,POut.StringParam(emailTemplate.Description));
			command="UPDATE emailtemplate SET "+command
				+" WHERE EmailTemplateNum = "+POut.Long(emailTemplate.EmailTemplateNum);
			Db.NonQ(command,paramSubject,paramBodyText,paramDescription);
			return true;
		}

		///<summary>Returns true if Update(EmailTemplate,EmailTemplate) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(EmailTemplate emailTemplate,EmailTemplate oldEmailTemplate) {
			if(emailTemplate.Subject != oldEmailTemplate.Subject) {
				return true;
			}
			if(emailTemplate.BodyText != oldEmailTemplate.BodyText) {
				return true;
			}
			if(emailTemplate.Description != oldEmailTemplate.Description) {
				return true;
			}
			if(emailTemplate.TemplateType != oldEmailTemplate.TemplateType) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one EmailTemplate from the database.</summary>
		public static void Delete(long emailTemplateNum) {
			string command="DELETE FROM emailtemplate "
				+"WHERE EmailTemplateNum = "+POut.Long(emailTemplateNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many EmailTemplates from the database.</summary>
		public static void DeleteMany(List<long> listEmailTemplateNums) {
			if(listEmailTemplateNums==null || listEmailTemplateNums.Count==0) {
				return;
			}
			string command="DELETE FROM emailtemplate "
				+"WHERE EmailTemplateNum IN("+string.Join(",",listEmailTemplateNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}