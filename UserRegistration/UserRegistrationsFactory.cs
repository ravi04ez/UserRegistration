﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
    public class UserRegistrationsFactory
    {
        public object CreateUserRegistration(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type userRegistrationType = executing.GetType(className);
                    return Activator.CreateInstance(userRegistrationType);
                }
                catch (ArgumentNullException)
                {
                    throw new CustomExecption(CustomExecption.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new CustomExecption(CustomExecption.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }

        public object CreateUserRegistrationUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(ValidationMSTest);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                try
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    object instance = constructorInfo.Invoke(new object[] { message });
                    return instance;
                }
                catch (ArgumentNullException)
                {
                    throw new CustomExecption(CustomExecption.ExceptionType.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new CustomExecption(CustomExecption.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }
    }
}
