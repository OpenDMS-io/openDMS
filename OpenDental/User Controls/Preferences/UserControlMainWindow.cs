﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeBase;
using OpenDentBusiness;

namespace OpenDental {
	public partial class UserControlMainWindow:UserControl {

		#region Fields - Private
		#endregion Fields - Private

		#region Fields - Public
		public bool Changed;
		#endregion Fields - Public

		#region Constructors
		public UserControlMainWindow() {
			InitializeComponent();
			Font=LayoutManagerForms.FontInitial;
		}
		#endregion Constructors

		#region Methods - Event Handlers
	
		#endregion Methods - Event Handlers

		#region Methods - Private
		#endregion Methods - Private

		#region Methods - Public
		public void FillWindowMain() {
			textMainWindowTitle.Text=PrefC.GetString(PrefName.MainWindowTitle);
			comboShowID.Items.Add(Lan.g(this,"None"));
			comboShowID.Items.Add(Lan.g(this,"PatNum"));
			comboShowID.Items.Add(Lan.g(this,"ChartNumber"));
			comboShowID.Items.Add(Lan.g(this,"Birthdate"));
			comboShowID.SelectedIndex=PrefC.GetInt(PrefName.ShowIDinTitleBar);
			checkTitleBarShowSpecialty.Checked=PrefC.GetBool(PrefName.TitleBarShowSpecialty);
			checkTitleBarShowSite.Checked=PrefC.GetBool(PrefName.TitleBarShowSite);
			checkUseClinicAbbr.Checked=PrefC.GetBool(PrefName.TitleBarClinicUseAbbr);
			if(!PrefC.HasClinicsEnabled) {
				checkUseClinicAbbr.Visible=false;
			}
			checkRefresh.Checked=!PrefC.GetBool(PrefName.PatientSelectUsesSearchButton);
			checkPrefFName.Checked=PrefC.GetBool(PrefName.PatientSelectUseFNameForPreferred);
			if(PrefC.HasClinicsEnabled){
				checkPatientSelectFilterRestrictedClinics.Visible=true;
				checkPatientSelectFilterRestrictedClinics.Checked=PrefC.GetBool(PrefName.PatientSelectFilterRestrictedClinics);
			}
			checkShowInactivePatientsDefault.Checked=PrefC.GetBool(PrefName.PatientSelectShowInactive);
			checkAllowRefreshWhileTyping.Checked=PrefC.GetBool(PrefName.EnterpriseAllowRefreshWhileTyping);
			if(PrefC.GetString(PrefName.PopupsDisableTimeSpan)!="") {
				TimeSpan timeSpanPopupsDisable=TimeSpan.Parse(PrefC.GetString(PrefName.PopupsDisableTimeSpan),CultureInfo.InvariantCulture);
				textPopupsDisableDays.Text=timeSpanPopupsDisable.Days.ToString("0");
				textPopupsDisableTimeSpan.Text=timeSpanPopupsDisable.Hours.ToString("00")+":"+timeSpanPopupsDisable.Minutes.ToString("00")+":"+timeSpanPopupsDisable.Seconds.ToString("00");
			}
		}

		public bool SaveMainWindow() {
			TimeSpan timeSpanPopup=TimeSpan.Zero;
			string popupsDisableDays=textPopupsDisableDays.Text;
			string popupsDisableTimeSpan=textPopupsDisableTimeSpan.Text;
			if(String.IsNullOrWhiteSpace(popupsDisableDays)) {
				popupsDisableDays="0";
			}
			if(String.IsNullOrWhiteSpace(popupsDisableTimeSpan)) {
				popupsDisableTimeSpan="00:00:00";
			}
			try {
				timeSpanPopup=TimeSpan.ParseExact(popupsDisableDays+"."+popupsDisableTimeSpan,"%d\\.hh\\:mm\\:ss",CultureInfo.InvariantCulture);
			}
			catch {
				MessageBox.Show(Lan.g(this,"Popups Disable Timespan is invalid."));
				return false;
			}
			Changed |=Prefs.UpdateString(PrefName.MainWindowTitle,textMainWindowTitle.Text);
			Changed |=Prefs.UpdateLong(PrefName.ShowIDinTitleBar,comboShowID.SelectedIndex);
			Changed |=Prefs.UpdateBool(PrefName.TitleBarShowSpecialty,checkTitleBarShowSpecialty.Checked);
			Changed |=Prefs.UpdateBool(PrefName.TitleBarShowSite, checkTitleBarShowSite.Checked);
			Changed |=Prefs.UpdateBool(PrefName.TitleBarClinicUseAbbr,checkUseClinicAbbr.Checked);
			Changed |=Prefs.UpdateBool(PrefName.PatientSelectUsesSearchButton,!checkRefresh.Checked);
			Changed |=Prefs.UpdateBool(PrefName.PatientSelectUseFNameForPreferred,checkPrefFName.Checked);
			Changed |=Prefs.UpdateBool(PrefName.PatientSelectFilterRestrictedClinics,checkPatientSelectFilterRestrictedClinics.Checked);
			Changed |=Prefs.UpdateBool(PrefName.PatientSelectShowInactive,checkShowInactivePatientsDefault.Checked);
			Changed |=Prefs.UpdateBool(PrefName.EnterpriseAllowRefreshWhileTyping,checkAllowRefreshWhileTyping.Checked);
			if(timeSpanPopup==TimeSpan.Zero) {
				Changed|=Prefs.UpdateString(PrefName.PopupsDisableTimeSpan,"");
			}
			else {
				Changed|=Prefs.UpdateString(PrefName.PopupsDisableTimeSpan,timeSpanPopup.ToString("c"));
			}
			return true;
		}
		#endregion Methods - Public
	}
}
