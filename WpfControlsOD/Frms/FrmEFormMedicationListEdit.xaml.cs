using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using OpenDentBusiness;
using WpfControls;
using WpfControls.UI;

namespace OpenDental {
	/// <summary>The editor is for the EFormField even though we're really editing the EFormFieldDef. This editor is not patient facing.</summary>
	public partial class FrmEFormMedicationListEdit : FrmODBase {
		///<summary>This is the object being edited.</summary>
		public EFormField EFormFieldCur;
		///<summary>We need access to a few other fields of the EFormDef.</summary>
		public EFormDef EFormDefCur;
		///<summary>All the siblings</summary>
		public List<EFormField> _listEFormFields;
		private EFormMedListLayout _eFormMedListLayout;

		///<summary></summary>
		public FrmEFormMedicationListEdit() {
			InitializeComponent();
			Load+=FrmEFormsMedicationListEdit_Load;
			groupAdvanced.Visible=false;
			checkAdvanced.Click+=CheckAdvanced_Click;
			checkIsCol2Visible.Click+=CheckIsCol2Visible_Click;
			checkSyncCol2Overwrite.Click+=CheckSyncCol2Overwrite_Click;
			checkSyncCol2OverwriteDate.Click+=CheckSyncCol2OverwriteDate_Click;
			checkSyncCol2Append.Click+=CheckSyncCol2Append_Click;
			checkSyncCol2AppendDate.Click+=CheckSyncCol2AppendDate_Click;
		}

		private void FrmEFormsMedicationListEdit_Load(object sender, EventArgs e) {
			Lang.F(this);
			_eFormMedListLayout=JsonConvert.DeserializeObject<EFormMedListLayout>(EFormFieldCur.ValueLabel);
			textTitle.Text=_eFormMedListLayout.Title;
			textHeaderCol1.Text=_eFormMedListLayout.HeaderCol1;
			textHeaderCol2.Text=_eFormMedListLayout.HeaderCol2;
			textVIntWidthCol1.Value=_eFormMedListLayout.WidthCol1;
			textVIntWidthCol2.Value=_eFormMedListLayout.WidthCol2;
			checkIsCol2Visible.Checked=_eFormMedListLayout.IsCol2Visible;
			checkPrefillCol1.Checked=_eFormMedListLayout.PrefillCol1;
			checkPrefillCol2.Checked=_eFormMedListLayout.PrefillCol2;
			checkSyncCol1.Checked=_eFormMedListLayout.ImportCol1;
			checkSyncCol2Overwrite.Checked=_eFormMedListLayout.ImportCol2Overwrite;
			checkSyncCol2OverwriteDate.Checked=_eFormMedListLayout.ImportCol2OverwriteDate;
			checkSyncCol2Append.Checked=_eFormMedListLayout.ImportCol2Append;
			checkSyncCol2AppendDate.Checked=_eFormMedListLayout.ImportCol2AppendDate;
			checkIsRequired.Checked=EFormFieldCur.IsRequired;
			checkBorder.Checked=EFormFieldCur.Border==EnumEFormBorder.ThreeD;
			textVIntFontScale.Value=EFormFieldCur.FontScale;
			int spaceBelowDefault=PrefC.GetInt(PrefName.EformsSpaceBelowEachField);
			labelSpaceDefault.Text=Lang.g(this,"leave blank to use the default value of ")+spaceBelowDefault.ToString();
			if(EFormFieldCur.SpaceBelow==-1){
				textSpaceBelow.Text="";
			}
			else{
				textSpaceBelow.Text=EFormFieldCur.SpaceBelow.ToString();
			}
			textCondParent.Text=EFormFieldCur.ConditionalParent;
			textCondValue.Text=EFormL.ConvertCondDbToVis(_listEFormFields,EFormFieldCur.ConditionalParent,EFormFieldCur.ConditionalValue);
		}

		private void CheckAdvanced_Click(object sender,EventArgs e) {
			if(checkAdvanced.Checked==true){
				groupAdvanced.Visible=true;
			}
			else{
				groupAdvanced.Visible=false;
			}
		}

		private void CheckIsCol2Visible_Click(object sender,EventArgs e) {
			if(checkIsCol2Visible.Checked==true) {
				checkPrefillCol2.Visible=true;
				checkPrefillCol2.Checked=true;
				labelPreFilCol2.Visible=true;
			}
			else {
				checkPrefillCol2.Visible=false;
				checkPrefillCol2.Checked=false;
				labelPreFilCol2.Visible=false;
			}
		}

		private void CheckSyncCol2AppendDate_Click(object sender,EventArgs e) {
			if(checkSyncCol2AppendDate.Checked==true) {
				checkSyncCol2Append.Checked=false;
				checkSyncCol2Overwrite.Checked=false;
				checkSyncCol2OverwriteDate.Checked=false;
			}
		}

