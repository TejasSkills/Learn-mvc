using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Operation_17Apr.App_Start
{
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class SampleAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;

        // This is a positional argument
        public SampleAttribute(string positionalString)
        {
            this.positionalString = positionalString;

            // TODO: Implement code here

            throw new NotImplementedException();
        }

        public string PositionalString
        {
            get { return positionalString; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}