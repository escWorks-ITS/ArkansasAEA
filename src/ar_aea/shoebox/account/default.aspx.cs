using System;
using System.Web.UI;

public partial class shoebox_account_default : region4.escWeb.BasePages.ShoeBox.Account.default_aspx
{
    protected override void AssignControlsToBase()
    {
        base._primaryEmail = txtPrimaryEmail;
        base._secondaryEmail = txtSecondaryEmail;
        base._saluation = ddlSalutation;
        base._lastName = txtLastName;
        base._firstName = txtFirstName;
        base._middleName = txtMiddleName;
        base._homeAddress = txtHomeAddress;
        base._city = txtCity;
        base._state = ddState;
        base._zip = txtZip;
        base._homePhone = txtHomePhone;
        base._workPhone = txtWorkPhone;
        base._region = ddlRegion;
        base._district = ddlDistrict;
        base._school = ddlSchool;
        base._position = ddlPosition;
        base._errorMessage = lbErrorMessage;

        base._btnSubmit = btnSubmit;

        base._pSuccess = pSuccess;
        base._pFirst = pFirst;

        //base._gradeLevel = ddlGradeLevel;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CascadingDropDown1.SelectedValue = CurrentUser.Location.Site.Organization.LocationID.ToString();
            CascadingDropDown2.SelectedValue = CurrentUser.Location.Site.LocationID.ToString();
            CascadingDropDown3.SelectedValue = CurrentUser.Location.LocationID.ToString();

            if (CurrentUser.Sid != Guid.Empty)
            {
                txtSSN.Text = ((escWeb.ar_aea.ObjectModel.User)CurrentUser).SSN;
                cbAEA.Checked = ((escWeb.ar_aea.ObjectModel.User)CurrentUser).AEAMember;
                
            }
        }
    }


    protected override void SetCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.ar_aea.ObjectModel.User u = user as escWeb.ar_aea.ObjectModel.User;

        u.SSN = txtSSN.Text == null ? null : txtSSN.Text;
        u.AEAMember = cbAEA.Checked ? true : false;

    }

    protected void OnChangePassword(object sender, EventArgs e)
    {
        string Email = this.txtPrimaryEmail.Text;

        string url = "password.aspx?mode=change&code=0" + "&email=" + Email;
        Response.Redirect(url);
    }

    protected override void _btnSubmit_Click(object sender, EventArgs e)
    {
        #region Validation
        string validationMessage;
        if (!ValidateData(out validationMessage))
        {
            //Display error message
            _errorMessage.Text = validationMessage;
            return;
        }

        if (!ValidateCustomerData(out validationMessage))
        {
            _errorMessage.Text = validationMessage;
            return;
        }

        bool err = false;

        int location_id, site_id, organization_id, position_id = 0, salutation_id = 0;
        //location_id = 1002;

        if (!Int32.TryParse(_school.SelectedValue, out location_id))
        {
            validationMessage += "<div class='error'>* Please select a "
                + region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized + "</div>";
            err = true;
        }


        if (!Int32.TryParse(_district.SelectedValue, out site_id))
        {
            //TODO: parameritze this
            validationMessage += "<div class='error'>* Please select a "
            + region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized + "</div>";
            err = true;
        }

        if (_region != null && !Int32.TryParse(_region.SelectedValue, out organization_id))
        {
            validationMessage += "<div class='error'>* Please select a " + region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized + "</div>";
            err = true;
        }

        if (_position != null && !Int32.TryParse(_position.SelectedValue, out position_id))
        {
            validationMessage += "<div class='error'>* Please select a position</div>";
            err = true;
        }

        if (err)
        {
            _errorMessage.Text = validationMessage;
            return;
        }
        #endregion

        #region Save Profile
        CurrentUser.SecondaryEmail = _secondaryEmail.Text;
        CurrentUser.LastName = _lastName.Text;
        CurrentUser.FirstName = _firstName.Text;
        CurrentUser.MiddleName = _middleName.Text;
        CurrentUser.Address = _homeAddress.Text;
        CurrentUser.City = _city.Text;
        CurrentUser.State = UserState;
        CurrentUser.Zip = _zip.Text;
        CurrentUser.HomePhone = _homePhone.Text;
        CurrentUser.WorkPhone = _workPhone.Text;

        CurrentUser.LocationID = location_id;
        CurrentUser.Locationsite = site_id;
        CurrentUser.PrimaryPosition = region4.Item.ReturnItem(position_id);
        CurrentUser.Salutation = region4.Item.ReturnItem(salutation_id);
        CurrentUser.GradeLevel = region4.Item.ReturnItem(0);

        SetCustomerParameters(CurrentUser);

        if (CurrentUser.Save())
        {
            Session.Remove("profile");
            Session["profile"] = CurrentUser;
            this.ShoppingCart.ChangeUser(CurrentUser);
            _pFirst.Visible = false;
            _pSuccess.Visible = true;
        }
        else
        {
            _errorMessage.Text = string.Format("<div class='error'>Oops. An error has occurred! {0}</div>", CurrentUser.LoadException.Message);
        }
        #endregion

       // RedirectToCheckOut();
    }

}
