//This file is automatically generated.
//Do not attempt to make changes to this file because the changes will be erased and overwritten.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace OpenDentBusiness.Crud{
	public class InsFilingCodeCrud {
		///<summary>Gets one InsFilingCode object from the database using the primary key.  Returns null if not found.</summary>
		public static InsFilingCode SelectOne(long insFilingCodeNum) {
			string command="SELECT * FROM insfilingcode "
				+"WHERE InsFilingCodeNum = "+POut.Long(insFilingCodeNum);
			List<InsFilingCode> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets one InsFilingCode object from the database using a query.</summary>
		public static InsFilingCode SelectOne(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsFilingCode> list=TableToList(Db.GetTable(command));
			if(list.Count==0) {
				return null;
			}
			return list[0];
		}

		///<summary>Gets a list of InsFilingCode objects from the database using a query.</summary>
		public static List<InsFilingCode> SelectMany(string command) {
			if(RemotingClient.RemotingRole==RemotingRole.ClientWeb) {
				throw new ApplicationException("Not allowed to send sql directly.  Rewrite the calling class to not use this query:\r\n"+command);
			}
			List<InsFilingCode> list=TableToList(Db.GetTable(command));
			return list;
		}

		///<summary>Converts a DataTable to a list of objects.</summary>
		public static List<InsFilingCode> TableToList(DataTable table) {
			List<InsFilingCode> retVal=new List<InsFilingCode>();
			InsFilingCode insFilingCode;
			foreach(DataRow row in table.Rows) {
				insFilingCode=new InsFilingCode();
				insFilingCode.InsFilingCodeNum= PIn.Long  (row["InsFilingCodeNum"].ToString());
				insFilingCode.Descript        = PIn.String(row["Descript"].ToString());
				insFilingCode.EclaimCode      = PIn.String(row["EclaimCode"].ToString());
				insFilingCode.ItemOrder       = PIn.Int   (row["ItemOrder"].ToString());
				insFilingCode.GroupType       = PIn.Long  (row["GroupType"].ToString());
				retVal.Add(insFilingCode);
			}
			return retVal;
		}

		///<summary>Converts a list of InsFilingCode into a DataTable.</summary>
		public static DataTable ListToTable(List<InsFilingCode> listInsFilingCodes,string tableName="") {
			if(string.IsNullOrEmpty(tableName)) {
				tableName="InsFilingCode";
			}
			DataTable table=new DataTable(tableName);
			table.Columns.Add("InsFilingCodeNum");
			table.Columns.Add("Descript");
			table.Columns.Add("EclaimCode");
			table.Columns.Add("ItemOrder");
			table.Columns.Add("GroupType");
			foreach(InsFilingCode insFilingCode in listInsFilingCodes) {
				table.Rows.Add(new object[] {
					POut.Long  (insFilingCode.InsFilingCodeNum),
					            insFilingCode.Descript,
					            insFilingCode.EclaimCode,
					POut.Int   (insFilingCode.ItemOrder),
					POut.Long  (insFilingCode.GroupType),
				});
			}
			return table;
		}

		///<summary>Inserts one InsFilingCode into the database.  Returns the new priKey.</summary>
		public static long Insert(InsFilingCode insFilingCode) {
			return Insert(insFilingCode,false);
		}

		///<summary>Inserts one InsFilingCode into the database.  Provides option to use the existing priKey.</summary>
		public static long Insert(InsFilingCode insFilingCode,bool useExistingPK) {
			if(!useExistingPK && PrefC.RandomKeys) {
				insFilingCode.InsFilingCodeNum=ReplicationServers.GetKey("insfilingcode","InsFilingCodeNum");
			}
			string command="INSERT INTO insfilingcode (";
			if(useExistingPK || PrefC.RandomKeys) {
				command+="InsFilingCodeNum,";
			}
			command+="Descript,EclaimCode,ItemOrder,GroupType) VALUES(";
			if(useExistingPK || PrefC.RandomKeys) {
				command+=POut.Long(insFilingCode.InsFilingCodeNum)+",";
			}
			command+=
				 "'"+POut.String(insFilingCode.Descript)+"',"
				+"'"+POut.String(insFilingCode.EclaimCode)+"',"
				+    POut.Int   (insFilingCode.ItemOrder)+","
				+    POut.Long  (insFilingCode.GroupType)+")";
			if(useExistingPK || PrefC.RandomKeys) {
				Db.NonQ(command);
			}
			else {
				insFilingCode.InsFilingCodeNum=Db.NonQ(command,true,"InsFilingCodeNum","insFilingCode");
			}
			return insFilingCode.InsFilingCodeNum;
		}

		///<summary>Inserts one InsFilingCode into the database.  Returns the new priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsFilingCode insFilingCode) {
			return InsertNoCache(insFilingCode,false);
		}

		///<summary>Inserts one InsFilingCode into the database.  Provides option to use the existing priKey.  Doesn't use the cache.</summary>
		public static long InsertNoCache(InsFilingCode insFilingCode,bool useExistingPK) {
			bool isRandomKeys=Prefs.GetBoolNoCache(PrefName.RandomPrimaryKeys);
			string command="INSERT INTO insfilingcode (";
			if(!useExistingPK && isRandomKeys) {
				insFilingCode.InsFilingCodeNum=ReplicationServers.GetKeyNoCache("insfilingcode","InsFilingCodeNum");
			}
			if(isRandomKeys || useExistingPK) {
				command+="InsFilingCodeNum,";
			}
			command+="Descript,EclaimCode,ItemOrder,GroupType) VALUES(";
			if(isRandomKeys || useExistingPK) {
				command+=POut.Long(insFilingCode.InsFilingCodeNum)+",";
			}
			command+=
				 "'"+POut.String(insFilingCode.Descript)+"',"
				+"'"+POut.String(insFilingCode.EclaimCode)+"',"
				+    POut.Int   (insFilingCode.ItemOrder)+","
				+    POut.Long  (insFilingCode.GroupType)+")";
			if(useExistingPK || isRandomKeys) {
				Db.NonQ(command);
			}
			else {
				insFilingCode.InsFilingCodeNum=Db.NonQ(command,true,"InsFilingCodeNum","insFilingCode");
			}
			return insFilingCode.InsFilingCodeNum;
		}

		///<summary>Updates one InsFilingCode in the database.</summary>
		public static void Update(InsFilingCode insFilingCode) {
			string command="UPDATE insfilingcode SET "
				+"Descript        = '"+POut.String(insFilingCode.Descript)+"', "
				+"EclaimCode      = '"+POut.String(insFilingCode.EclaimCode)+"', "
				+"ItemOrder       =  "+POut.Int   (insFilingCode.ItemOrder)+", "
				+"GroupType       =  "+POut.Long  (insFilingCode.GroupType)+" "
				+"WHERE InsFilingCodeNum = "+POut.Long(insFilingCode.InsFilingCodeNum);
			Db.NonQ(command);
		}

		///<summary>Updates one InsFilingCode in the database.  Uses an old object to compare to, and only alters changed fields.  This prevents collisions and concurrency problems in heavily used tables.  Returns true if an update occurred.</summary>
		public static bool Update(InsFilingCode insFilingCode,InsFilingCode oldInsFilingCode) {
			string command="";
			if(insFilingCode.Descript != oldInsFilingCode.Descript) {
				if(command!="") { command+=",";}
				command+="Descript = '"+POut.String(insFilingCode.Descript)+"'";
			}
			if(insFilingCode.EclaimCode != oldInsFilingCode.EclaimCode) {
				if(command!="") { command+=",";}
				command+="EclaimCode = '"+POut.String(insFilingCode.EclaimCode)+"'";
			}
			if(insFilingCode.ItemOrder != oldInsFilingCode.ItemOrder) {
				if(command!="") { command+=",";}
				command+="ItemOrder = "+POut.Int(insFilingCode.ItemOrder)+"";
			}
			if(insFilingCode.GroupType != oldInsFilingCode.GroupType) {
				if(command!="") { command+=",";}
				command+="GroupType = "+POut.Long(insFilingCode.GroupType)+"";
			}
			if(command=="") {
				return false;
			}
			command="UPDATE insfilingcode SET "+command
				+" WHERE InsFilingCodeNum = "+POut.Long(insFilingCode.InsFilingCodeNum);
			Db.NonQ(command);
			return true;
		}

		///<summary>Returns true if Update(InsFilingCode,InsFilingCode) would make changes to the database.
		///Does not make any changes to the database and can be called before remoting role is checked.</summary>
		public static bool UpdateComparison(InsFilingCode insFilingCode,InsFilingCode oldInsFilingCode) {
			if(insFilingCode.Descript != oldInsFilingCode.Descript) {
				return true;
			}
			if(insFilingCode.EclaimCode != oldInsFilingCode.EclaimCode) {
				return true;
			}
			if(insFilingCode.ItemOrder != oldInsFilingCode.ItemOrder) {
				return true;
			}
			if(insFilingCode.GroupType != oldInsFilingCode.GroupType) {
				return true;
			}
			return false;
		}

		///<summary>Deletes one InsFilingCode from the database.</summary>
		public static void Delete(long insFilingCodeNum) {
			string command="DELETE FROM insfilingcode "
				+"WHERE InsFilingCodeNum = "+POut.Long(insFilingCodeNum);
			Db.NonQ(command);
		}

		///<summary>Deletes many InsFilingCodes from the database.</summary>
		public static void DeleteMany(List<long> listInsFilingCodeNums) {
			if(listInsFilingCodeNums==null || listInsFilingCodeNums.Count==0) {
				return;
			}
			string command="DELETE FROM insfilingcode "
				+"WHERE InsFilingCodeNum IN("+string.Join(",",listInsFilingCodeNums.Select(x => POut.Long(x)))+")";
			Db.NonQ(command);
		}

	}
}