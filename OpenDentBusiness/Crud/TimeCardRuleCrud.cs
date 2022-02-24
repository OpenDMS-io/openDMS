//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OpenDentBusiness.Crud{
	public class TimeCardRuleCrud {
		///<summary>Gets one TimeCardRule object from the database using the primary key.  Returns null if not found.</summary>
		public static TimeCardRule SelectOne(long timeCardRuleNum) {
			string command="SELECT * FROM timecardrule "
				+"WHERE TimeCardRuleNum = "+POut.Long(timeCardRuleNum);
			List<TimeCardRule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one TimeCardRule object from the database using a query.</summary>
		public static TimeCardRule SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TimeCardRule> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of TimeCardRule objects from the database using a query.</summary>
		public static List<TimeCardRule> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<TimeCardRule> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<TimeCardRule> TableToList(DataTable table) {
			List<TimeCardRule> retVal=new List<TimeCardRule>();
			TimeCardRule timeCardRule;
			foreach(DataRow row in table.Rows) {
				timeCardRule=new TimeCardRule();
				timeCardRule.TimeCardRuleNum = PIn.Long  (row["TimeCardRuleNum"].ToString());
				timeCardRule.EmployeeNum     = PIn.Long  (row["EmployeeNum"].ToString());
				timeCardRule.OverHoursPerDay = PIn.Time(row["OverHoursPerDay"].ToString());
				timeCardRule.AfterTimeOfDay  = PIn.Time(row["AfterTimeOfDay"].ToString());
				timeCardRule.BeforeTimeOfDay = PIn.Time(row["BeforeTimeOfDay"].ToString());
				timeCardRule.IsOvertimeExempt= PIn.Bool  (row["IsOvertimeExempt"].ToString());
				timeCardRule.MinClockInTime  = PIn.Time(row["MinClockInTime"].ToString());
				retVal.Add(timeCardRule);
			}
			return retVal;
		}

		///<summary>Converts a list of TimeCardRule into a DataTable.</summary>
		public static DataTable ListToTable(List<TimeCardRule> listTimeCardRules,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="TimeCardRule";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("TimeCardRuleNum");
			table.Columns.Add("EmployeeNum");
			table.Columns.Add("OverHoursPerDay");
			table.Columns.Add("AfterTimeOfDay");
			table.Columns.Add("BeforeTimeOfDay");
			table.Columns.Add("IsOvertimeExempt");
			table.Columns.Add("MinClockInTime");
			foreach(TimeCardRule timeCardRule in listTimeCardRules) {
				table.Rows.Add(new object[] {
					POut.Long  (timeCardRule.TimeCardRuleNum),
					POut.Long  (timeCardRule.EmployeeNum),
					POut.Time  (timeCardRule.OverHoursPerDay,false),
					POut.Time  (timeCardRule.AfterTimeOfDay,false),
					POut.Time  (timeCardRule.BeforeTimeOfDay,false),
					POut.Bool  (timeCardRule.IsOvertimeExempt),
					POut.Time  (timeCardRule.MinClockInTime,false),
				});
			}
			return table;
		}

		///<summary>Inserts one TimeCardRule into the database.  Returns the new priKey.</summary>
		public static long Insert(TimeCardRule timeCardRule) {
			return Insert(timeCardRule,false);
		}

		///<summary>Inserts one TimeCardRule into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(TimeCardRule timeCardRule,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				timeCardRule.TimeCardRuleNum=ReplicationServers.GetKey("timecardrule","TimeCardRuleNum");
			}
			string command="INSERT INTO timecardrule (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="TimeCardRuleNum,";
			}
			command+="EmployeeNum,OverHoursPerDay,AfterTimeOfDay,BeforeTimeOfDay,IsOvertimeExempt,MinClockInTime) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(timeCardRule.TimeCardRuleNum)+",";
			}
			command+=
				     POut.Long  (timeCardRule.EmployeeNum)+","
				+    POut.Time  (timeCardRule.OverHoursPerDay)+","
				+    POut.Time  (timeCardRule.AfterTimeOfDay)+","
				+    POut.Time  (timeCardRule.BeforeTimeOfDay)+","
				+    POut.Bool  (timeCardRule.IsOvertimeExempt)+","
				+    POut.Time  (timeCardRule.MinClockInTime)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				timeCardRule.TimeCardRuleNum=Db.NonQ(command,true,"TimeCardRuleNum","timeCardRule");
			}
			return timeCardRule.TimeCardRuleNum;
		}

		///<summary>Inserts many TimeCardRules into the database.</summary>
		public static void InsertMany(List<TimeCardRule> listTimeCardRules) {
			InsertMany(listTimeCardRules,false);
		}

		///<summary>Inserts many TimeCardRules into the database.  Provides option to use the existing priKey.</summary>
		public static void InsertMany(List<TimeCardRule> listTimeCardRules,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				foreach(TimeCardRule timeCardRule in listTimeCardRules) {
					Insert(timeCardRule);
				}
			}
			else {
				StringBuilder sbCommands=null;
				int index=0;
				int countRows=0;
				while(index < listTimeCardRules.Count) {
					TimeCardRule timeCardRule=listTimeCardRules[index];
					StringBuilder sbRow=new StringBuilder("(");
					bool hasComma=false;
					if(sbCommands==null) {
						sbCommands=new StringBuilder();
						sbCommands.Append("INSERT INTO timecardrule (");
						if(useExistingPK) {
							sbCommands.Append("TimeCardRuleNum,");
						}
						sbCommands.Append("EmployeeNum,OverHoursPerDay,AfterTimeOfDay,BeforeTimeOfDay,IsOvertimeExempt,MinClockInTime) VALUES ");
						countRows=0;
					}
					else {
						hasComma=true;
					}
					if(useExistingPK) {
						sbRow.Append(POut.Long(timeCardRule.TimeCardRuleNum)); sbRow.Append(",");
					}
					sbRow.Append(POut.Long(timeCardRule.EmployeeNum)); sbRow.Append(",");
					sbRow.Append(POut.Time(timeCardRule.OverHoursPerDay)); sbRow.Append(",");
					sbRow.Append(POut.Time(timeCardRule.AfterTimeOfDay)); sbRow.Append(",");
					sbRow.Append(POut.Time(timeCardRule.BeforeTimeOfDay)); sbRow.Append(",");
					sbRow.Append(POut.Bool(timeCardRule.IsOvertimeExempt)); sbRow.Append(",");
					sbRow.Append(POut.Time(timeCardRule.MinClockInTime)); sbRow.Append(")");
					if(sbCommands.Length+sbRow.Length+1 > TableBase.MaxAllowedPacketCount && countRows > 0) {
						Db.NonQ(sbCommands.ToString());
						sbCommands=null;
					}
					else {
						if(hasComma) {
							sbCommands.Append(",");
						}
						sbCommands.Append(sbRow.ToString());
						countRows++;
						if(index==listTimeCardRules.Count-1) {
							Db.NonQ(sbCommands.ToString());
						}
						index++;
					}
				}
			}
		}

		///<summary>Inserts one TimeCardRule into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TimeCardRule timeCardRule) {
			return InsertNoCache(timeCardRule,false);
		}

		///<summary>Inserts one TimeCardRule into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(TimeCardRule timeCardRule,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO timecardrule (";
			if(!useExistingPK && isRandomKeys) {
				timeCardRule.TimeCardRuleNum=ReplicationServers.GetKeyNoCache("timecardrule","TimeCardRuleNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="TimeCardRuleNum,";
			}
			command+="EmployeeNum,OverHoursPerDay,AfterTimeOfDay,BeforeTimeOfDay,IsOvertimeExempt,MinClockInTime) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(timeCardRule.TimeCardRuleNum)+",";
			}
			command+=
				     POut.Long  (timeCardRule.EmployeeNum)+","
				+    POut.Time  (timeCardRule.OverHoursPerDay)+","
				+    POut.Time  (timeCardRule.AfterTimeOfDay)+","
				+    POut.Time  (timeCardRule.BeforeTimeOfDay)+","
				+    POut.Bool  (timeCardRule.IsOvertimeExempt)+","
				+    POut.Time  (timeCardRule.MinClockInTime)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				timeCardRule.TimeCardRuleNum=Db.NonQ(command,true,"TimeCardRuleNum","timeCardRule");
			}
			return timeCardRule.TimeCardRuleNum;
		}

		///<summary>Updates one TimeCardRule in the database.</summary>
		public static void Update(TimeCardRule timeCardRule) {
			string command="UPDATE timecardrule SET "
				+"EmployeeNum     =  "+POut.Long  (timeCardRule.EmployeeNum)+", "
				+"OverHoursPerDay =  "+POut.Time  (timeCardRule.OverHoursPerDay)+", "
				+"AfterTimeOfDay  =  "+POut.Time  (timeCardRule.AfterTimeOfDay)+", "
				+"BeforeTimeOfDay =  "+POut.Time  (timeCardRule.BeforeTimeOfDay)+", "
				+"IsOvertimeExempt=  "+POut.Bool  (timeCardRule.IsOvertimeExempt)+", "
				+"MinClockInTime  =  "+POut.Time  (timeCardRule.MinClockInTime)+" "
				+"WHERE TimeCardRuleNum = "+POut.Long(timeCardRule.TimeCardRuleNum);
			Db.NonQ(command);
		}

		///<summary>Updates one TimeCardRule in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(TimeCardRule timeCardRule,TimeCardRule oldTimeCardRule) {
			string command="";
			if(timeCardRule.EmployeeNum != oldTimeCardRule.EmployeeNum) {
				if(command!="") { command+=",";}
				command+="EmployeeNum = "+POut.Long(timeCardRule.EmployeeNum)+"";
			}
			if(timeCardRule.OverHoursPerDay != oldTimeCardRule.OverHoursPerDay) {
				if(command!="") { command+=",";}
				command+="OverHoursPerDay = "+POut.Time  (timeCardRule.OverHoursPerDay)+"";
			}
			if(timeCardRule.AfterTimeOfDay != oldTimeCardRule.AfterTimeOfDay) {
				if(command!="") { command+=",";}
				command+="AfterTimeOfDay = "+POut.Time  (timeCardRule.AfterTimeOfDay)+"";
			}
			if(timeCardRule.BeforeTimeOfDay != oldTimeCardRule.BeforeTimeOfDay) {
				if(command!="") { command+=",";}
				command+="BeforeTimeOfDay = "+POut.Time  (timeCardRule.BeforeTimeOfDay)+"";
			}
			if(timeCardRule.IsOvertimeExempt != oldTimeCardRule.IsOvertimeExempt) {
				if(command!="") { command+=",";}
				command+="IsOvertimeExempt = "+POut.Bool(timeCardRule.IsOvertimeExempt)+"";
			}
			if(timeCardRule.MinClockInTime != oldTimeCardRule.MinClockInTime) {
				if(command!="") { command+=",";}
				command+="MinClockInTime = "+POut.Time  (timeCardRule.MinClockInTime)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE timecardrule SET "+command
				+" WHERE TimeCardRuleNum = "+POut.Long(timeCardRule.TimeCardRuleNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(TimeCardRule,TimeCardRule) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(TimeCardRule timeCardRule,TimeCardRule oldTimeCardRule) {
			if(timeCardRule.EmployeeNum != oldTimeCardRule.EmployeeNum) {
				return true;
			}
			if(timeCardRule.OverHoursPerDay != oldTimeCardRule.OverHoursPerDay) {
				return true;
			}
			if(timeCardRule.AfterTimeOfDay != oldTimeCardRule.AfterTimeOfDay) {
				return true;
			}
			if(timeCardRule.BeforeTimeOfDay != oldTimeCardRule.BeforeTimeOfDay) {
				return true;
			}
			if(timeCardRule.IsOvertimeExempt != oldTimeCardRule.IsOvertimeExempt) {
				return true;
			}
			if(timeCardRule.MinClockInTime != oldTimeCardRule.MinClockInTime) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one TimeCardRule from the database.</summary>
		public static void Delete(long timeCardRuleNum) {
			string command="DELETE FROM timecardrule "
				+"WHERE TimeCardRuleNum = "+POut.Long(timeCardRuleNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many TimeCardRules from the database.</summary>
		public static void DeleteMany(List<long> listTimeCardRuleNums) {
			if(listTimeCardRuleNums==null || listTimeCardRuleNums.Count==0) {
				return;
			}
			string command="DELETE FROM timecardrule "
				+"WHERE TimeCardRuleNum IN("+string.Join(",",listTimeCardRuleNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}