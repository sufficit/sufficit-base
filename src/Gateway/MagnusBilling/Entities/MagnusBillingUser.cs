using System;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.MagnusBilling
{
    /// <summary>
    /// MagnusBilling User entity compatible with pkg_user table
    /// Represents user accounts in MagnusBilling system
    /// </summary>
    public class MagnusBillingUser
    {
        [JsonPropertyOrder(1)]
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyOrder(2)]
        [JsonPropertyName("id_group")]
        public string IdGroup { get; set; } = "1";

        [JsonPropertyOrder(3)]
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyOrder(4)]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyOrder(5)]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; } = string.Empty;

        [JsonPropertyOrder(6)]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyOrder(7)]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyOrder(8)]
        [JsonPropertyName("active")]
        public string Active { get; set; } = "1";

        [JsonPropertyOrder(9)]
        [JsonPropertyName("credit")]
        public string Credit { get; set; } = "0.0000";

        [JsonPropertyOrder(10)]
        [JsonPropertyName("creditlimit")]
        public string CreditLimit { get; set; } = "0.0000";

        [JsonPropertyOrder(11)]
        [JsonPropertyName("id_plan")]
        public string IdPlan { get; set; } = "1";

        [JsonPropertyOrder(12)]
        [JsonPropertyName("language")]
        public string Language { get; set; } = "en";

        [JsonPropertyOrder(13)]
        [JsonPropertyName("redial")]
        public string Redial { get; set; } = "";

        [JsonPropertyOrder(14)]
        [JsonPropertyName("enableexpire")]
        public string EnableExpire { get; set; } = "0";

        [JsonPropertyOrder(15)]
        [JsonPropertyName("expirationdate")]
        public string ExpirationDate { get; set; } = string.Empty;

        [JsonPropertyOrder(16)]
        [JsonPropertyName("expiredays")]
        public string ExpireDays { get; set; } = "0";

        [JsonPropertyOrder(17)]
        [JsonPropertyName("typepaid")]
        public string TypePaid { get; set; } = "0";

        [JsonPropertyOrder(18)]
        [JsonPropertyName("callingcard_pin")]
        public string CallingCardPin { get; set; } = string.Empty;

        [JsonPropertyOrder(19)]
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyOrder(20)]
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonPropertyOrder(21)]
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyOrder(22)]
        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyOrder(23)]
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; } = string.Empty;

        [JsonPropertyOrder(24)]
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;

        [JsonPropertyOrder(25)]
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyOrder(26)]
        [JsonPropertyName("mobile")]
        public string Mobile { get; set; } = string.Empty;

        [JsonPropertyOrder(27)]
        [JsonPropertyName("doc")]
        public string Doc { get; set; } = string.Empty;

        [JsonPropertyOrder(28)]
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; } = string.Empty;

        [JsonPropertyOrder(29)]
        [JsonPropertyName("comercialname")]
        public string ComercialName { get; set; } = string.Empty;

        [JsonPropertyOrder(30)]
        [JsonPropertyName("statecompany")]
        public string StateCompany { get; set; } = string.Empty;

        [JsonPropertyOrder(31)]
        [JsonPropertyName("citycompany")]
        public string CityCompany { get; set; } = string.Empty;

        [JsonPropertyOrder(32)]
        [JsonPropertyName("companyaddress")]
        public string CompanyAddress { get; set; } = string.Empty;

        [JsonPropertyOrder(33)]
        [JsonPropertyName("creationdate")]
        public string CreationDate { get; set; } = string.Empty;

        [JsonPropertyOrder(34)]
        [JsonPropertyName("firstusedate")]
        public string FirstUseDate { get; set; } = string.Empty;

        [JsonPropertyOrder(35)]
        [JsonPropertyName("lastuse")]
        public string LastUse { get; set; } = string.Empty;

        [JsonPropertyOrder(36)]
        [JsonPropertyName("nbused")]
        public string NbUsed { get; set; } = "0";

        [JsonPropertyOrder(37)]
        [JsonPropertyName("max_concurrent")]
        public string MaxConcurrent { get; set; } = "1";

        [JsonPropertyOrder(38)]
        [JsonPropertyName("invoice_day")]
        public string InvoiceDay { get; set; } = "1";

        [JsonPropertyOrder(39)]
        [JsonPropertyName("credit_notification")]
        public string CreditNotification { get; set; } = "0";

        [JsonPropertyOrder(40)]
        [JsonPropertyName("id_timezone")]
        public string IdTimezone { get; set; } = "1";

        [JsonPropertyOrder(41)]
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyOrder(42)]
        [JsonPropertyName("restriction")]
        public string Restriction { get; set; } = "0";

        [JsonPropertyOrder(43)]
        [JsonPropertyName("calllimit")]
        public string CallLimit { get; set; } = "0";

        [JsonPropertyOrder(44)]
        [JsonPropertyName("loginkey")]
        public string LoginKey { get; set; } = string.Empty;

        [JsonPropertyOrder(45)]
        [JsonPropertyName("mac_addr")]
        public string MacAddr { get; set; } = string.Empty;

        [JsonPropertyOrder(46)]
        [JsonPropertyName("simultaccess")]
        public string SimultAccess { get; set; } = "0";

        [JsonPropertyOrder(47)]
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; } = "1";

        [JsonPropertyOrder(48)]
        [JsonPropertyName("lastcall")]
        public string LastCall { get; set; } = string.Empty;

        [JsonPropertyOrder(49)]
        [JsonPropertyName("tag")]
        public string Tag { get; set; } = string.Empty;

        [JsonPropertyOrder(50)]
        [JsonPropertyName("voicemail")]
        public string Voicemail { get; set; } = "0";

        [JsonPropertyOrder(51)]
        [JsonPropertyName("disk_space")]
        public string DiskSpace { get; set; } = "0";
    }
}