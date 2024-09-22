namespace nexgen.Domain.Consts
{
    public static class ApiErrorCodes
    {
        public static KeyValuePair<string, string> BookTitleRequired { get => new KeyValuePair<string, string>("001", "BookTitle field is required."); }
        public static KeyValuePair<string, string> BookTitleLengthNotCorrect { get => new KeyValuePair<string, string>("002", "BookTitle field length not correct."); }


        public static KeyValuePair<string, string> UsernameRequired { get => new KeyValuePair<string, string>("003", "Username field is required."); }
        public static KeyValuePair<string, string> PasswordRequired { get => new KeyValuePair<string, string>("004", "Password field is required."); }
        public static KeyValuePair<string, string> UsernameMinLength { get => new KeyValuePair<string, string>("005", "Username minimum length is 8 characters."); }
        public static KeyValuePair<string, string> PasswordMinLength { get => new KeyValuePair<string, string>("006", "Password minimum length is 8 characters."); }

        public static KeyValuePair<string, string> PasswordMaxLength { get => new KeyValuePair<string, string>("007", "Password maximum length is 50 characters."); }
        public static KeyValuePair<string, string> UsernameMaxLength { get => new KeyValuePair<string, string>("008", "Username maximum length is 50 characters."); }


    }
}
