//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class JobQuoteCrud {
		///<summary>Gets one JobQuote object from the database using the primary key.  Returns null if not found.</summary>
		public static JobQuote SelectOne(long jobQuoteNum) {
			string command="SELECT * FROM jobquote "
				+"WHERE JobQuoteNum = "+POut.Long(jobQuoteNum);
			List<JobQuote> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one JobQuote object from the database using a query.</summary>
		public static JobQuote SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<JobQuote> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of JobQuote objects from the database using a query.</summary>
		public static List<JobQuote> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<JobQuote> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<JobQuote> TableToList(DataTable table) {
			List<JobQuote> retVal=new List<JobQuote>();
			JobQuote jobQuote;
			foreach(DataRow row in table.Rows) {
				jobQuote=new JobQuote();
				jobQuote.JobQuoteNum       = PIn.Long  (row["JobQuoteNum"].ToString());
				jobQuote.JobNum            = PIn.Long  (row["JobNum"].ToString());
				jobQuote.PatNum            = PIn.Long  (row["PatNum"].ToString());
				jobQuote.Amount            = PIn.String(row["Amount"].ToString());
				jobQuote.Note              = PIn.String(row["Note"].ToString());
				jobQuote.Hours             = PIn.String(row["Hours"].ToString());
				jobQuote.ApprovedAmount    = PIn.String(row["ApprovedAmount"].ToString());
				jobQuote.IsCustomerApproved= PIn.Bool  (row["IsCustomerApproved"].ToString());
				retVal.Add(jobQuote);
			}
			return retVal;
		}

		///<summary>Converts a list of JobQuote into a DataTable.</summary>
		public static DataTable ListToTable(List<JobQuote> listJobQuotes,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="JobQuote";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("JobQuoteNum");
			table.Columns.Add("JobNum");
			table.Columns.Add("PatNum");
			table.Columns.Add("Amount");
			table.Columns.Add("Note");
			table.Columns.Add("Hours");
			table.Columns.Add("ApprovedAmount");
			table.Columns.Add("IsCustomerApproved");
			foreach(JobQuote jobQuote in listJobQuotes) {
				table.Rows.Add(new object[] {
					POut.Long  (jobQuote.JobQuoteNum),
					POut.Long  (jobQuote.JobNum),
					POut.Long  (jobQuote.PatNum),
					            jobQuote.Amount,
					            jobQuote.Note,
					            jobQuote.Hours,
					            jobQuote.ApprovedAmount,
					POut.Bool  (jobQuote.IsCustomerApproved),
				});
			}
			return table;
		}

		///<summary>Inserts one JobQuote into the database.  Returns the new priKey.</summary>
		public static long Insert(JobQuote jobQuote) {
			return Insert(jobQuote,false);
		}

		///<summary>Inserts one JobQuote into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(JobQuote jobQuote,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				jobQuote.JobQuoteNum=ReplicationServers.GetKey("jobquote","JobQuoteNum");
			}
			string command="INSERT INTO jobquote (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="JobQuoteNum,";
			}
			command+="JobNum,PatNum,Amount,Note,Hours,ApprovedAmount,IsCustomerApproved) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(jobQuote.JobQuoteNum)+",";
			}
			command+=
				     POut.Long  (jobQuote.JobNum)+","
				+    POut.Long  (jobQuote.PatNum)+","
				+"'"+POut.String(jobQuote.Amount)+"',"
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(jobQuote.Hours)+"',"
				+"'"+POut.String(jobQuote.ApprovedAmount)+"',"
				+    POut.Bool  (jobQuote.IsCustomerApproved)+")";
			if(jobQuote.Note==null) {
				jobQuote.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(jobQuote.Note));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramNote);
			}
			else {
				jobQuote.JobQuoteNum=Db.NonQ(command,true,"JobQuoteNum","jobQuote",paramNote);
			}
			return jobQuote.JobQuoteNum;
		}

		///<summary>Inserts one JobQuote into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(JobQuote jobQuote) {
			return InsertNoCache(jobQuote,false);
		}

		///<summary>Inserts one JobQuote into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(JobQuote jobQuote,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO jobquote (";
			if(!useExistingPK && isRandomKeys) {
				jobQuote.JobQuoteNum=ReplicationServers.GetKeyNoCache("jobquote","JobQuoteNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="JobQuoteNum,";
			}
			command+="JobNum,PatNum,Amount,Note,Hours,ApprovedAmount,IsCustomerApproved) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(jobQuote.JobQuoteNum)+",";
			}
			command+=
				     POut.Long  (jobQuote.JobNum)+","
				+    POut.Long  (jobQuote.PatNum)+","
				+"'"+POut.String(jobQuote.Amount)+"',"
				+    DbHelper.ParamChar+"paramNote,"
				+"'"+POut.String(jobQuote.Hours)+"',"
				+"'"+POut.String(jobQuote.ApprovedAmount)+"',"
				+    POut.Bool  (jobQuote.IsCustomerApproved)+")";
			if(jobQuote.Note==null) {
				jobQuote.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(jobQuote.Note));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramNote);
			}
			else {
				jobQuote.JobQuoteNum=Db.NonQ(command,true,"JobQuoteNum","jobQuote",paramNote);
			}
			return jobQuote.JobQuoteNum;
		}

		///<summary>Updates one JobQuote in the database.</summary>
		public static void Update(JobQuote jobQuote) {
			string command="UPDATE jobquote SET "
				+"JobNum            =  "+POut.Long  (jobQuote.JobNum)+", "
				+"PatNum            =  "+POut.Long  (jobQuote.PatNum)+", "
				+"Amount            = '"+POut.String(jobQuote.Amount)+"', "
				+"Note              =  "+DbHelper.ParamChar+"paramNote, "
				+"Hours             = '"+POut.String(jobQuote.Hours)+"', "
				+"ApprovedAmount    = '"+POut.String(jobQuote.ApprovedAmount)+"', "
				+"IsCustomerApproved=  "+POut.Bool  (jobQuote.IsCustomerApproved)+" "
				+"WHERE JobQuoteNum = "+POut.Long(jobQuote.JobQuoteNum);
			if(jobQuote.Note==null) {
				jobQuote.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(jobQuote.Note));
			Db.NonQ(command,paramNote);
		}

		///<summary>Updates one JobQuote in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(JobQuote jobQuote,JobQuote oldJobQuote) {
			string command="";
			if(jobQuote.JobNum != oldJobQuote.JobNum) {
				if(command!="") { command+=",";}
				command+="JobNum = "+POut.Long(jobQuote.JobNum)+"";
			}
			if(jobQuote.PatNum != oldJobQuote.PatNum) {
				if(command!="") { command+=",";}
				command+="PatNum = "+POut.Long(jobQuote.PatNum)+"";
			}
			if(jobQuote.Amount != oldJobQuote.Amount) {
				if(command!="") { command+=",";}
				command+="Amount = '"+POut.String(jobQuote.Amount)+"'";
			}
			if(jobQuote.Note != oldJobQuote.Note) {
				if(command!="") { command+=",";}
				command+="Note = "+DbHelper.ParamChar+"paramNote";
			}
			if(jobQuote.Hours != oldJobQuote.Hours) {
				if(command!="") { command+=",";}
				command+="Hours = '"+POut.String(jobQuote.Hours)+"'";
			}
			if(jobQuote.ApprovedAmount != oldJobQuote.ApprovedAmount) {
				if(command!="") { command+=",";}
				command+="ApprovedAmount = '"+POut.String(jobQuote.ApprovedAmount)+"'";
			}
			if(jobQuote.IsCustomerApproved != oldJobQuote.IsCustomerApproved) {
				if(command!="") { command+=",";}
				command+="IsCustomerApproved = "+POut.Bool(jobQuote.IsCustomerApproved)+"";
			}
			if(command=="") {
				return false;
			}
			if(jobQuote.Note==null) {
				jobQuote.Note="";
			}
			OdSqlParameter paramNote=new OdSqlParameter("paramNote",OdDbType.Text,POut.StringParam(jobQuote.Note));
			command="UPDATE jobquote SET "+command
				+" WHERE JobQuoteNum = "+POut.Long(jobQuote.JobQuoteNum);
			Db.NonQ(command,paramNote);
			return true;
		}

		///<summary>Returns true if Update(JobQuote,JobQuote) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(JobQuote jobQuote,JobQuote oldJobQuote) {
			if(jobQuote.JobNum != oldJobQuote.JobNum) {
				return true;
			}
			if(jobQuote.PatNum != oldJobQuote.PatNum) {
				return true;
			}
			if(jobQuote.Amount != oldJobQuote.Amount) {
				return true;
			}
			if(jobQuote.Note != oldJobQuote.Note) {
				return true;
			}
			if(jobQuote.Hours != oldJobQuote.Hours) {
				return true;
			}
			if(jobQuote.ApprovedAmount != oldJobQuote.ApprovedAmount) {
				return true;
			}
			if(jobQuote.IsCustomerApproved != oldJobQuote.IsCustomerApproved) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one JobQuote from the database.</summary>
		public static void Delete(long jobQuoteNum) {
			string command="DELETE FROM jobquote "
				+"WHERE JobQuoteNum = "+POut.Long(jobQuoteNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many JobQuotes from the database.</summary>
		public static void DeleteMany(List<long> listJobQuoteNums) {
			if(listJobQuoteNums==null || listJobQuoteNums.Count==0) {
				return;
			}
			string command="DELETE FROM jobquote "
				+"WHERE JobQuoteNum IN("+string.Join(",",listJobQuoteNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

		///<summary>Inserts, updates, or deletes database rows to match supplied list.  Returns true if db changes were made.</summary>
		public static bool Sync(List<JobQuote> listNew,List<JobQuote> listDB) {
			//Adding items to lists changes the order of operation. All inserts are completed first, then updates, then deletes.
			List<JobQuote> listIns    =new List<JobQuote>();
			List<JobQuote> listUpdNew =new List<JobQuote>();
			List<JobQuote> listUpdDB  =new List<JobQuote>();
			List<JobQuote> listDel    =new List<JobQuote>();
			listNew.Sort((JobQuote x,JobQuote y) => { return x.JobQuoteNum.CompareTo(y.JobQuoteNum); });
			listDB.Sort((JobQuote x,JobQuote y) => { return x.JobQuoteNum.CompareTo(y.JobQuoteNum); });
			int idxNew=0;
			int idxDB=0;
			int rowsUpdatedCount=0;
			JobQuote fieldNew;
			JobQuote fieldDB;
			//Because both lists have been sorted using the same criteria, we can now walk each list to determine which list contians the next element.  The next element is determined by Primary Key.
			//If the New list contains the next item it will be inserted.  If the DB contains the next item, it will be deleted.  If both lists contain the next item, the item will be updated.
			while(idxNew<listNew.Count || idxDB<listDB.Count) {
				fieldNew=null;
				if(idxNew<listNew.Count) {
					fieldNew=listNew[idxNew];
				}
				fieldDB=null;
				if(idxDB<listDB.Count) {
					fieldDB=listDB[idxDB];
				}
				//begin compare
				if(fieldNew!=null && fieldDB==null) {//listNew has more items, listDB does not.
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew==null && fieldDB!=null) {//listDB has more items, listNew does not.
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				else if(fieldNew.JobQuoteNum<fieldDB.JobQuoteNum) {//newPK less than dbPK, newItem is 'next'
					listIns.Add(fieldNew);
					idxNew++;
					continue;
				}
				else if(fieldNew.JobQuoteNum>fieldDB.JobQuoteNum) {//dbPK less than newPK, dbItem is 'next'
					listDel.Add(fieldDB);
					idxDB++;
					continue;
				}
				//Both lists contain the 'next' item, update required
				listUpdNew.Add(fieldNew);
				listUpdDB.Add(fieldDB);
				idxNew++;
				idxDB++;
			}
			//Commit changes to DB
			for(int i=0;i<listIns.Count;i++) {
				Insert(listIns[i]);
			}
			for(int i=0;i<listUpdNew.Count;i++) {
				if(Update(listUpdNew[i],listUpdDB[i])) {
					rowsUpdatedCount++;
				}
			}
			DeleteMany(listDel.Select(x => x.JobQuoteNum).ToList());
			if(rowsUpdatedCount>0 || listIns.Count>0 || listDel.Count>0) {
				return true;
			}
			return false;
		}

	}
}