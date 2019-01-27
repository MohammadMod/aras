using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aras
{
    // a genetic class for validation
    public class Validation
    {
        protected string type;
        public string errorMessage { get; private set; }
        public string data { get; protected set; }


        public Validation()
        {
            type = "data";
            errorMessage = "";
            data = "";
        }


        protected virtual bool isEmpty()
        {
            if (data.Length <= 0)
            {
                errorMessage = $"entered {type} is empty";
                return true;
            }
            return false;
        }

        /// <summary>
        /// this method runs on N*N, need to be optimized
        /// </summary>
        /// <param name="valids"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        protected virtual bool invalidChars(List<char> valids)
        {

            foreach (char item in data)
            {
                bool found = false;
                for (int i = 0; i < valids.Count && !found; i++)
                {
                    if (item == valids[i])
                        found = true;
                }

                if (found == false)
                {
                    errorMessage = $"using '{item}' is not allowed in {type}"; ;
                    return true;
                }
            }

            return false;
        }

        protected virtual bool isTooLong(int max)
        {
            if (data.Length > max)
            {
                errorMessage = $"entered {type} is too long, please no more {max} letters" ;
                return true;
            }
            return false;
        }

        protected virtual bool isTooShort(int min)
        {
            if (data.Length < min)
            {
                errorMessage = $"entered {type} is too short, please at least {min} letters";
                return true;
            }
            return false;
        }
    }
}