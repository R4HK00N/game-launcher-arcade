namespace QRCodeGenerator23
{
    public class EmailAddressInputFieldValidations : InputFieldValidations
    {
        // Regex pattern for validating email addresses
        private string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public override void ValidateInputFields()
        {
            RegularExpressions.Add(emailPattern);
            ValidateFields();
        }
    }
}