		private void CheckSyncCol2Append_Click(object sender,EventArgs e) {
			if(checkSyncCol2Append.Checked==true) {
				checkSyncCol2AppendDate.Checked=false;
				checkSyncCol2Overwrite.Checked=false;
				checkSyncCol2OverwriteDate.Checked=false;
			}
		}

		private void CheckSyncCol2OverwriteDate_Click(object sender,EventArgs e) {
			if(checkSyncCol2OverwriteDate.Checked==true) {
				checkSyncCol2Append.Checked=false;
				checkSyncCol2AppendDate.Checked=false;
				checkSyncCol2Overwrite.Checked=false;
			}
		}

		private void CheckSyncCol2Overwrite_Click(object sender,EventArgs e) {
			if(checkSyncCol2Overwrite.Checked==true) {
				checkSyncCol2Append.Checked=false;
				checkSyncCol2AppendDate.Checked=false;
				checkSyncCol2OverwriteDate.Checked=false;
			}
		}

		private void butDelete_Click(object sender,EventArgs e) {
			//no need to verify with user because they have another chance to cancel in the parent window.
			EFormFieldCur=null;
			IsDialogOK=true;
		}
		private void butPickParent_Click(object sender,EventArgs e) {
			FrmEFormFieldPicker frmEFormFieldPicker=new FrmEFormFieldPicker();
			frmEFormFieldPicker.ListEFormFields=_listEFormFields;
			int idx=_listEFormFields.IndexOf(EFormFieldCur);
			frmEFormFieldPicker.ListSelectedIndices.Add(idx);//Prevents self selection as parent
			frmEFormFieldPicker.ShowDialog();
			if(frmEFormFieldPicker.IsDialogCancel){
				return;
			}
			textCondParent.Text=frmEFormFieldPicker.ParentSelected;
		}

		private void butPickValue_Click(object sender,EventArgs e) {
			textCondValue.Text=EFormL.PickCondValue(_listEFormFields,textCondParent.Text,textCondValue.Text);
		}

		private void butSave_Click(object sender, EventArgs e) {
			if(!textVIntWidthCol1.IsValid()
				|| !textVIntWidthCol2.IsValid()
				|| !textVIntFontScale.IsValid()) 
			{
				MsgBox.Show("Please fix entry errors first.");
				return;
			}
			int spaceBelow=-1;
			if(textSpaceBelow.Text!=""){
				try{
					spaceBelow=Convert.ToInt32(textSpaceBelow.Text);
				}
				catch{
					MsgBox.Show(this,"Please fix error in Space Below first.");
					return;
				}
				if(spaceBelow<0 || spaceBelow>200){
					MsgBox.Show(this,"Space Below value is invalid.");
					return;
				}
			}
			//end of validation
			_eFormMedListLayout.Title=textTitle.Text;
			_eFormMedListLayout.HeaderCol1=textHeaderCol1.Text;
			_eFormMedListLayout.HeaderCol2=textHeaderCol2.Text;
			_eFormMedListLayout.WidthCol1=textVIntWidthCol1.Value;
			_eFormMedListLayout.WidthCol2=textVIntWidthCol2.Value;
			_eFormMedListLayout.IsCol2Visible=checkIsCol2Visible.Checked==true;
			_eFormMedListLayout.PrefillCol1=checkPrefillCol1.Checked==true;
			_eFormMedListLayout.PrefillCol2=checkPrefillCol2.Checked==true;
			_eFormMedListLayout.ImportCol1=checkSyncCol1.Checked==true;
			_eFormMedListLayout.ImportCol2Overwrite=checkSyncCol2Overwrite.Checked==true;
			_eFormMedListLayout.ImportCol2OverwriteDate=checkSyncCol2OverwriteDate.Checked==true;
			_eFormMedListLayout.ImportCol2Append=checkSyncCol2Append.Checked==true;
			_eFormMedListLayout.ImportCol2AppendDate=checkSyncCol2AppendDate.Checked==true;
			EFormFieldCur.ValueLabel=JsonConvert.SerializeObject(_eFormMedListLayout);
			EFormFieldCur.IsRequired=checkIsRequired.Checked==true;
			if(checkBorder.Checked==true){
				EFormFieldCur.Border=EnumEFormBorder.ThreeD;
			}
			else{
				EFormFieldCur.Border=EnumEFormBorder.None;
			}
			EFormFieldCur.FontScale=textVIntFontScale.Value;
			EFormFieldCur.SpaceBelow=spaceBelow;
			EFormFieldCur.ConditionalParent=textCondParent.Text;
			EFormFieldCur.ConditionalValue=EFormL.ConvertCondVisToDb(_listEFormFields,textCondParent.Text,textCondValue.Text);
			//not saved to db here. That happens when clicking Save in parent window.
			IsDialogOK=true;
		}

		
	}
}