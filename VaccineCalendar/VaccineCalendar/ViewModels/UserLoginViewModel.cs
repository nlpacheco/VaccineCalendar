//using MobileSharedCode.Validations;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace VaccineCalendar.ViewModels
//{
//    public class UserLoginViewModel: BaseViewModel
//    {
//        ValidatableObject<string> _emailUsuario;
//        ValidatableObject<string> _password;

//        public ValidatableObject<string> EmailUsuario
//        {
//            get
//            {
//                return _emailUsuario;
//            }
//            set
//            {   
//                _emailUsuario = value;
//                RaisePropertyChanged(() => EmailUsuario);
//            }
//        }

//        public ValidatableObject<string> Password
//        {
//            get
//            {
//                return _password;
//            }
//            set
//            {
//                _password = value;
//                RaisePropertyChanged(() => Password);
//            }
//        }

//        public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
//        {
//            public string ValidationMessage { get; set; }

//            public bool Check(T value)
//            {
//                if (value == null)
//                {
//                    return false;
//                }

//                var str = value as string;
//                return !string.IsNullOrWhiteSpace(str);
//            }
//        }

//        public class EmailRule<T> : IValidationRule<T>
//        {
//            public string ValidationMessage { get; set; }

//            public bool Check(T value)
//            {
//                if (value == null)
//                {
//                    return false;
//                }

//                var str = value as string;
//                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
//                Match match = regex.Match(str);

//                return match.Success;
//            }
//        }
//    }
//}
