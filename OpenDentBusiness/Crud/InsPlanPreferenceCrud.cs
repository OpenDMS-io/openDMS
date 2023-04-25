//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class InsPlanPreferenceCrud {
		///<summary>Gets one InsPlanPreference object from the database using the primary key.  Returns null if not found.</summary>
		public static InsPlanPreference SelectOne(long insPlanPrefNum) {
			string command="SELECT * FROM insplanpreference "
				+"WHERE InsPlanPrefNum = "+POut.Long(insPlanPrefNum);
			List<InsPlanPreference> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsPlanPreference object from the database using a query.</summary>
		public static InsPlanPreference SelectOne(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsPlanPreference> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsPlanPreference objects from the database using a query.</summary>
		public static List<InsPlanPreference> SelectMany(string command) {
			if(RemotingClient.MiddleTierRole==MiddleTierRole.ClientMT) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsPlanPreference> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsPlanPreference> TableToList(DataTable table) {
			List<InsPlanPreference> retVal=new List<InsPlanPreference>();
			InsPlanPreference insPlanPreference;
			foreach(DataRow row in table.Rows) {
				insPlanPreference=new InsPlanPreference();
				insPlanPreference.InsPlanPrefNum= PIn.Long  (row["InsPlanPrefNum"].ToString());
				insPlanPreference.PlanNum       = PIn.Long  (row["PlanNum"].ToString());
				insPlanPreference.FKey          = PIn.Long  (row["FKey"].ToString());
				insPlanPreference.FKeyType      = (OpenDentBusiness.InsPlanPrefFKeyType)PIn.Int(row["FKeyType"].ToString());
				insPlanPreference.ValueString   = PIn.String(row["ValueString"].ToString());
				retVal.Add(insPlanPreference);
			}
			return retVal;
		}

		///<summary>Converts a list of InsPlanPreference into a DataTable.</summary>
		public static DataTable ListToTable(List<InsPlanPreference> listInsPlanPreferences,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="InsPlanPreference";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("InsPlanPrefNum");
			table.Columns.Add("PlanNum");
			table.Columns.Add("FKey");
			table.Columns.Add("FKeyType");
			table.Columns.Add("ValueString");
			foreach(InsPlanPreference insPlanPreference in listInsPlanPreferences) {
				table.Rows.Add(new object[] {
					POut.Long  (insPlanPreference.InsPlanPrefNum),
					POut.Long  (insPlanPreference.PlanNum),
					POut.Long  (insPlanPreference.FKey),
					POut.Int   ((int)insPlanPreference.FKeyType),
					            insPlanPreference.ValueString,
				});
			}
			return table;
		}

		///<summary>Inserts one InsPlanPreference into the database.  Returns the new priKey.</summary>
		public static long Insert(InsPlanPreference insPlanPreference) {
			return Insert(insPlanPreference,false);
		}

		///<summary>Inserts one InsPlanPreference into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsPlanPreference insPlanPreference,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				insPlanPreference.InsPlanPrefNum=ReplicationServers.GetKey("insplanpreference","InsPlanPrefNum");
			}
			string command="INSERT INTO insplanpreference (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InsPlanPrefNum,";
			}
			command+="PlanNum,FKey,FKeyType,ValueString) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insPlanPreference.InsPlanPrefNum)+",";
			}
			command+=
				     POut.Long  (insPlanPreference.PlanNum)+","
				+    POut.Long  (insPlanPreference.FKey)+","
				+    POut.Int   ((int)insPlanPreference.FKeyType)+","
				+    DbHelper.ParamChar+"paramValueString)";
			if(insPlanPreference.ValueString==null) {
				insPlanPreference.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(insPlanPreference.ValueString));
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command,paramValueString);
			}
			else {
				insPlanPreference.InsPlanPrefNum=Db.NonQ(command,true,"InsPlanPrefNum","insPlanPreference",paramValueString);
			}
			return insPlanPreference.InsPlanPrefNum;
		}

		///<summary>Inserts one InsPlanPreference into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsPlanPreference insPlanPreference) {
			return InsertNoCache(insPlanPreference,false);
		}

		///<summary>Inserts one InsPlanPreference into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsPlanPreference insPlanPreference,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO insplanpreference (";
			if(!useExistingPK && isRandomKeys) {
				insPlanPreference.InsPlanPrefNum=ReplicationServers.GetKeyNoCache("insplanpreference","InsPlanPrefNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="InsPlanPrefNum,";
			}
			command+="PlanNum,FKey,FKeyType,ValueString) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(insPlanPreference.InsPlanPrefNum)+",";
			}
			command+=
				     POut.Long  (insPlanPreference.PlanNum)+","
				+    POut.Long  (insPlanPreference.FKey)+","
				+    POut.Int   ((int)insPlanPreference.FKeyType)+","
				+    DbHelper.ParamChar+"paramValueString)";
			if(insPlanPreference.ValueString==null) {
				insPlanPreference.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(insPlanPreference.ValueString));
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command,paramValueString);
			}
			else {
				insPlanPreference.InsPlanPrefNum=Db.NonQ(command,true,"InsPlanPrefNum","insPlanPreference",paramValueString);
			}
			return insPlanPreference.InsPlanPrefNum;
		}

		///<summary>Updates one InsPlanPreference in the database.</summary>
		public static void Update(InsPlanPreference insPlanPreference) {
			string command="UPDATE insplanpreference SET "
				+"PlanNum       =  "+POut.Long  (insPlanPreference.PlanNum)+", "
				+"FKey          =  "+POut.Long  (insPlanPreference.FKey)+", "
				+"FKeyType      =  "+POut.Int   ((int)insPlanPreference.FKeyType)+", "
				+"ValueString   =  "+DbHelper.ParamChar+"paramValueString "
				+"WHERE InsPlanPrefNum = "+POut.Long(insPlanPreference.InsPlanPrefNum);
			if(insPlanPreference.ValueString==null) {
				insPlanPreference.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(insPlanPreference.ValueString));
			Db.NonQ(command,paramValueString);
		}

		///<summary>Updates one InsPlanPreference in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(InsPlanPreference insPlanPreference,InsPlanPreference oldInsPlanPreference) {
			string command="";
			if(insPlanPreference.PlanNum != oldInsPlanPreference.PlanNum) {
				if(command!="") { command+=",";}
				command+="PlanNum = "+POut.Long(insPlanPreference.PlanNum)+"";
			}
			if(insPlanPreference.FKey != oldInsPlanPreference.FKey) {
				if(command!="") { command+=",";}
				command+="FKey = "+POut.Long(insPlanPreference.FKey)+"";
			}
			if(insPlanPreference.FKeyType != oldInsPlanPreference.FKeyType) {
				if(command!="") { command+=",";}
				command+="FKeyType = "+POut.Int   ((int)insPlanPreference.FKeyType)+"";
			}
			if(insPlanPreference.ValueString != oldInsPlanPreference.ValueString) {
				if(command!="") { command+=",";}
				command+="ValueString = "+DbHelper.ParamChar+"paramValueString";
			}
			if(command=="") {
				return false;
			}
			if(insPlanPreference.ValueString==null) {
				insPlanPreference.ValueString="";
			}
			OdSqlParameter paramValueString=new OdSqlParameter("paramValueString",OdDbType.Text,POut.StringParam(insPlanPreference.ValueString));
			command="UPDATE insplanpreference SET "+command
				+" WHERE InsPlanPrefNum = "+POut.Long(insPlanPreference.InsPlanPrefNum);
			Db.NonQ(command,paramValueString);
			return true;
		}

		///<summary>Returns true if Update(InsPlanPreference,InsPlanPreference) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(InsPlanPreference insPlanPreference,InsPlanPreference oldInsPlanPreference) {
			if(insPlanPreference.PlanNum != oldInsPlanPreference.PlanNum) {
				return true;
			}
			if(insPlanPreference.FKey != oldInsPlanPreference.FKey) {
				return true;
			}
			if(insPlanPreference.FKeyType != oldInsPlanPreference.FKeyType) {
				return true;
			}
			if(insPlanPreference.ValueString != oldInsPlanPreference.ValueString) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one InsPlanPreference from the database.</summary>
		public static void Delete(long insPlanPrefNum) {
			string command="DELETE FROM insplanpreference "
				+"WHERE InsPlanPrefNum = "+POut.Long(insPlanPrefNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many InsPlanPreferences from the database.</summary>
		public static void DeleteMany(List<long> listInsPlanPrefNums) {
			if(listInsPlanPrefNums==null || listInsPlanPrefNums.Count==0) {
				return;
			}
			string command="DELETE FROM insplanpreference "
				+"WHERE InsPlanPrefNum IN("+string.Join(",",listInsPlanPrefNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}