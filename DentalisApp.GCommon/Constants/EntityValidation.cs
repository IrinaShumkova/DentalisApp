namespace DentalisApp.Common.Constants
{
    public static class EntityValidation
    {
        /*Patient start*/

        public const int PatientEGNLength = 10;
        public const int PatientFirstNameMinLength =1;
        public const int PatientFirstNameMaxLength =50;
        public const int PatientSecondNameMaxLength = 30;
        public const int PatientLastNameMinLength = 1;
        public const int PatientLastNameMaxLength = 64;
        public const int PatientAddressMaxLength = 200;
        public const int PatientPhoneMaxLength = 50;
        public const int PatientEmailMaxLength = 254;
        public const int PatientAllergiesMaxLength = 300;
        public const int PatientMedicalHistoryMaxLength = 500;
        public const int PatientNotesMaxLength = 500;

        /*Patient end*/

        /*Appointment start*/
        public const string AppointmentDateTimeSQlType = "smalldatetime";
        public const int AppointmentNotesMaxLength = 500;
        public const int AppointmentDiagnosisMaxLength = 300;

        /*Appointment end*/

        /*Invoice start*/
        public const int InvoiceNumberMinLength = 3;
        public const int InvoiceNumberMaxLength = 15;

        /*Invoice end*/

        /*InvoiceItem start*/
        public const int InvoiceItemDescriptionMaxLength = 200;

        public const string InvoiceItemPriceType = "decimal(18,2)";
      

        /*InvoiceItem end*/
    }
}
