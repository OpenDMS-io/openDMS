using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenDentBusiness;

namespace OpenDental{
///<summary></summary>
	public partial class FormDefEditImages:FormODBase {
		///<summary></summary>
		public bool IsNew;
		private Def DefCur;
		
		///<summary></summary>
		public FormDefEditImages(Def defCur) {
			InitializeComponent();// Required for Windows Form Designer support
			InitializeLayoutManager();
			Lan.F(this);
			DefCur=defCur.Copy();
		}

		private void FormDefEdit_Load(object sender,System.EventArgs e) {
			//Also see Defs.GetImageCat and ImageCategorySpecial when reworking this form.
			textName.Text=DefCur.ItemName;
			//textValue.Text=DefCur.ItemValue;
			if(DefCur.ItemValue.Contains("X")) {
				checkChartModule.Checked=true;
			}
			if(DefCur.ItemValue.Contains("F")) {
				checkPatientForms.Checked=true;
			}
			if(DefCur.ItemValue.Contains("L")) {
				checkPatientPortal.Checked=true;
			}
			if(DefCur.ItemValue.Contains("P")) {
				checkPatientPictures.Checked=true;
			}
			if(DefCur.ItemValue.Contains("S")) {
				checkStatements.Checked=true;
			}
			if(DefCur.ItemValue.Contains("T")) {
				checkToothCharts.Checked=true;
			}
			if(DefCur.ItemValue.Contains("R")) {
				checkTreatmentPlans.Checked=true;
			}
			if(DefCur.ItemValue.Contains("A")) {
				checkPaymentPlans.Checked=true;
			}
			if(DefCur.ItemValue.Contains("C")) {
				checkClaimAttachments.Checked=true;
			}
			if(DefCur.ItemValue.Contains("B")) {
				checkLabCases.Checked=true;
			}
			if(DefCur.ItemValue.Contains("U")) {
				checkAutoSaveForm.Checked=true;
			}
			checkHidden.Checked=DefCur.IsHidden;
		}

		private void checkPatientPictures_CheckedChanged(object sender,EventArgs e) {
			if(checkPatientPictures.Checked) {
				checkStatements.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkToothCharts.Checked=false;
				checkPaymentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkLabCases.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkStatements_CheckedChanged(object sender,EventArgs e) {
			if(checkStatements.Checked) {
				checkPatientPictures.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkToothCharts.Checked=false;
				checkPaymentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkLabCases.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkToothCharts_CheckedChanged(object sender,EventArgs e) {
			if(checkToothCharts.Checked) {
				checkStatements.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkPatientPictures.Checked=false;
				checkPaymentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkLabCases.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkTreatmentPlans_CheckedChanged(object sender,EventArgs e) {
			if(checkTreatmentPlans.Checked) {
				checkStatements.Checked=false;
				checkPatientPictures.Checked=false;
				checkToothCharts.Checked=false;
				checkPaymentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkLabCases.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkPaymentPlans_CheckedChanged(object sender,EventArgs e) {
			if(checkPaymentPlans.Checked) {
				checkStatements.Checked=false;
				checkPatientPictures.Checked=false;
				checkToothCharts.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkLabCases.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkClaimAttachments_CheckedChanged(object sender,EventArgs e) {
			if(checkClaimAttachments.Checked) {
				checkStatements.Checked=false;
				checkPatientPictures.Checked=false;
				checkToothCharts.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkPaymentPlans.Checked=false;
				checkLabCases.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkLabCases_CheckedChanged(object sender,EventArgs e) {
			if(checkLabCases.Checked) {
				checkStatements.Checked=false;
				checkPatientPictures.Checked=false;
				checkToothCharts.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkPaymentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkAutoSaveForm.Checked=false;
			}
		}

		private void checkAutoSaveForm_CheckedChanged(object sender,EventArgs e) {
			if(checkAutoSaveForm.Checked) {
				checkPatientPictures.Checked=false;
				checkStatements.Checked=false;
				checkTreatmentPlans.Checked=false;
				checkToothCharts.Checked=false;
				checkPaymentPlans.Checked=false;
				checkClaimAttachments.Checked=false;
				checkLabCases.Checked=false;
			}
		}

		private void butOK_Click(object sender, System.EventArgs e) {
			if(checkHidden.Checked) {
				if(Defs.IsDefinitionInUse(DefCur)) {
					if(!MsgBox.Show(this,MsgBoxButtons.OKCancel,"Warning: This definition is currently in use within the program.")) {
						return;
					}
				}
			}
			if(textName.Text==""){
				MsgBox.Show(this,"Name required.");
				return;
			}
			DefCur.ItemName=textName.Text;
			string itemVal="";
			if(checkChartModule.Checked) {
				itemVal+="X";
			}
			if(checkPatientForms.Checked) {
				itemVal+="F";
			}
			if(checkPatientPortal.Checked) {
				itemVal+="L";
			}
			if(checkPatientPictures.Checked) {
				itemVal+="P";
			}
			if(checkStatements.Checked) {
				itemVal+="S";
			}
			if(checkToothCharts.Checked) {
				itemVal+="T";
			}
			if(checkTreatmentPlans.Checked) {
				itemVal+="R";
			}
			if(checkPaymentPlans.Checked) {
				itemVal+="A";
			}
			if(checkClaimAttachments.Checked) {
				itemVal+="C";
			}
			if(checkLabCases.Checked) {
				itemVal+="B";
			}
			if(checkAutoSaveForm.Checked) {
				itemVal+="U";
			}
			DefCur.ItemValue=itemVal;
			DefCur.IsHidden=checkHidden.Checked;
			if(IsNew){
				Defs.Insert(DefCur);
			}
			else{
				Defs.Update(DefCur);
			}
			DialogResult=DialogResult.OK;
		}

		private void butCancel_Click(object sender,System.EventArgs e) {
			DialogResult=DialogResult.Cancel;
		}
	}
}
