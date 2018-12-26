using Canducci.ZipCodePostmon;
using System;
public partial class FinderZip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnFind_Click(object sender, EventArgs e)
    {
        try
        {
            PanelStatus.Visible = false;
            LblMessage.Text = "";
            if (!string.IsNullOrEmpty(TxtZipCode.Text) && TxtZipCode.Text.Length > 7)
            {
                ZipCodeNumber number;
                if (ZipCodeNumber.TryParse(TxtZipCode.Text, out number))
                {
                    ZipCodeResult result = ZipCodeResult.Create();
                    ZipCode zipCode = result.Find(number);
                    LtlAddress.Text = zipCode.Address ?? "";
                    LtlCity.Text = zipCode.City ?? "";
                    LtlCityAreaKm2.Text = zipCode.CityInfo.AreaKm2 ?? "";
                    LtlCityCodeIbge.Text = zipCode.CityInfo.CodeIbge.ToString();
                    LtlCodePostal.Text = zipCode.CodePostal ?? "";
                    LtlComplement.Text = zipCode.Complement ?? "";
                    LtlDistrict.Text = zipCode.District ?? "";
                    LtlUF.Text = zipCode.UF ?? "";
                    LtlUFName.Text = zipCode.UFInfo.Name ?? "";
                    LtlUFAreadKm2.Text = zipCode.UFInfo.AreaKm2 ?? "";
                    LtlUFCodeIbge.Text = zipCode.UFInfo.CodeIbge.ToString();
                    PanelStatus.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            LblMessage.Text = "Cep Inválido";
            //throw ex;
        }
        
    }
}